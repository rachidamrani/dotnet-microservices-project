using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Contract for users service that contains use cases for users
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to handle user login use case and returns
    /// and AuthenticationResponse object that contains
    /// status of login
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest request);
    
    /// <summary>
    /// Method to handle user registration use case and returns
    /// and AuthenticationResponse object that represents
    /// status of user registration
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest? request);
}