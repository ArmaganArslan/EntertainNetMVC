using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntertainNetBitirme.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        CategoryManager ctm = new CategoryManager(new EfCategoryDal());

        public ActionResult MyContents(string p)
        {
            Context c = new Context();
            p = (string)Session["writerMail"];
            var writerIdInfo = c.Writers.Where(x=>x.writerMail == p).Select(y=> y.writerId).FirstOrDefault();
            var contentValues = cm.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent() 
        {
            List<SelectListItem> valueCategory = (from x in ctm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.categoryName,
                                                      Value = x.categoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> valueHeading = (from x in hm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.headingName,
                                                      Value = x.headingId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlh = valueHeading;

            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p) 
        {
            Context c = new Context();
            string mail = (string)Session["writerMail"];
            var writerIdInfo = c.Writers.Where(x => x.writerMail == mail).Select(y => y.writerId).FirstOrDefault();
            p.contentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.writerId = writerIdInfo;
            p.contentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContents");
        }
    }
}