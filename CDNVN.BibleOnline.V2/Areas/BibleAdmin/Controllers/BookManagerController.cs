using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using CDNVN.BibleOnline.V2.Data.Entities;

namespace CDNVN.BibleOnline.V2.Areas.BibleAdmin.Controllers
{
    public class BookManagerController : Controller
    {
        private BibleContext db;
        // GET: Admin/BookManager
        public ActionResult Index(string version ="BTT")
        {
            var listS = (from ConnectionStringSettings c in ConfigurationManager.ConnectionStrings select c.Name).ToList();
            var selectList = new SelectList(listS,version);
            ViewBag.Versions = selectList;
            ViewBag.Version = version;
            db = new BibleContext(version);
            return View(db.Books.OrderBy(b=>b.Order));
        }
        public ActionResult Create(string version = "BTT")
        {
            db = new BibleContext(version);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book,string version = "BTT")
        {
            if (ModelState.IsValid)
            {
                db = new BibleContext(version);
                book.UrlKeyword = Data.Translation.ConvertToUnsign3(book.Name);
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index", new {version = version});
            }
            return View(book);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}