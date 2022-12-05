using WebApplication1.Model.Domain;

namespace WebApplication1.Repositires
{
    public interface IwalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> GetAsync(Guid id);

        Task<Walk> AddAsync(Walk walk);
        Task<Walk> DeleteAsync(Guid id);

        Task<Walk> UpdateAsync(Guid id, Walk walk);
    }
}
