using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedUITest
{
    public class ProductBuilder
    {
        private Product _product;

        private ProductBuilder()
        {
            _product = new Product();
            _product.Name = "H.264 Megapixel Surveillance Camera TL-SC3430";
            _product.UnitPrice = "$82.94";
        }

        public static ProductBuilder New()
        {
            return new ProductBuilder();
        }

        public ProductBuilder WithName(string name)
        {
            _product.Name = name;
            return this;
        }

        public ProductBuilder WithUnitPrice(string unitPrice)
        {
            _product.UnitPrice = unitPrice;
            return this;
        }

        public Product Build()
        {
            return _product;
        }
    }
}
