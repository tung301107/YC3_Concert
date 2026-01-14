using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YC3.Interfaces;

public interface IOrderService
{
    // Đảm bảo tên là PlaceOrderAsync và có đủ 3 tham số
    Task<Guid> PlaceOrderAsync(Guid userId, Guid eventId, List<Guid> seatIds);
}