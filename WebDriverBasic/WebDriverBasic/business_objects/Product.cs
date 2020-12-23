using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverFramework.business_objects
{
    class Product
    {
        public Product(string productName, string categoryId, string supplierId, int unitPrice,
            string quantityPerUnit, int unitsInStock, int unitsOnOrder, int reorderLevel)
        {
            Index = 0;
            ProductName = productName;
            CategoryId = categoryId;
            SupplierId = supplierId;
            UnitPrice = unitPrice.ToString();
            QuantityPerUnit = quantityPerUnit;
            UnitsInStock = unitsInStock.ToString();
            UnitsOnOrder = unitsOnOrder.ToString();
            ReorderLevel = reorderLevel.ToString();
        }

        public int Index { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string SupplierId { get; set; }
        public string UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UnitsInStock { get; set; }
        public string UnitsOnOrder { get; set; }
        public string ReorderLevel { get; set; }
        //public string Discontinued { get; set; }


        public override bool Equals(Object obj)
        {
            if (!(obj is Product product)) return false;
            return ProductName == product.ProductName &&
                CategoryId == product.CategoryId &&
                SupplierId == product.SupplierId &&
                UnitPrice == product.UnitPrice &&
                QuantityPerUnit == product.QuantityPerUnit &&
                UnitsInStock == product.UnitsInStock &&
                UnitsOnOrder == product.UnitsOnOrder &&
                ReorderLevel == product.ReorderLevel;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, CategoryId, SupplierId, UnitPrice, QuantityPerUnit, UnitsInStock, UnitsOnOrder, ReorderLevel);
        }
    }

}
