using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService(IUsersRepository usersRepository) : IUsersService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        ApplicationUser? user = await usersRepository.GetUserByEmailAndPassword(request.Email,
            request.Password);

        return user == null ? null : new AuthenticationResponse(user.UserId,
            user.Email,
            user.PersonName,
            user.Gender,
            "token",
            Success: true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest? request)
    {
        ApplicationUser user = new ApplicationUser
        {
            PersonName = request?.PersonName,
            Email = request?.Email,
            Gender = request?.Gender.ToString(),
            Password = request?.Password,
        };

        ApplicationUser? registeredUser = await usersRepository.AddUser(user);

        if (registeredUser == null)
        {
            return null;
        }
        
        return new AuthenticationResponse(registeredUser.UserId,
            registeredUser.Email,
            registeredUser.PersonName,
            registeredUser.Gender,
            "token",
            Success: true);
    }
}