using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Crispy toasted bread topped with fresh tomatoes, basil, garlic, and a drizzle of olive oil.", "images/bruschetta.webp", "Bruschetta", 6.4900000000000002, "" },
                    { 2, "Appetizer", "Mushroom caps filled with seasoned cream cheese, herbs, and breadcrumbs, baked to golden perfection.", "images/stuffed_mushrooms.jpeg", "Stuffed Mushrooms", 7.9900000000000002, "Customer Favorite" },
                    { 3, "Appetizer", "Crisp romaine lettuce tossed with parmesan, crunchy croutons, and creamy Caesar dressing.", "images/caesar_salad.jpg", "Caesar Salad", 8.4900000000000002, "Light & Fresh" },
                    { 4, "Entrée", "Fresh Atlantic salmon fillet grilled to perfection, served with roasted vegetables and lemon butter sauce.", "images/grilled_salmon.jpg", "Grilled Salmon", 16.989999999999998, "Chef's Choice" },
                    { 5, "Entrée", "Creamy fettuccine Alfredo topped with tender grilled chicken and sprinkled with parmesan.", "images/chicken_alfredo.png", "Chicken Alfredo Pasta", 14.99, "Top Rated" },
                    { 6, "Entrée", "Classic pizza with fresh mozzarella, ripe tomatoes, and aromatic basil leaves on a thin crust.", "images/margherita_pizza.jpg", "Margherita Pizza", 12.49, "" },
                    { 7, "Dessert", "Warm chocolate cake with a gooey molten center, served with a scoop of vanilla ice cream.", "images/choco_lava.jpg", "Chocolate Lava Cake", 6.9900000000000002, "Best Seller" },
                    { 8, "Dessert", "Rich and creamy cheesecake topped with fresh strawberries and a drizzle of berry coulis.", "images/strawberry_cheesecake.jpg", "Strawberry Cheesecake", 7.4900000000000002, "" },
                    { 9, "Dessert", "Italian classic dessert with layers of espresso-soaked ladyfingers and mascarpone cream.", "images/tiramisu.avif", "Tiramisu", 7.9900000000000002, "Chef's Special" },
                    { 10, "Entrée", "Juicy beef patty with cheddar cheese, lettuce, tomato, and pickles, served with fries.", "images/classic_burger.jpg", "Classic Burger", 9.9900000000000002, "Top Rated" },
                    { 11, "Entrée", "Soft tortillas filled with grilled chicken, fresh salsa, avocado, and a drizzle of lime crema.", "images/chicken_taco.webp", "Chicken Taco", 8.4900000000000002, "" },
                    { 12, "Entrée", "A healthy wrap with hummus, mixed greens, cucumber, bell peppers, and shredded carrots.", "images/veggie_wrap.jpg", "Veggie Wrap", 7.9900000000000002, "Vegetarian" },
                    { 13, "Dessert", "Rich and fudgy chocolate brownie served warm with a scoop of vanilla ice cream.", "images/chocolate_brownie.jpeg", "Chocolate Brownie", 5.4900000000000002, "Chef's Special" },
                    { 14, "Dessert", "Layers of fresh seasonal fruits, yogurt, and granola, served in a glass.", "images/fruit_parfait.jpg", "Fruit Parfait", 4.9900000000000002, "Healthy Choice" },
                    { 15, "Appetizer", "Toasted baguette slices topped with garlic butter and herbs, served warm.", "images/garlic_bread.jpg", "Garlic Bread", 4.4900000000000002, "" },
                    { 16, "Appetizer", "Crispy breaded mozzarella sticks served with marinara dipping sauce.", "images/mozzarella_sticks.jpeg", "Mozzarella Sticks", 5.9900000000000002, "Best Seller" },
                    { 17, "Entrée", "Flour tortilla filled with seasoned beef, rice, beans, cheese, and fresh salsa.", "images/beef_burrito.jpg", "Beef Burrito", 10.49, "" },
                    { 18, "Entrée", "Grilled zucchini, bell peppers, and eggplant with pesto spread on whole-grain bread.", "images/grilled_veggie_sandwich.jpg", "Grilled Veggie Sandwich", 8.9900000000000002, "Vegetarian" },
                    { 19, "Entrée", "Crispy fried fish fillets served with golden fries and tartar sauce.", "images/fish_chips.jpg", "Fish & Chips", 12.99, "" },
                    { 20, "Dessert", "Tangy lemon custard in a buttery crust topped with whipped cream.", "images/lemon_tart.jpg", "Lemon Tart", 5.4900000000000002, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
