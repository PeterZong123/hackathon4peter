namespace ServiceRole.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Long { get; set; }

        public int Weight { get; set; }

        public string Category { get; set; }
    }
}