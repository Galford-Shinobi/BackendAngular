using BackEnd.Shared.Domain.Models;
using System.Threading.Tasks;

namespace BackEnd.Shared.Domain.IServices
{
    public interface ILoginService
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
