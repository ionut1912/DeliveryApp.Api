namespace DeliveryApp.Domain.Models;

public class UserConfig
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Username { get; set; }
    public float Weight { get; set; }
    public int Height { get; set; }
    public int Age { get; set; }
    public string Sex { get; set; }
    public double NumberOfCaloriesConsumed { get; set; }
    public double NumberOfCaloriesAllowed { get; set; }
}