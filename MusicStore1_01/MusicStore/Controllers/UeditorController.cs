using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class UeditorController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: Ueditor
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Guid id, string cmt, string Replys)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            //查出出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //评论对象
            var reply = new Reply()
            {
                Album = _context.Albums.Find(id),
                Person = _context.Persons.Find(person.ID),
                Content = cmt,
            };
            //父级回复
            if (string.IsNullOrEmpty(Replys))
            {
                //顶级回复
                reply.ParentReply = null;
            }
            else
            {
                reply.ParentReply = _context.Reply.Find(Guid.Parse(Replys));
            }

            _context.Reply.Add(reply);
            _context.SaveChanges();

            var Albums = _context.Albums.SingleOrDefault(x => x.ID == id);

            var HtmlString = "";
            foreach (var item in Albums.Reply.OrderByDescending(x => x.ReplyTime))
            {
                var sonCmt = _context.Reply.Where(x => x.ParentReply.ID == item.ID).ToList().Count;
                ViewBag.count = sonCmt;
                HtmlString += " <div class=\"Music-Reply\">";
                HtmlString += " <img src = " + item.Person.Avarda + " alt = 加载失败 />";
                HtmlString += "<p id='Content-" + item.ID + "'> <span> " + item.Person.Name + "：</ span >" + item.Content + " </p>";
                HtmlString += " <div class=\"Reply-time\"> <a href=\"#container\" onclick=\"javascript:GetQuote('" + item.ID + "','" + item.ID + "')\">回复</a> <a href='#'onclick=\"javascript: ShowCmt('" + item.ID + "');\">(" + sonCmt + ")</a>";
                HtmlString += " | <a onclick=\"javascript:Like('" + item.ID + "')\";><i class=\"glyphicon glyphicon-thumbs-up\">（" + item.Like + "）</i></a> ";
                HtmlString += "| <a  onclick=\"javascript:Hate('" + item.ID + "')\";><i class=\"glyphicon glyphicon-thumbs-down\">（" + item.Hate + "）</i></a>";
                HtmlString += " | 发表时间：" + item.ReplyTime + "</div>";
                HtmlString += " </div>";
            }

            // return Json(reply, JsonRequestBehavior.AllowGet);
            return Json(HtmlString);
        }
        [HttpPost]
        public ActionResult FIndex(Guid id)
        {
            var Albums = _context.Albums.SingleOrDefault(x => x.ID == id);

            var HtmlString = "";
            foreach (var item in Albums.Reply.OrderByDescending(x => x.ReplyTime))
            {
                var sonCmt = _context.Reply.Where(x => x.ParentReply.ID == item.ID).ToList().Count;
                ViewBag.count = sonCmt;
                HtmlString += " <div class=\"Music-Reply\">";
                HtmlString += " <img src = " + item.Person.Avarda + " alt = 加载失败 />";
                HtmlString += "<p id='Content-" + item.ID + "'> <span> " + item.Person.Name + "：</ span >" + item.Content + " </p>";
                HtmlString += " <div class=\"Reply-time\"> <a href=\"#container\" onclick=\"javascript:GetQuote('" + item.ID + "','" + item.ID + "')\">回复</a> <a href='#'onclick=\"javascript: ShowCmt('" + item.ID + "');\">(" + sonCmt + ")</a>";
                HtmlString += " | <a onclick=\"javascript:Like('" + item.ID + "')\";><i class=\"glyphicon glyphicon-thumbs-up\">（" + item.Like + "）</i></a> ";
                HtmlString += "| <a onclick=\"javascript:Hate('" + item.ID + "')\";><i class=\"glyphicon glyphicon-thumbs-down\">（" + item.Hate + "）</i></a>";
                HtmlString += " | 发表时间：" + item.ReplyTime + "</div>";
                HtmlString += " </div>";

            }
            if (Albums.Reply.Count == 0)
            {
                HtmlString += "<div class=\"Reply-null\"> 暂无评论内容 </div>";
            }
            return Json(HtmlString);
        }
    }
}