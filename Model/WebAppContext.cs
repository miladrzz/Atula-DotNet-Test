using Microsoft.EntityFrameworkCore;

namespace AtulaDotNetTest.Model
{
    public class WebAppContext: DbContext 
    {
        public WebAppContext(DbContextOptions<WebAppContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            // seed categories
            modelbuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "table" },
                new Category { Id = 2, Name = "chair" },
                new Category { Id = 3, Name = "sofa" }
            );

            // seed products
            modelbuilder.Entity<Product>().HasData(
                new Product { Id = 1, Sku = 2, Name = "lorem table" },
                new Product { Id = 2, Sku = 2, Name = "ipsum table" },
                new Product { Id = 3, Sku = 4, Name = "dolor table" },
                new Product { Id = 4, Sku = 2, Name = "sit chair" },
                new Product { Id = 5, Sku = 1, Name = "amet chair" },
                new Product { Id = 6, Sku = 5, Name = "consectetur chair" },
                new Product { Id = 7, Sku = 9, Name = "adipiscing sofa" },
                new Product { Id = 8, Sku = 1, Name = "elit sofa" },
                new Product { Id = 9, Sku = 3, Name = "mauris sofa" }
            );

            // seeding many-to-many relationship between products and categories
            modelbuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.HasData(
                    new { ProductsId = 1, CategoriesId = 1 }, // lorem table -> table
                    new { ProductsId = 2, CategoriesId = 1 }, // ipsum table -> table
                    new { ProductsId = 3, CategoriesId = 1 }, // dolor table -> table
                    new { ProductsId = 4, CategoriesId = 2 }, // sit chair -> chair
                    new { ProductsId = 5, CategoriesId = 2 }, // amet chair -> chair
                    new { ProductsId = 6, CategoriesId = 2 }, // consectetur chair -> chair
                    new { ProductsId = 7, CategoriesId = 3 }, // adipiscing sofa -> sofa
                    new { ProductsId = 8, CategoriesId = 3 }, // elit sofa -> sofa
                    new { ProductsId = 9, CategoriesId = 3 }  // mauris sofa -> sofa
                ));
        }

    }
}
