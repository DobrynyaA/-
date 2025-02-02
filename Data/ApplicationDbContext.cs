using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NikePro.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
		public DbSet<ApplicationUser> ApplicationUsers { get; set; } = default!;
		public DbSet<Cart> Carts { get; set; } = default!;
		public DbSet<CartItem> CartItems { get; set; } = default!;
		public DbSet<Client> Clients { get; set; } = default!;
		public DbSet<Employee> Employees { get; set; } = default!;
		public DbSet<Order> Orders { get; set; } = default!;
		public DbSet<OrderItem> OrderItems { get; set; } = default!;
		public DbSet<OrderStatus> OrderStatuses { get; set; } = default!;
		public DbSet<Product> Products { get; set; } = default!;
		public DbSet<ProductType> ProductTypes { get; set; } = default!;
		public DbSet<Service> Services { get; set; } = default!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

	}
}
