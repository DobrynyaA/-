namespace NikePro.Data
{
	public class Order
	{
		public int OrderId { get; set; }
		public int? CartId { get; set; }
		public int ClientId { get; set; }
		public Client Client { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now.ToUniversalTime();
		public DateTime? OrderDateEnd { get; set; }
		public int OrderStatusId { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public int? EmployeeId {  get; set; }
		public Employee? Employee { get; set; }
		public decimal TotalAmount { get; set; }
		public ICollection<OrderItem> OrderItems { get; set; } = [];

	}
}
