using Haber.DAL.Abstract.EntityFramework;
using Haber.Entities;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.DAL.Concrete
{
    public class EfKategoriDal : IKategoriDal
    {
        HaberContext context = new HaberContext();
        public void Add(KategoriModel kategori)
        {
            Kategori entity = new Kategori();
            entity.KategoriName = kategori.KategoriName;
            entity.Haberler = new List<Entities.Haber>();
            context.Kategoriler.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var kategori = context.Kategoriler.Find(id);
            context.Kategoriler.Remove(kategori);
            context.SaveChanges();
        }

        public KategoriModel Get(int id)
        {
            var kategori = context.Kategoriler.Find(id);
            var model = new KategoriModel();
            model.KategoriId = kategori.KategoriID;
            model.KategoriName = kategori.KategoriName;
            model.Haberler = kategori.Haberler;
            return model;
        }

        public List<KategoriModel> GetAll()
        {
            return context.Kategoriler.Select(i => new KategoriModel
            {
                KategoriName = i.KategoriName,
                Haberler = i.Haberler,
                KategoriId = i.KategoriID
                
            }).ToList();
        }

        public List<Kategori> GetAllEntities()
        {
            return context.Kategoriler.ToList();
        }

        public KategoriModel Listing(Kategori kategori)
        {
            var model = new KategoriModel();
            model.KategoriName = kategori.KategoriName;
            return model;
        }

        public void Update(KategoriModel kategorimodel)
        {
            var entity = context.Kategoriler.Find(kategorimodel.KategoriId);
            entity.KategoriName = kategorimodel.KategoriName;
            context.SaveChanges();
        }
    }
}
