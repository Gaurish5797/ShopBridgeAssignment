/******************************
 * Author : Gaurish Abhisheki
 * Date   : 20.06.2021
 * Tests using MSUNIT
 *****************************/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiShopBridge.Controllers;
using WebApiShopBridge;
using System.Threading.Tasks;


namespace ShopBridgeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void   TestInit()
        {
            try
            {
                //Creates Dummy recrods for test in the TEST DB
                var context = new WebApiShopBridge.ItemDbConfig();
                context.Database.ExecuteSqlCommand("EXEC CreateTestRecords");
            }
            
            catch(Exception Exp)
            {
                Console.WriteLine( Exp.Message);
            }
            
        }
        [TestMethod]
        public async Task  Test1GetItemSingleId()
        {
            try
            {

                int ItemId = 1;
                WebApiShopBridge.Controllers.ItemsController itemscontroller = new WebApiShopBridge.Controllers.ItemsController();
                var result = await itemscontroller.GetItem(ItemId);

                WebApiShopBridge.Item item;
                if (result.GetType().Equals(typeof(System.Web.Http.Results.OkNegotiatedContentResult<object>)))
                {
                    item = (WebApiShopBridge.Item)((System.Web.Http.Results.OkNegotiatedContentResult<object>)result).Content;
                    Assert.AreEqual(ItemId, item.ItemId);
                    Console.WriteLine("Getitem Single Id Passed");
                }
                else
                {
                    Assert.Fail();
                    Console.WriteLine("Getitem single Id Failed");
                }
            }
            catch(Exception Exp)
            {
                Console.WriteLine("Getitem single Id Failed -> " + Exp.Message);
            }
        }

        [TestMethod]
        public async Task Test2GetItemAll()
        {
            try
            {
                WebApiShopBridge.Controllers.ItemsController itemscontroller = new WebApiShopBridge.Controllers.ItemsController();
                var result = await itemscontroller.GetItem(null);

                if (result.GetType().Equals(typeof(System.Web.Http.Results.OkNegotiatedContentResult<object>)))
                {
                    var items = ((System.Web.Http.Results.OkNegotiatedContentResult<object>)result).Content;
                    int count = ((System.Collections.Generic.List<WebApiShopBridge.Item>)(items)).Count;
                    Assert.AreEqual(count , 5);
                    Console.WriteLine("GetItem All Passed");
                }
                else
                {
                    Assert.Fail();
                    Console.WriteLine("GetItem All Failed");
                }
            }
            catch (Exception Exp)
            {
                Console.WriteLine("GetItem All Failed -> " + Exp.Message);
            }
        }

        [TestMethod]
        public async Task Test3InsertItem()
        {
            try
            {
                WebApiShopBridge.Controllers.ItemsController itemscontroller = new WebApiShopBridge.Controllers.ItemsController();
                var result = await itemscontroller.InsertItem("TestItem", "TestDecription", 999.99);

                WebApiShopBridge.Item item;
                if (result.GetType().Equals(typeof(System.Web.Http.Results.OkNegotiatedContentResult<object>)))
                {
                     item = (WebApiShopBridge.Item)((System.Web.Http.Results.OkNegotiatedContentResult<object>)result).Content;
                     Assert.AreEqual("TestItem",item.ItemName);
                     Console.WriteLine("InsertItem Passed");
                }
                else
                {
                    Assert.Fail();
                    Console.WriteLine("InsertItem Failed");
                }
            }
            catch (Exception Exp)
            {
                Console.WriteLine("InsertItem Failed -> " + Exp.Message);
            }
        }

        [TestMethod]
        public async Task Test4SaveItem()
        {
            try
            {
                WebApiShopBridge.Controllers.ItemsController itemscontroller = new WebApiShopBridge.Controllers.ItemsController();
                var result = await itemscontroller.SaveItem(2,"TestItem", "TestDecription", 999.99);

                WebApiShopBridge.Item item;
                if (result.GetType().Equals(typeof(System.Web.Http.Results.OkNegotiatedContentResult<object>)))
                {
                    item = (WebApiShopBridge.Item)((System.Web.Http.Results.OkNegotiatedContentResult<object>)result).Content;
                    Assert.AreEqual("TestItem", item.ItemName);
                    Console.WriteLine("SaveItem Passed");
                }
                else
                {
                    Assert.Fail();
                    Console.WriteLine("SaveItem Failed");
                }
            }
            catch (Exception Exp)
            {
                Console.WriteLine("SaveItem Failed -> " + Exp.Message);
            }
        }

        [TestMethod]
        public async Task Test5DeleteItem()
        {
            try
            {
                WebApiShopBridge.Controllers.ItemsController itemscontroller = new WebApiShopBridge.Controllers.ItemsController();
                var result = await itemscontroller.DeleteItem(4);

                if (result.GetType().Equals(typeof(System.Web.Http.Results.OkNegotiatedContentResult<String>)))
                {
                    var returnedstring = ((System.Web.Http.Results.OkNegotiatedContentResult<String>)result).Content;

                    Assert.AreEqual("Delete Successful", returnedstring);
                    Console.WriteLine("DeleteItem All Passed");
                }
                else
                {
                    Assert.Fail();
                    Console.WriteLine("DeleteItem  Failed");
                }
            }
            catch (Exception Exp)
            {
                Console.WriteLine("DeleteItem  Failed -> " + Exp.Message);
            }
        }
    }
}
