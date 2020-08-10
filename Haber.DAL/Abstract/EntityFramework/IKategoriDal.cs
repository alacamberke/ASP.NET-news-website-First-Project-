using Haber.Entities;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.DAL.Abstract.EntityFramework
{
    public interface IKategoriDal
    {
        List<KategoriModel> GetAll();
        List<Kategori> GetAllEntities();
        KategoriModel Get(int id);
        void Add(KategoriModel kategori);
        void Delete(int id);
        KategoriModel Listing(Kategori kategori);
        void Update(KategoriModel kategorimodel);
    }
}
