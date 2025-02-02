namespace NikePro.Data
{
	public class Product
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public ProductType ProductType { get; set; }
		public int ProductTypeId { get; set; }
		public string ImagesUrl { get; set; }
		public int Price { get; set; }
		public string Description { get; set; }
	}
}
