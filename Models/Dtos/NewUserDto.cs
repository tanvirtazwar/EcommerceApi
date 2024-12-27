namespace EcommerceApi.Models.Dtos;

public class NewUserDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
}
