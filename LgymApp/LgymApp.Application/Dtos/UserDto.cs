namespace LgymApp.Application.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; } 
    public string Password { get; set; }
}