using Haber.DAL.Abstract.EntityFramework;
using Haber.DAL.Concrete;
using Haber.Entities;
using Haber.Interface;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Bll
{
    public class KategoriManager : IKategoriService
    {
        private IKategoriDal _kategoriDal;
        public KategoriManager(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;
        }

        public void Add(KategoriModel kategori)
        {
            _kategoriDal.Add(kategori);
        }

        public void Delete(int id)
        {
            _kategoriDal.Delete(id);
        }

        public KategoriModel Get(int id)
        {
            return _kategoriDal.Get(id);
        }

        public List<KategoriModel> GetAll()
        {
            return _kategoriDal.GetAll();
        }

        public List<Kategori> GetAllEntities()
        {
            return _kategoriDal.GetAllEntities();
        }

        public KategoriModel Listing(Kategori kategori)
        {
            return _kategoriDal.Listing(kategori);
        }

        public void Update(KategoriModel kategorimodel)
        {
            _kategoriDal.Update(kategorimodel);
        }
    }
}
