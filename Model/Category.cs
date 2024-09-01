﻿namespace AtulaDotNetTest.Model
{
    public class Category
    {
        public int Id { get; set; } 
        public required string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
