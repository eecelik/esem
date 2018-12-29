using Business;
using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        [HttpGet]
        public ActionResult Index(string username)
        {
            IConversationService conversationService = IocUtil.Resolve<IConversationService>();
            IAccountService accountService = IocUtil.Resolve<IAccountService>();

            Account fromAccount = accountService.Get(Session["kullaniciAdi"].ToString());
            Account toAccount = accountService.Get(username);

            List<Message> messages = conversationService.GetMessages(fromAccount.Id, toAccount.Id);

            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string text)
        {
            IConversationService conversationService = IocUtil.Resolve<IConversationService>();
            IAccountService accountService = IocUtil.Resolve<IAccountService>();

            Account fromAccount = accountService.Get(Session["kullaniciAdi"].ToString());
            Account toAccount = accountService.Get(username);

            conversationService.SendMessage(fromAccount.Id, toAccount.Id, text);

            return RedirectToAction("Index/" + username, "Messages");
        }
    }
}