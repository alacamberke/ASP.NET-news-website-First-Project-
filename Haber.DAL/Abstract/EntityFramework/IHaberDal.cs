using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haber.Entities;
using Haber.Models;

namespace Haber.DAL.Abstract.EntityFramework
{
    public interface IHaberDal
    {
        List<HaberModel> GetAll();
        HaberModel Get(int id);
        void Add(HaberModel haber);
        void Delete(int id);
        List<HaberModel> Listing(KategoriModel kategorimodel);
        HaberModel View(HaberModel haber);

    }
}
