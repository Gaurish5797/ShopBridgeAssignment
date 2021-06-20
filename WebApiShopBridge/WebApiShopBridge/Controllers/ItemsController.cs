using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebApiShopBridge.Controllers
{
    public class ItemsController : ApiController
    {

       

        [HttpGet]
        [Route("api/GetItem")]
        public async Task<IHttpActionResult> GetItem(int? itemId)
        {
            try
            {
                object result;
                Item resultItem;

                
                //TODO : Authorization code here if any

                using (var context = new ItemDbConfig())
                {
                    if (itemId == null)
                    {
                        result = context.Item.ToList();
                    }
                    else
                    {
                        resultItem = await context.Item.FindAsync(itemId);
                        result = resultItem;
                    }
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return ErrorAsync(ex, this.Request.RequestUri.ToString());
            }
        }

        [HttpPut]
        [Route("api/InsertItem")]
        public async Task<IHttpActionResult> InsertItem(String ItemName, String ItemDescription, double ItemPrice)
        {

            try
            {

                object result = null;

                //TODO : Authorization code here if any

                //Basic Validations
                if (ItemName.Trim() != string.Empty)

                    using (var context = new ItemDbConfig())
                    {
                        Item item = new Item() { ItemName = ItemName, ItemDescription = ItemDescription, ItemPrice = Convert.ToDecimal(ItemPrice) };

                        context.Item.Add(item);

                        //Will execute sp InsertItem 
                        await context.SaveChangesAsync();

                        result = item;
                    }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return ErrorAsync(ex, this.Request.RequestUri.ToString());
            }
        }

        [HttpPut]
        [Route("api/SaveItem")]
        public async Task<IHttpActionResult> SaveItem(int itemId, String ItemName, String ItemDescription, double ItemPrice)
        {
            try
            {

                object result;

                //TODO : Authorization code here if any

                using (var context = new ItemDbConfig())
                {
                    Item item = context.Item.Find(itemId);

                    if (item != null)
                    {
                        item.ItemName = ItemName;
                        item.ItemDescription = ItemDescription;
                        item.ItemPrice = Convert.ToDecimal(ItemPrice);

                        //Will execute sp UpdateItem 
                        await context.SaveChangesAsync();
                    }
                    result = item;
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return ErrorAsync(ex, this.Request.RequestUri.ToString());
            }
        }

        [HttpDelete]
        [Route("api/DeleteItem")]
        public async Task<IHttpActionResult> DeleteItem(int itemId)
        {
            try
            {

                object result = null;

                //TODO : Authorization code here if any

                using (var context = new ItemDbConfig())
                {
                    Item item = context.Item.Find(itemId);

                    if (item != null)
                    {
                        context.Item.Remove(item);

                        //Will execute sp DeleteItem 
                        await context.SaveChangesAsync();

                        result = item;
                    }
                }

                if (result != null)
                    return Ok("Delete Successful");
                else
                    return Ok("Cant find record");

            }
            catch (Exception ex)
            {
                return ErrorAsync(ex, this.Request.RequestUri.ToString());
            }
        }
        protected IHttpActionResult ErrorAsync(Exception ex, string uri, object value = null, bool returnException = false)
        {
            string error = "";
            try
            {
                //TODO : Put code here if error needs to be logged in a log file
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception e)
            {

                return Content(HttpStatusCode.InternalServerError,  e.Message);
            }

        }
    }
}
