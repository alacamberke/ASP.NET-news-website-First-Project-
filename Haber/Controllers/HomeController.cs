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
    public class HomeController : Controller
    {
        private IHaberService _haberService;
        private IKategoriService _kategoriService;
        private IAuthenticationService _authenticateService;
        private ICommentService _commentService;

        public HomeController(IHaberService haberService, IKategoriService kategoriService, 
            IAuthenticationService authenticateService, ICommentService commentService)
        {
            _haberService = haberService;
            _kategoriService = kategoriService;
            _authenticateService = authenticateService;
            _commentService = commentService;
        }

        public ActionResult Index(int kategoriid = 0)
        {
            if(kategoriid != 0)
            {
                var kategori = _kategoriService.Get(kategoriid);
                var haberlerk = _haberService.Listing(kategori);
                return View(haberlerk);
            }

            var haberler = _haberService.GetAll();
            return View(haberler);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            var haber = _haberService.Get(id);
            ViewBag.kategori = _kategoriService.Get(haber.KategoriId);

            var newhaber = _haberService.View(haber);

            return View(newhaber);
        }

        [HttpPost, ActionName("Details")]
        public ActionResult DetailsComment(CommentModel comment, int haberid)
        {
            comment.HaberId = haberid;
            _commentService.CommentAdd(comment);
            return RedirectToAction("Details","Home",new { id=comment.HaberId});
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.kategori = new SelectList(_kategoriService.GetAll(), "KategoriId", "KategoriName");
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(HaberModel habermodel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.kategori = new SelectList(_kategoriService.GetAll(), "KategoriId", "KategoriName", habermodel.KategoriId);

                var currentUser = _authenticateService.GetCurrentUser();
                habermodel.HaberOwner = currentUser.UserID;
                _haberService.Add(habermodel);
            }

            return RedirectToAction("Index","Home");
        }

        public ActionResult Search(string search)
        {
            var haberler = _haberService.GetAll();

            if (!String.IsNullOrEmpty(search))
            {
                haberler = haberler.Where(i => i.HaberTitle.Contains(search)).ToList();
            }

            return View(haberler);
        }

        public PartialViewResult Comments(int haberid)
        {
            var comments = _commentService.GetAllComments().Where(i => i.HaberId == haberid).ToList();
            foreach (var comment in comments)
            {
                comment.CommentOwner = _authenticateService.GetUserById(comment.CommentOwnerId).Username;
            }
            return PartialView(comments);
        }
    }
}