using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YC3.Interfaces;

public interface IOrderService
{
    // Đảm bảo Interface định nghĩa đúng tên và tham số
    Task<Guid> PlaceOrderAsync(Guid userId, Guid eventId, List<Guid> seatIds);
}