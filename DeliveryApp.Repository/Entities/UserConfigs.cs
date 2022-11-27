namespace DeliveryApp.Repository.Entities;

public class UserConfigs
{
    public Guid id { get; set; }
    public int userId { get; set; }
    public string username { get; set; }
    public float weight { get; set; }
    public int height { get; set; }
    public int age { get; set; }
    public string sex { get; set; }
}