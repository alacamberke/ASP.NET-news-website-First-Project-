using Haber.DAL.Abstract.EntityFramework;
using Haber.Interface;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Bll
{
    public class HaberManager : IHaberService
    {
        private IHaberDal _haberDal;
        public HaberManager(IHaberDal haberDal)
        {
            _haberDal = haberDal;
        }
        public void Add(HaberModel haber)
        {
            _haberDal.Add(haber);
        }

        public void Delete(int id)
        {
            _haberDal.Delete(id);
        }

        public HaberModel Get(int id)
        {
            return _haberDal.Get(id);
        }

        public List<HaberModel> GetAll()
        {
            return _haberDal.GetAll();
        }

        public List<HaberModel> Listing(KategoriModel kategorimodel)
        {
            return _haberDal.Listing(kategorimodel);
        }

        public HaberModel View(HaberModel haber)
        {
            return _haberDal.View(haber);
        }
    }
}
