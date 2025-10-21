using System.Data;
using CoreLayer.Interfaces.Repositories;
using CoreLayer.Models;
using InfrasructureLayer.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace InfrasructureLayer.Repositories;

public class OrderRepository : Repository<OrderModel>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) { }

    // public async Task<IEnumerable<OrderModel>> GetOrdersByCustomerIdAsync(int custumerId)
    // {
    //     var context = Context.Orders;
    //     if (context == null) throw new DataException("In Orders Db context is nullable");
    //
    //     return await context.
    //         Where(e => e.CustomerId == custumerId).
    //         Include(o => o.Car).
    //         ToListAsync();
    // }

    public async Task<IEnumerable<OrderModel>> GetOrdersByDateRange(DateTime fromdate, DateTime todate)
    {
        var context = Context.Orders;/*Include(c => c.Customer)*/
        if (context == null) throw new DataException("In Orders Db context is nullable");

        return await context
            .Where(o => o.OrderDate >= fromdate && o.OrderDate <= todate).Include(c => c.Car)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersByOrderIdAsync(int orderId)
    {
        var context = Context.Orders;
        if (context == null) throw new DataException("In Orders Db context is nullable");

        return await context.Where(o => o.OrderId == orderId).
            Include(o => o.Car).
            ToListAsync();
    }
}