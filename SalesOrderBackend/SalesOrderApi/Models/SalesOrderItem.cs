namespace SalesOrderApi.Models;

public class SalesOrderItem
{
    public int Id { get; set; }
    public int SalesOrderId { get; set; }
    public string ItemCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TaxRate { get; set; }
}