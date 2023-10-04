namespace ProvaPub.Models
{
	public class Customer : Base
	{		
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
