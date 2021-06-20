﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiShopBridge
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ItemDbConfig : DbContext
    {
        public ItemDbConfig()
            : base("name=ItemDbConfig")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Item> Item { get; set; }
    
        public virtual int DeleteItem(Nullable<int> itemId)
        {
            var itemIdParameter = itemId.HasValue ?
                new ObjectParameter("ItemId", itemId) :
                new ObjectParameter("ItemId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteItem", itemIdParameter);
        }
    
        public virtual int InsertItem(string itemName, string itemDescription, Nullable<decimal> itemPrice)
        {
            var itemNameParameter = itemName != null ?
                new ObjectParameter("ItemName", itemName) :
                new ObjectParameter("ItemName", typeof(string));
    
            var itemDescriptionParameter = itemDescription != null ?
                new ObjectParameter("ItemDescription", itemDescription) :
                new ObjectParameter("ItemDescription", typeof(string));
    
            var itemPriceParameter = itemPrice.HasValue ?
                new ObjectParameter("ItemPrice", itemPrice) :
                new ObjectParameter("ItemPrice", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertItem", itemNameParameter, itemDescriptionParameter, itemPriceParameter);
        }
    
        public virtual ObjectResult<SelectItems_Result> SelectItems(Nullable<int> itemId)
        {
            var itemIdParameter = itemId.HasValue ?
                new ObjectParameter("ItemId", itemId) :
                new ObjectParameter("ItemId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectItems_Result>("SelectItems", itemIdParameter);
        }
    
        public virtual int UpdateItem(Nullable<int> itemId, string itemName, string itemDescription, Nullable<decimal> itemPrice)
        {
            var itemIdParameter = itemId.HasValue ?
                new ObjectParameter("ItemId", itemId) :
                new ObjectParameter("ItemId", typeof(int));
    
            var itemNameParameter = itemName != null ?
                new ObjectParameter("ItemName", itemName) :
                new ObjectParameter("ItemName", typeof(string));
    
            var itemDescriptionParameter = itemDescription != null ?
                new ObjectParameter("ItemDescription", itemDescription) :
                new ObjectParameter("ItemDescription", typeof(string));
    
            var itemPriceParameter = itemPrice.HasValue ?
                new ObjectParameter("ItemPrice", itemPrice) :
                new ObjectParameter("ItemPrice", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateItem", itemIdParameter, itemNameParameter, itemDescriptionParameter, itemPriceParameter);
        }
    }
}