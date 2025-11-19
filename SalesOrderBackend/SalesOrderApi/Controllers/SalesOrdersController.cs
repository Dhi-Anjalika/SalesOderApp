using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // 👈 ADD THIS
using SalesOrderApi.Models;

namespace SalesOrderApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesOrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public SalesOrdersController(AppDbContext context)
    {
        _context = context;
    }

    // 👇 ADD THIS METHOD
    [HttpGet]
    public async Task<ActionResult<List<SalesOrder>>> GetSalesOrders()
    {
        return await _context.SalesOrders
            .Include(o => o.Client)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> CreateSalesOrder(SalesOrderDto dto)
    {
        var order = new SalesOrder
        {
            ClientId = dto.ClientId,
            InvoiceNo = dto.InvoiceNo,
            InvoiceDate = dto.InvoiceDate,
            ReferenceNo = dto.ReferenceNo,
            Note = dto.Note
        };

        _context.SalesOrders.Add(order);
        await _context.SaveChangesAsync();

        foreach (var itemDto in dto.Items)
        {
            var item = new SalesOrderItem
            {
                SalesOrderId = order.Id,
                ItemCode = itemDto.ItemCode,
                Description = itemDto.Description,
                Note = itemDto.Note,
                Quantity = itemDto.Quantity,
                Price = itemDto.Price,
                TaxRate = itemDto.TaxRate
            };
            _context.SalesOrderItems.Add(item);
        }

        await _context.SaveChangesAsync();
        return Ok(new { Id = order.Id });
    }
}

public class SalesOrderDto
{
    public int ClientId { get; set; }
    public string InvoiceNo { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public string ReferenceNo { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public List<SalesOrderItemDto> Items { get; set; } = new();
}

public class SalesOrderItemDto
{
    public string ItemCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TaxRate { get; set; }
}