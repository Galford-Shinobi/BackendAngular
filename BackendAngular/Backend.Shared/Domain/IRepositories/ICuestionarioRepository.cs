using BackEnd.Shared.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Sahred.Domain.IRepositories
{
    public interface ICuestionarioRepository
    {
        Task CreateCuestionario(Cuestionario cuestionario);
        Task<List<Cuestionario>> GetListCuestionarioByUser(int idUsuario);
        Task<Cuestionario> GetCuestionario(int idCuestionario);
        Task<Cuestionario> BuscarCuestionario(int idCuestionario, int idUsuario);
        Task EliminarCuestionario(Cuestionario cuestionario);
        Task<List<Cuestionario>> GetListCuestionarios();
    }
}
