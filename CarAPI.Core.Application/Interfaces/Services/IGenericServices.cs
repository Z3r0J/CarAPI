using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.Interfaces.Services
{
    public interface IGenericServices<DTOCreate, DTO,Entity>
        where DTOCreate : class
        where DTO : class
        where Entity : class
    {
        Task<DTOCreate> Add(DTOCreate dto);
        Task Delete(int id);
        Task<List<DTO>> GetAll();
        Task<DTOCreate> GetById(int id);
        Task Update(DTOCreate dto, int id);
    }
}