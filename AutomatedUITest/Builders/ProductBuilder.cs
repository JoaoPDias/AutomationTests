namespace AutomatedUITest.Builders
{
    public class ProductBuilder
    {
        private Product _product;

        private ProductBuilder()
        {
            _product = new Product();
            _product.Title = "H.264 Megapixel Surveillance Camera TL-SC3430";
            _product.UnitPrice = "82.94";
        }

        public static ProductBuilder New()
        {
            return new ProductBuilder();
        }

        public ProductBuilder WithName(string name)
        {
            _product.Title = name;
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
