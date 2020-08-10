using Haber.Interface;
using Haber.Models;
using Haber.MyFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haber.Controllers
{
    [Action]
    public class KategoriController : Controller
    {
        private IKategoriService _kategoriService;
        private IHaberService _haberService;
        public KategoriController(IKategoriService kategoriService, IHaberService haberService)
        {
            _kategoriService = kategoriService;
            _haberService = haberService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var kategoriler = _kategoriService.GetAll();
            return View(kategoriler);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(KategoriModel kategorimodel)
        {
            if (ModelState.IsValid)
            {
                _kategoriService.Add(kategorimodel);
            }
            return RedirectToAction("Index","Kategori");
        }

        public PartialViewResult Kategoriler()
        {
            var kategoriler = _kategoriService.GetAll();
            return PartialView(kategoriler);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var kategori = _kategoriService.Get(id);
            return View(kategori);
        }

        [HttpPost]
        public ActionResult Details(KategoriModel kategorimodel)
        {
            _kategoriService.Update(kategorimodel);
            return RedirectToAction("Index","Kategori");
        }

        public ActionResult Delete(int id)
        {
            var kategori = _kategoriService.Get(id);
            return View(kategori);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            var haberler = _haberService.GetAll().Where(i => i.KategoriId == id).ToList();
            _kategoriService.Delete(id);
            return RedirectToAction("Index","Kategori");
        }
    }
}