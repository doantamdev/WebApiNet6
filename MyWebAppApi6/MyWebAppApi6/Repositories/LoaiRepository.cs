using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebAppApi6.Data;
using MyWebAppApi6.Models;

namespace MyWebAppApi6.Repositories
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public LoaiRepository(MyDbContext context,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddLoaiAsync(LoaiVM model)
        {
           var newLoai = _mapper.Map<Loai>(model);
            _context.Loais!.Add(newLoai);
            await _context.SaveChangesAsync();
            return newLoai.MaLoai;
        }

        public async Task DeleteLoaiAsync(int id)
        {
            var deleteLoai = _context.Loais!.SingleOrDefault(l => l.MaLoai == id);
            if(deleteLoai != null)
            {
                _context.Loais!.Remove(deleteLoai);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<LoaiVM>> getAllLoaisAsync()
        {
            var loais = await _context.Loais!.ToListAsync();
            return _mapper.Map<List<LoaiVM>>(loais);
        }

        public async Task<LoaiVM> getLoaiAsync(int id)
        {
            var loai = await _context.Loais!.FindAsync(id);
            return _mapper.Map<LoaiVM>(loai);
        }

        public async Task UpdateLoaiAsync(int id, LoaiVM model)
        {
            if(id == model.MaLoai)
            {
                var updateLoai = _mapper.Map<Loai>(model);
                _context.Loais!.Update(updateLoai);
                await _context.SaveChangesAsync();
            }
        }
    }
}
