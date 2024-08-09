using MaselaTea.Enums;

namespace MaselaTea.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string Barcode { get; set; }
    public Color Color { get; set; }
    //Catgeory
}
