namespace Web.Models
{
    using System.Collections.Generic;

    public class ProductRepository
    {
        private readonly List<Product> _items;

        public ProductRepository()
        {
            var ids = 1;

            _items = new List<Product>
            {
                new Product { Id = ids++, Name = "Notebook Acer Aspiron", Price = 250.99m, Image = "https://res.cloudinary.com/enjoei/image/upload/c_thumb,f_auto,g_center,h_294,q_80,w_276/jvc77a8akrc0xynofimi.jpg" },
                new Product { Id = ids++, Name = "Notebook Acer Aspiron", Price = 250.99m, Image = "https://res.cloudinary.com/enjoei/image/upload/a_270,c_thumb,f_auto,g_center,h_294,q_80,w_276/emjnxinmae6hq1g2gtyn.jpg" },
                new Product { Id = ids++, Name = "Notebook Acer Aspiron", Price = 250.99m, Image = "https://res.cloudinary.com/enjoei/image/upload/c_thumb,f_auto,g_center,h_294,q_80,w_276/fmi5feex8yylxst0i5yq.jpg" },

                new Product { Id = ids++, Name = "Notebook Acer Aspiron", Price = 250.99m, Image = "https://res.cloudinary.com/enjoei/image/upload/c_thumb,f_auto,g_center,h_294,q_80,w_276/fmi5feex8yylxst0i5yq.jpg" },
                new Product { Id = ids++, Name = "Notebook Acer Aspiron", Price = 250.99m, Image = "https://res.cloudinary.com/enjoei/image/upload/a_270,c_thumb,f_auto,g_center,h_294,q_80,w_276/emjnxinmae6hq1g2gtyn.jpg" },
                new Product { Id = ids++, Name = "Notebook Acer Aspiron", Price = 250.99m, Image = "https://res.cloudinary.com/enjoei/image/upload/c_thumb,f_auto,g_center,h_294,q_80,w_276/jvc77a8akrc0xynofimi.jpg" },

                new Product { Id = ids, Name = "Notebook Acer Aspiron", Price = 250.99m, Image = "https://res.cloudinary.com/enjoei/image/upload/a_270,c_thumb,f_auto,g_center,h_294,q_80,w_276/emjnxinmae6hq1g2gtyn.jpg" },
            };
        }

        public IEnumerable<Product> All()
        {
            return _items;
        }

        public void Save(Product product)
        {
            _items.Add(product);
        }
    }
}