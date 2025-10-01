using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<MenuItem>().HasData(new MenuItem
        {
            Id = 1,
            Name = "Bruschetta",
            Description = "Crispy toasted bread topped with fresh tomatoes, basil, garlic, and a drizzle of olive oil.",
            Image = "images/bruschetta.webp",
            Price = 6.49,
            Category = "Appetizer",
            SpecialTag = ""
        },
        new MenuItem
        {
            Id = 2,
            Name = "Stuffed Mushrooms",
            Description = "Mushroom caps filled with seasoned cream cheese, herbs, and breadcrumbs, baked to golden perfection.",
            Image = "images/stuffed_mushrooms.jpeg",
            Price = 7.99,
            Category = "Appetizer",
            SpecialTag = "Customer Favorite"
        },
        new MenuItem
        {
            Id = 3,
            Name = "Caesar Salad",
            Description = "Crisp romaine lettuce tossed with parmesan, crunchy croutons, and creamy Caesar dressing.",
            Image = "images/caesar_salad.jpg",
            Price = 8.49,
            Category = "Appetizer",
            SpecialTag = "Light & Fresh"
        },
        new MenuItem
        {
            Id = 4,
            Name = "Grilled Salmon",
            Description = "Fresh Atlantic salmon fillet grilled to perfection, served with roasted vegetables and lemon butter sauce.",
            Image = "images/grilled_salmon.jpg",
            Price = 16.99,
            Category = "Entrée",
            SpecialTag = "Chef's Choice"
        },
        new MenuItem
        {
            Id = 5,
            Name = "Chicken Alfredo Pasta",
            Description = "Creamy fettuccine Alfredo topped with tender grilled chicken and sprinkled with parmesan.",
            Image = "images/chicken_alfredo.png",
            Price = 14.99,
            Category = "Entrée",
            SpecialTag = "Top Rated"
        },
        new MenuItem
        {
            Id = 6,
            Name = "Margherita Pizza",
            Description = "Classic pizza with fresh mozzarella, ripe tomatoes, and aromatic basil leaves on a thin crust.",
            Image = "images/margherita_pizza.jpg",
            Price = 12.49,
            Category = "Entrée",
            SpecialTag = ""
        },
        new MenuItem
        {
            Id = 7,
            Name = "Chocolate Lava Cake",
            Description = "Warm chocolate cake with a gooey molten center, served with a scoop of vanilla ice cream.",
            Image = "images/choco_lava.jpg",
            Price = 6.99,
            Category = "Dessert",
            SpecialTag = "Best Seller"
        },
        new MenuItem
        {
            Id = 8,
            Name = "Strawberry Cheesecake",
            Description = "Rich and creamy cheesecake topped with fresh strawberries and a drizzle of berry coulis.",
            Image = "images/strawberry_cheesecake.jpg",
            Price = 7.49,
            Category = "Dessert",
            SpecialTag = ""
        },
        new MenuItem
        {
            Id = 9,
            Name = "Tiramisu",
            Description = "Italian classic dessert with layers of espresso-soaked ladyfingers and mascarpone cream.",
            Image = "images/tiramisu.avif",
            Price = 7.99,
            Category = "Dessert",
            SpecialTag = "Chef's Special"
        },
        new MenuItem
        {
            Id = 10,
            Name = "Classic Burger",
            Description = "Juicy beef patty with cheddar cheese, lettuce, tomato, and pickles, served with fries.",
            Image = "images/classic_burger.jpg",
            Price = 9.99,
            Category = "Entrée",
            SpecialTag = "Top Rated"
        },
        new MenuItem
        {
            Id = 11,
            Name = "Chicken Taco",
            Description = "Soft tortillas filled with grilled chicken, fresh salsa, avocado, and a drizzle of lime crema.",
            Image = "images/chicken_taco.webp",
            Price = 8.49,
            Category = "Entrée",
            SpecialTag = ""
        },
        new MenuItem
        {
            Id = 12,
            Name = "Veggie Wrap",
            Description = "A healthy wrap with hummus, mixed greens, cucumber, bell peppers, and shredded carrots.",
            Image = "images/veggie_wrap.jpg",
            Price = 7.99,
            Category = "Entrée",
            SpecialTag = "Vegetarian"
        },
        new MenuItem
        {
            Id = 13,
            Name = "Chocolate Brownie",
            Description = "Rich and fudgy chocolate brownie served warm with a scoop of vanilla ice cream.",
            Image = "images/chocolate_brownie.jpeg",
            Price = 5.49,
            Category = "Dessert",
            SpecialTag = "Chef's Special"
        },
        new MenuItem
        {
            Id = 14,
            Name = "Fruit Parfait",
            Description = "Layers of fresh seasonal fruits, yogurt, and granola, served in a glass.",
            Image = "images/fruit_parfait.jpg",
            Price = 4.99,
            Category = "Dessert",
            SpecialTag = "Healthy Choice"
        },
        new MenuItem
        {
            Id = 15,
            Name = "Garlic Bread",
            Description = "Toasted baguette slices topped with garlic butter and herbs, served warm.",
            Image = "images/garlic_bread.jpg",
            Price = 4.49,
            Category = "Appetizer",
            SpecialTag = ""
        },
        new MenuItem
        {
            Id = 16,
            Name = "Mozzarella Sticks",
            Description = "Crispy breaded mozzarella sticks served with marinara dipping sauce.",
            Image = "images/mozzarella_sticks.jpeg",
            Price = 5.99,
            Category = "Appetizer",
            SpecialTag = "Best Seller"
        },
        new MenuItem
        {
            Id = 17,
            Name = "Beef Burrito",
            Description = "Flour tortilla filled with seasoned beef, rice, beans, cheese, and fresh salsa.",
            Image = "images/beef_burrito.jpg",
            Price = 10.49,
            Category = "Entrée",
            SpecialTag = ""
        },
        new MenuItem
        {
            Id = 18,
            Name = "Grilled Veggie Sandwich",
            Description = "Grilled zucchini, bell peppers, and eggplant with pesto spread on whole-grain bread.",
            Image = "images/grilled_veggie_sandwich.jpg",
            Price = 8.99,
            Category = "Entrée",
            SpecialTag = "Vegetarian"
        },
        new MenuItem
        {
            Id = 19,
            Name = "Fish & Chips",
            Description = "Crispy fried fish fillets served with golden fries and tartar sauce.",
            Image = "images/fish_chips.jpg",
            Price = 12.99,
            Category = "Entrée",
            SpecialTag = ""
        },
        new MenuItem
        {
            Id = 20,
            Name = "Lemon Tart",
            Description = "Tangy lemon custard in a buttery crust topped with whipped cream.",
            Image = "images/lemon_tart.jpg",
            Price = 5.49,
            Category = "Dessert",
            SpecialTag = ""
        }
        );
    }
}
