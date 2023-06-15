using BackEnd.Shared.Domain.IRepositories;
using BackEnd.Shared.Domain.IServices;
using BackEnd.Shared.Domain.Models;
using System.Threading.Tasks;

namespace BackEnd.Shared.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }
    }
}
