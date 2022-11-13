using Span.Culturio.Api.Models.User;
using System.Text.Json.Nodes;

namespace Span.Culturio.Api.Services.User {
    public interface IUserService {
        Task<UsersDto> GetUsersAsync(int pageSize, int pageIndex);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> RegisterUser(RegisterUserDto registerUserDto);
        Task<TokenDto> Login(LoginDto loginUserDto);
    }
}
