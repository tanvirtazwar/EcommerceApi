using EcommerceApi.Models.User;

namespace EcommerceApi.Services;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
