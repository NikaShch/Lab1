using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverFramework.business_objects
{
    class Product
    {
        public Product(string productName, string categoryID, string supplierID, int unitPrice,
            string quantityPerUnit, int unitsInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            Index = 0;
            ProductName = productName;
            CategoryId = categoryID;
            SupplierId = supplierID;
            UnitPrice = unitPrice.ToString();
            QuantityPerUnit = quantityPerUnit;
            UnitsInStock = unitsInStock.ToString();
            UnitsOnOrder = unitsOnOrder.ToString();
            ReorderLevel = reorderLevel.ToString();
            Discontinued = discontinued.ToString();
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
        public string Discontinued { get; set; }

    }

}
