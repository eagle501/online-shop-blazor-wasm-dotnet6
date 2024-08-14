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

    public int LargeShrit { get; set; } = 0;
    public int MediumShrit { get; set; } = 0;
    public int SmallShrit { get; set; } = 0;

  
  
    


}

