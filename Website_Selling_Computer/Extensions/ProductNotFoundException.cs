namespace Website_Selling_Computer.Extensions
{
	public class ProductNotFoundException :Exception
	{
		public ProductNotFoundException(string message) : base(message)
		{
		}
	}
}
