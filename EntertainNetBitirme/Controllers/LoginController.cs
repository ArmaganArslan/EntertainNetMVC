using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EntertainNetBitirme.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminLoginManager alm = new AdminLoginManager(new EfAdminDal());

        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p) 
        {
            var adminUserInfo = alm.GetAdmin(p.adminUserName, p.adminPassword);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.adminUserName, false);
                Session["adminUserName"] = adminUserInfo.adminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p) 
        {
            var writerUserInfo = wlm.GetWriter(p.writerMail, p.writerPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.writerMail, false);
                Session["writerMail"] = writerUserInfo.writerMail;
                return RedirectToAction("MyContents", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

    }
}