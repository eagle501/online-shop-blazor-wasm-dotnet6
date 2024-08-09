using OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;
public class CartStore
{
    private static readonly CartStore _instance = new CartStore();

    public static CartStore Instance => _instance;

    public List<Product> SelectedItems { get; set; } = new List<Product>();

    public int SelectedItemsCount => SelectedItems.Count;

    public decimal TotalPrice => (decimal)SelectedItems.Sum(p => p.Price);
}