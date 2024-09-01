namespace AtulaDotNetTest.Model
{
    public class Product
    {
        public int Id { get; set; }
        public required int Sku { get; set; }
        public required string Name { get; set; }

        public List<Category>? Categories { get; set; }

    }
}
