using Haber.Interface;
using Haber.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haber.Bll;
using Haber.DAL.Concrete;
using Haber.Models;

namespace Haber.Service
{
    public class KategoriService : IKategoriService
    {
        private KategoriManager _kategoriManager = new KategoriManager(new EfKategoriDal());
        public void Add(KategoriModel kategori)
        {
            _kategoriManager.Add(kategori);
        }

        public void Delete(int id)
        {
            _kategoriManager.Delete(id);
        }

        public KategoriModel Get(int id)
        {
            return _kategoriManager.Get(id);
        }

        public List<KategoriModel> GetAll()
        {
            return _kategoriManager.GetAll();
        }

        public List<Kategori> GetAllEntities()
        {
            return _kategoriManager.GetAllEntities();
        }

        public KategoriModel Listing(Kategori kategori)
        {
            return _kategoriManager.Listing(kategori);
        }

        public void Update(KategoriModel kategorimodel)
        {
            _kategoriManager.Update(kategorimodel);
        }
    }
}
