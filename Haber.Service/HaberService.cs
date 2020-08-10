using Haber.Interface;
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
    public class HaberService : IHaberService
    {
        private HaberManager _haberManager = new HaberManager(new EfHaberDal());
        public void Add(HaberModel haber)
        {
            _haberManager.Add(haber);
        }

        public void Delete(int id)
        {
            _haberManager.Delete(id);
        }

        public HaberModel Get(int id)
        {
            return _haberManager.Get(id);
        }

        public List<HaberModel> GetAll()
        {
            return _haberManager.GetAll();
        }

        public List<HaberModel> Listing(KategoriModel kategorimodel)
        {
            return _haberManager.Listing(kategorimodel);
        }

        public HaberModel View(HaberModel haber)
        {
            return _haberManager.View(haber);
        }
    }
}
