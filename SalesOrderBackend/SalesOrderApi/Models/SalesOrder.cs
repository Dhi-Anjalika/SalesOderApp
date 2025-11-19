// namespace SalesOrderApi.Models;

// public class SalesOrder
// {
//     public int Id { get; set; }
//     public int ClientId { get; set; }
//     public string InvoiceNo { get; set; } = string.Empty;
//     public DateTime InvoiceDate { get; set; }
//     public string ReferenceNo { get; set; } = string.Empty;
//     public string Note { get; set; } = string.Empty;
//     public List<SalesOrderItem> Items { get; set; } = new();
// }

namespace SalesOrderApi.Models;

public class SalesOrder
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    
    // 👇 ADD THIS LINE
    public Client Client { get; set; } = null!;

    public string InvoiceNo { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public string ReferenceNo { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public List<SalesOrderItem> Items { get; set; } = new();
}