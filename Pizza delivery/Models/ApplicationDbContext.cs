using Microsoft.EntityFrameworkCore;
namespace Pizza_delivery.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            /*Database.EnsureCreated(); */
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Pizza.sqlite");
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id=1,
                Name = "Classics",
                Desc = "Pizza classics that you all love"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id=2,
                Name = "meat",
                Desc = "Meat on your pizza"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                    Id=3,
                Name = "Vegan Pizzas",
                Desc = "For people who can't eat meat"
            });


            modelBuilder.Entity<Pizza>().HasData(new Pizza
            {
                PizzaId = 1,
                Name = "Cheese Pizza",
                Shortdesc = "Classic Cheese Pizza",
                Longdesc = "A delicious pizza topped with melted cheese",
                Allergyinfo = "Contains dairy",
                Price = 9.99,
                ImgUrl = "https://imgs.search.brave.com/Jjnq5FREzGTpj2krf9WTHMj5l9BvaHVf5UJciqytNPA/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTgw/ODIyNjYxL3Bob3Rv/L2NoZWVzZS1waXp6/YS5qcGc_cz02MTJ4/NjEyJnc9MCZrPTIw/JmM9NzVFcS1FMm5X/aWdpVXRnejJkamty/YTU0X0J6dVRBYkRK/V3kxUWktS0xZYz0",
                                ImgThumbnailUrl = "https://imgs.search.brave.com/VlW0WkN_bI_ZhO6IsbzS-HMFLwxx8CYrryk_jVEwasU/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvMTY4/Mjc1ODE2L3Bob3Rv/L2NoZWVzZS5qcGc_/cz02MTJ4NjEyJnc9/MCZrPTIwJmM9cE9W/b2JkTlEwMzJTZ082/UXo0Wm85TmhSRVpI/UTc5cVJJeThXaDZ4/Y28waz0",
                                IsPizzaOfTheWeek = false,
                InStock = true,
                CategoryId = 1
            });

            modelBuilder.Entity<Pizza>().HasData(new Pizza
            {
                PizzaId = 2,
                Name = "Vegan Cheese Pizza",
                Shortdesc = "Plant based cheese",
                Longdesc = "Plant based cheese",
                Allergyinfo = "nothing",
                Price = 10,
                ImgUrl = "https://imgs.search.brave.com/MeJ3RDJ3UuA5xaxwq65TaWkVp7e-f6asXGspokh7bfk/rs:fit:860:0:0/g:ce/aHR0cHM6Ly93aWxs/YW1ldHRldHJhbnNw/bGFudC5jb20vd3At/Y29udGVudC91cGxv/YWRzLzIwMTkvMDgv/aG9tZW1hZGUtdmVn/YW4tY2hlZXNlLXBp/enphLTY4NXgxMDI0/LmpwZw",
ImgThumbnailUrl = "https://imgs.search.brave.com/qgMChR5wVbLVTI4oumvpSjoqyRhya-jHQnpll5tPrcI/rs:fit:860:0:0/g:ce/aHR0cHM6Ly90aGVi/YW5hbmFkaWFyaWVz/LmNvbS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMy8wMS92ZWdh/bi1waXp6YS1kb3Vn/aF81NjQzLTcwMHgx/MDUwLmpwZw",
IsPizzaOfTheWeek = false,
                InStock = true,
                CategoryId = 3
            });

            modelBuilder.Entity<Pizza>().HasData(new Pizza
            {
                PizzaId = 3,
                Name = "Salami Pizza",
                Shortdesc = "Delicious salami slices atop a crispy crust",
                Longdesc = "Enjoy the bold flavor of thinly sliced salami on our signature pizza crust",
                Allergyinfo = "Contains gluten and meat",
                Price = 11.99,
                ImgUrl = "https://imgs.search.brave.com/7ybT6v3dfciYJZtBrg1RtbbEYqeouH3OYXV-DB0Wu9s/rs:fit:860:0:0/g:ce/aHR0cHM6Ly90aGVy/ZWNpcGVjcml0aWMu/Y29tL3dwLWNvbnRl/bnQvdXBsb2Fkcy8y/MDIyLzEyL3NhbGFt/aV9waXp6YS0xLTc1/MHgxMDAwLmpwZw",
ImgThumbnailUrl = "https://imgs.search.brave.com/v15TfinqIFjMlrGusGgqAmpOLJkk4cjNWG6Zgyr2QT0/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9ob21l/a2l0Y2hlbnRhbGsu/Y29tL3dwLWNvbnRl/bnQvdXBsb2Fkcy8y/MDIxLzExL3NhbGFt/aS1vbi1waXp6YS5q/cGc",
IsPizzaOfTheWeek = true,
                InStock = true,
                CategoryId = 2
            });

            modelBuilder.Entity<Pizza>().HasData(new Pizza
            {
                PizzaId = 4,
                Name = "Meat Lover's Pizza",
            Shortdesc = "Loaded with savory meats",
                Longdesc = "Indulge in a hearty pizza topped with a variety of meats including pepperoni,sausage,ham,and bacon",
                Allergyinfo = "Contains gluten and meat",
                Price = 13.99,
                ImgUrl = "https://imgs.search.brave.com/DvGM0mzzdbkZsJv3X0EsS1fRb0V4S9Rm92R3NSs0u84/rs:fit:860:0:0/g:ce/aHR0cHM6Ly93d3cu/YmFjaW5vcy5jb20v/d3AtY29udGVudC91/cGxvYWRzLzIwMjEv/MDUvVGhlLVVsdGlt/YXRlLU1lYXQtTG92/ZXJzLVBpenphLmpw/Zw",
ImgThumbnailUrl = "https://imgs.search.brave.com/-Nlm3ldmmU4Hs-MVe-fslBqlek8dB1usYyn6jLQ_ARM/rs:fit:860:0:0/g:ce/aHR0cDovL2VtaWx5/Yml0ZXMuY29tL3dw/LWNvbnRlbnQvdXBs/b2Fkcy8yMDExLzEy/L01lYXQtTG92ZXIt/MjUyN3MtUGl6emEt/NWMtNjIweDQxMC5q/cGc",
IsPizzaOfTheWeek = false,
                InStock = true,
                CategoryId = 2
            });


        }

        
        
    }
}
