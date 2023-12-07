using Microsoft.EntityFrameworkCore;
using MyWebAppApi6.Data;
using MyWebAppApi6.Models;

namespace MyWebAppApi6.Repositories
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly MyDbContext _context;
        public static int PAGE_Size { get; set; } = 5;

        public HangHoaRepository(MyDbContext context) 
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            var allProducts = _context.HangHoas!.Include(hh => hh.Loai).AsQueryable();
            #region Filtering
            if (!string.IsNullOrEmpty(search))
            { 
               allProducts=allProducts.Where(hh => hh.TenHh!.Contains(search));
            }
            if(from.HasValue)
            {
                allProducts =allProducts.Where(hh => hh.DonGia >= from);
            }
            if(to.HasValue)
            {
                allProducts =allProducts.Where(hh => hh.DonGia <= to);
            }
            #endregion

            #region Sorting
            //Default sort by TenHh
            allProducts = allProducts.OrderBy(hh => hh.TenHh);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "tenhh_desc": allProducts = allProducts.OrderByDescending
                            (hh => hh.TenHh); break;
                    case "gia_asc":
                        allProducts = allProducts.OrderBy
                        (hh => hh.DonGia); break;
                    case "gia_desc":
                        allProducts = allProducts.OrderByDescending
                        (hh => hh.DonGia); break;
                }
            }
            #endregion
            //#region Paging
            //allProducts = allProducts.Skip((page -1) * PAGE_Size).Take(PAGE_Size);
            //#endregion
            //var result = allProducts.Select(hh => new HangHoaModel
            //{
            //    MaHangHoa = hh.MaHh,
            //    TenHangHoa = hh.TenHh,
            //    DonGia = hh.DonGia,
            //    TenLoai = hh.Loai!.TenLoai
            //});
            //return result.ToList();

            var result = PagniatedList<HangHoaData>.Create(allProducts, page, PAGE_Size);
            return result.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai?.TenLoai
            }).ToList();

        }
    }
}
