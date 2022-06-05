namespace Helbiz.Application.Dtos.User;

public class RegisterOutputPayload
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
}