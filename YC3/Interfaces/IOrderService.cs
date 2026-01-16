using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YC3.Interfaces;

public interface IOrderService
{
    // Thêm tham số decimal totalAmount vào cuối
    Task<Guid> PlaceOrderAsync(Guid userId, Guid eventId, List<Guid> seatIds, decimal totalAmount);
}