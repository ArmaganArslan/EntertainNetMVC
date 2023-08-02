using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntertainNetBitirme.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        WriterManager wm = new WriterManager(new EfWriterDal());

        WriterValidator writerValidator = new WriterValidator();

        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["writerMail"];
            id = c.Writers.Where(x => x.writerMail == p).Select(y => y.writerId).FirstOrDefault();
            var writerValue = wm.GetById(id);
            ViewBag.a = id;
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("MyHeadings");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeadings(string p) 
        {
            p = (string)Session["writerMail"];
            var writerIdInfo = c.Writers.Where(x => x.writerMail == p).Select(y => y.writerId).FirstOrDefault();
            var values = hm.GetListByWriter(writerIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.categoryName,
                                                      Value = x.categoryId.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p) 
        {
            string mail = (string)Session["writerMail"];
            var writerIdInfo = c.Writers.Where(x => x.writerMail == mail).Select(y => y.writerId).FirstOrDefault();
            p.headingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.writerId = writerIdInfo;
            p.headingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeadings");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.categoryName,
                                                      Value = x.categoryId.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;

            var headingValue = hm.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            p.headingStatus = true;
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeadings");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.headingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeadings");
        }
    }
}