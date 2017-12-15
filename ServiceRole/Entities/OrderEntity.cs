using Microsoft.WindowsAzure.Storage.Table;
using ServiceRole.Models;

namespace ServiceRole.Entities
{
    public class OrderEntity : TableEntity
    {
        private const string PartitionKeyForTable = "1";

        public OrderEntity()
        {

        }

        public OrderEntity(int orderId, int productId, int height, int width, int _long, int weight, string category)
        {
            PartitionKey = PartitionKeyForTable;
            RowKey = orderId.ToString();
            OrderId = orderId;
            ProductId = productId;
            Height = height;
            Width = width;
            Long = _long;
            Weight = weight;
            Category = category;
        }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Long { get; set; }

        public int Weight { get; set; }

        public string Category { get; set; }

        public Order ToDTO()
        {
            var order = new Order
            {
                Category = this.Category,
                Height = this.Height,
                Width = this.Width,
                Long = this.Long,
                OrderId = this.OrderId,
                ProductId = this.ProductId,
                Weight = this.Weight
            };

            return order;
        }
    }
}