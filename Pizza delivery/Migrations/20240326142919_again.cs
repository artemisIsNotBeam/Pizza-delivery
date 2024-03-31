using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pizza_delivery.Migrations
{
    /// <inheritdoc />
    public partial class again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Desc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Shortdesc = table.Column<string>(type: "TEXT", nullable: false),
                    Longdesc = table.Column<string>(type: "TEXT", nullable: false),
                    Allergyinfo = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ImgThumbnailUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsPizzaOfTheWeek = table.Column<bool>(type: "INTEGER", nullable: false),
                    InStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaId);
                    table.ForeignKey(
                        name: "FK_Pizzas_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PizzaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Desc", "Name" },
                values: new object[,]
                {
                    { 1, "Pizza classics that you all love", "Classics" },
                    { 2, "Meat on your pizza", "meat" },
                    { 3, "For people who can't eat meat", "Vegan Pizzas" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "Allergyinfo", "CategoryId", "ImgThumbnailUrl", "ImgUrl", "InStock", "IsPizzaOfTheWeek", "Longdesc", "Name", "Price", "Shortdesc" },
                values: new object[,]
                {
                    { 1, "Contains dairy", 1, "https://imgs.search.brave.com/VlW0WkN_bI_ZhO6IsbzS-HMFLwxx8CYrryk_jVEwasU/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvMTY4/Mjc1ODE2L3Bob3Rv/L2NoZWVzZS5qcGc_/cz02MTJ4NjEyJnc9/MCZrPTIwJmM9cE9W/b2JkTlEwMzJTZ082/UXo0Wm85TmhSRVpI/UTc5cVJJeThXaDZ4/Y28waz0", "https://imgs.search.brave.com/Jjnq5FREzGTpj2krf9WTHMj5l9BvaHVf5UJciqytNPA/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTgw/ODIyNjYxL3Bob3Rv/L2NoZWVzZS1waXp6/YS5qcGc_cz02MTJ4/NjEyJnc9MCZrPTIw/JmM9NzVFcS1FMm5X/aWdpVXRnejJkamty/YTU0X0J6dVRBYkRK/V3kxUWktS0xZYz0", true, false, "A delicious pizza topped with melted cheese", "Cheese Pizza", 9.9900000000000002, "Classic Cheese Pizza" },
                    { 2, "nothing", 3, "https://imgs.search.brave.com/qgMChR5wVbLVTI4oumvpSjoqyRhya-jHQnpll5tPrcI/rs:fit:860:0:0/g:ce/aHR0cHM6Ly90aGVi/YW5hbmFkaWFyaWVz/LmNvbS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMy8wMS92ZWdh/bi1waXp6YS1kb3Vn/aF81NjQzLTcwMHgx/MDUwLmpwZw", "https://imgs.search.brave.com/MeJ3RDJ3UuA5xaxwq65TaWkVp7e-f6asXGspokh7bfk/rs:fit:860:0:0/g:ce/aHR0cHM6Ly93aWxs/YW1ldHRldHJhbnNw/bGFudC5jb20vd3At/Y29udGVudC91cGxv/YWRzLzIwMTkvMDgv/aG9tZW1hZGUtdmVn/YW4tY2hlZXNlLXBp/enphLTY4NXgxMDI0/LmpwZw", true, false, "Plant based cheese", "Vegan Cheese Pizza", 10.0, "Plant based cheese" },
                    { 3, "Contains gluten and meat", 2, "https://imgs.search.brave.com/v15TfinqIFjMlrGusGgqAmpOLJkk4cjNWG6Zgyr2QT0/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9ob21l/a2l0Y2hlbnRhbGsu/Y29tL3dwLWNvbnRl/bnQvdXBsb2Fkcy8y/MDIxLzExL3NhbGFt/aS1vbi1waXp6YS5q/cGc", "https://imgs.search.brave.com/7ybT6v3dfciYJZtBrg1RtbbEYqeouH3OYXV-DB0Wu9s/rs:fit:860:0:0/g:ce/aHR0cHM6Ly90aGVy/ZWNpcGVjcml0aWMu/Y29tL3dwLWNvbnRl/bnQvdXBsb2Fkcy8y/MDIyLzEyL3NhbGFt/aV9waXp6YS0xLTc1/MHgxMDAwLmpwZw", true, true, "Enjoy the bold flavor of thinly sliced salami on our signature pizza crust", "Salami Pizza", 11.99, "Delicious salami slices atop a crispy crust" },
                    { 4, "Contains gluten and meat", 2, "https://imgs.search.brave.com/-Nlm3ldmmU4Hs-MVe-fslBqlek8dB1usYyn6jLQ_ARM/rs:fit:860:0:0/g:ce/aHR0cDovL2VtaWx5/Yml0ZXMuY29tL3dw/LWNvbnRlbnQvdXBs/b2Fkcy8yMDExLzEy/L01lYXQtTG92ZXIt/MjUyN3MtUGl6emEt/NWMtNjIweDQxMC5q/cGc", "https://imgs.search.brave.com/DvGM0mzzdbkZsJv3X0EsS1fRb0V4S9Rm92R3NSs0u84/rs:fit:860:0:0/g:ce/aHR0cHM6Ly93d3cu/YmFjaW5vcy5jb20v/d3AtY29udGVudC91/cGxvYWRzLzIwMjEv/MDUvVGhlLVVsdGlt/YXRlLU1lYXQtTG92/ZXJzLVBpenphLmpw/Zw", true, false, "Indulge in a hearty pizza topped with a variety of meats including pepperoni,sausage,ham,and bacon", "Meat Lover's Pizza", 13.99, "Loaded with savory meats" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CategoryId",
                table: "Pizzas",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_PizzaId",
                table: "ShoppingCartItems",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
