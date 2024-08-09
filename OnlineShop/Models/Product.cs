namespace OnlineShop.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string ImageURL { get; set; } = "";
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int ItemQuantity { get; set; } = 1;
  
  
    


}

