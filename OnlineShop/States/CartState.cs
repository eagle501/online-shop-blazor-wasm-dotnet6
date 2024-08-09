

using OnlineShop.Models;
using System.Net.Http.Json;
using System.Net.Http;
using OnlineShop.Utilities;  // Add this namespace

namespace OnlineShop.States { 

public class CartState
{
    private readonly HttpClient _httpClient;

    public List<Product> SelectedItems { get; set; } = new();

    private readonly INotificationService _notificationService;

    

    public CartState(HttpClient httpClient, INotificationService notificationService)
    {
        _httpClient = httpClient;
        _notificationService = notificationService;
    }

    public async Task AddProductToCartAsync(Guid productId)
    {
        if (!SelectedItems.Any(p => p.Id == productId))
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("sample-data/products.json") ?? new List<Product>();
            var product = products.First(p => p.Id == productId);
            SelectedItems.Add(product);
            await _notificationService.Publish(new CartChangeEvent { Items = SelectedItems });
        }
    }

    public void RemoveProductFromCart(Guid productId)
    {
        SelectedItems.RemoveAll(p => p.Id == productId);
        _notificationService.Publish(new CartChangeEvent { Items = SelectedItems });
    }
  

    
}

public class CartChangeEvent
{
    public List<Product> Items { get; set; }
}







}






/*
using OnlineShop.Models;
using System.Net.Http.Json;

namespace OnlineShop.States;

public class CartState
{
    private readonly HttpClient _httpClient;

    public List<Product> SelectedItems { get; set; } = new();

    public CartState(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddProductToCartAsync(Guid productId)
    {
        if (SelectedItems.Any(p => p.Id == productId) is false)
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("sample-data/products.json") ?? new();
            var product = products.First(p => p.Id == productId);
            SelectedItems.Add(product);
        }
    }
}
*/