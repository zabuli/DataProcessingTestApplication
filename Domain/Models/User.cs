namespace Domain.Models
{
	public class User
	{
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Password { get; private set; }
    }
}