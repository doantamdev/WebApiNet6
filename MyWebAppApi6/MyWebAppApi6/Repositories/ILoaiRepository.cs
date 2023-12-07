using MyWebAppApi6.Data;
using MyWebAppApi6.Models;

namespace MyWebAppApi6.Repositories
{
    public interface ILoaiRepository
    {
        public Task<List<LoaiVM>> getAllLoaisAsync();
        public Task<LoaiVM> getLoaiAsync(int id);
        public Task<int> AddLoaiAsync(LoaiVM model);
        public Task UpdateLoaiAsync(int id, LoaiVM model);
        public Task DeleteLoaiAsync(int id);
    }
}
