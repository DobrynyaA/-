namespace NikePro.Data
{
	public class Cart
	{
		public int CartId { get; set; }
		public int Clientid { get; set; }
		public Client Client { get; set; }
		public ICollection<CartItem> Items { get; set; } = [];

	}
}
