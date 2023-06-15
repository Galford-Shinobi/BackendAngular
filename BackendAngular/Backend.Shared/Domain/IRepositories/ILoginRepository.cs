using BackEnd.Shared.Domain.Models;
using System.Threading.Tasks;

namespace BackEnd.Shared.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
