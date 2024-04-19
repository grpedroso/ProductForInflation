namespace ProductInflation.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
        public override string ToString()
        {
            return $@"Id: {Id}
                      Producto: {Name}
                      Descripcion: {Description}
                      Precio: {Price}";
        }
    }
}
