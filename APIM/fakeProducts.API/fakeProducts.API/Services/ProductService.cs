namespace fakeProducts.API.Services
{

    public class ProductService
    {
        private List<Product> products = new()
        {
            new(){ Id=1, Name="IPhone", Price=35000},
            new(){ Id=2, Name="Samsung", Price=25000},
            new(){ Id=3, Name="Xiaomi", Price=6500}
        };

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.Find(x => x.Id == id);

        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }


    }
}
