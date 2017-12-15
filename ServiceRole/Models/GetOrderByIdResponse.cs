using System.Collections.Generic;
using System.Linq;
using ServiceRole.Entities;

namespace ServiceRole.Models
{
    public class GetOrderByIdResponse
    {
        public List<Order> Orders { get; set; }

        public GetOrderByIdResponse(IQueryable<OrderEntity> entities)
        {
            Orders = new List<Order>();

            foreach (var entity in entities)
            {
                Orders.Add(entity.ToDTO());
            }
        }
    }
}