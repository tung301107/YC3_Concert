using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YC3.Interfaces;

public interface IOrderService
{
    Task<Guid> PlaceOrderAsync(Guid userId, Guid eventId, List<Guid> seatIds);
}