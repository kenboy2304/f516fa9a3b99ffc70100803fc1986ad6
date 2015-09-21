using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CDNVN.BibleOnline.V2.Data.Entities;

namespace CDNVN.BibleOnline.V2.Controllers
{
    public class ReadController : Controller
    {
        private BibleContext db;
        // GET: Read
        public ActionResult Index(string book, int fromChapter = 0, int fromVerse = 0, int toChapter = 0, int toVerse = 0, string v = "BTT")
        {
            db = new BibleContext(v);
            var bookId = db.Books.SingleOrDefault(b => b.Id.Equals(book) || b.UrlKeyword.Equals(book) || b.Name.Equals(book));
            if (bookId == default(Book)) return HttpNotFound();
            var data = new List<Verse>();
            string address = "";
            //ma-thi-o 1
            if (fromChapter > 0 && fromVerse == 0 && toChapter == 0 && toVerse == 0)
            {
                data = db.Verses.Where(ve => ve.BookId.Equals(bookId.Id) && ve.Chapter.Equals(fromChapter))
                    .OrderBy(ve => ve.Id).ToList();
                address = string.Format("{0} {1}", bookId.Name, fromChapter);
            }
            //ma-thi-o 1:1
            if (fromChapter > 0 && fromVerse > 0 && toChapter == 0 && toVerse == 0)
            {
                data.Add(db.Verses.Find(bookId.Id, fromChapter, fromVerse));
                address = string.Format("{0} {1}.{2}", bookId.Name, fromChapter, fromVerse);
                
            }
            //ma-thi-o 1:1-2
            if (fromChapter > 0 && fromVerse > 0 && toChapter == 0 && toVerse > 0 && fromVerse <=toVerse && fromVerse <= toVerse)
            {
                data = db.Verses.Where(ve => ve.BookId.Equals(bookId.Id) && ve.Chapter==fromChapter && ve.Id>=fromVerse && ve.Id<=toVerse ).ToList();
                address = string.Format("{0} {1}:{2}-{3}", bookId.Name, fromChapter, fromVerse, toVerse);

            }
            //ma-thi-o 1-2
            if (fromChapter > 0 && fromVerse == 0 && toChapter > 0 && toVerse == 0 && fromChapter < toChapter )
            {
                data = db.Verses.Where(ve => ve.BookId.Equals(bookId.Id) && ve.Chapter >= fromChapter && ve.Chapter <= toChapter).ToList();
                address = string.Format("{0} {1}-{2}", bookId.Name, fromChapter, toChapter);
            }
            //ma-thi-o 1-2:5
            if (fromChapter > 0 && fromVerse == 0 && toChapter > 0 && toVerse > 0 && fromChapter < toChapter )
            {
                data = db.Verses.Where(ve => ve.BookId.Equals(bookId.Id) && 
                    ((ve.Chapter >= fromChapter && ve.Chapter < toChapter) ||(ve.Chapter == toChapter && ve.Id <= toVerse))
                    ).ToList();
                address = string.Format("{0} {1}-{2}:{3}", bookId.Name, fromChapter, toChapter, toVerse);
            }
            //ma-thi-o 1:1-2:2
            if (fromChapter > 0 && fromVerse > 0 && toChapter > 0 && toVerse > 0 && fromChapter < toChapter)
            {
                data = db.Verses.Where(ve => ve.BookId.Equals(bookId.Id) && (
                                          (ve.Chapter== fromChapter && ve.Id >=fromVerse) ||
                                          (ve.Chapter > fromChapter && ve.Chapter < toChapter) ||
                                          (ve.Chapter == toChapter && ve.Id <= toVerse)
                                          )
                            ).ToList();
                address = string.Format("{0} {1}:{2}-{3}:{4}", bookId.Name, fromChapter, fromVerse, toChapter, toVerse);
            }
            ViewBag.Address = address;
            return View(data);
            //return HttpNotFound();
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