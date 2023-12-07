using MyWebAppApi6.Models;

namespace MyWebAppApi6.Repositories
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1);

    }
}
