using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: Store

        public ActionResult Detail(Guid id)
        {

            if ((Session["LoginUserSessionModel"] as LoginUserSessionModel) == null)
            {
                ViewBag.img = "/Content/images/boys.jpg";
                ViewBag.name = "<a href='../../Account/login'> 请登录 </a>";
            }
            else
            {
                ViewBag.img = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.Avarda;
                ViewBag.name = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.Name;
            }

            var Albums = _context.Albums.SingleOrDefault(x => x.ID == id);

            return View(Albums);
        }

        public ActionResult ShowCmt(string pid)
        {

            var htmlString = "";
            //子回复
            Guid id = Guid.Parse(pid);
            var cmts = _context.Reply.Where(x => x.ParentReply.ID == id).OrderByDescending(x => x.CreateDateTime).ToList();
            //原回复
            var pcmt = _context.Reply.Find(id);
            htmlString += "<div class=\"modal-header\">";
            htmlString += "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">×</button>";
            htmlString += "<h4 class=\"modal-title\" id=\"myModalLabel\">";
            htmlString += "<em>楼主&nbsp;&nbsp;</em>" + pcmt.Person.Name + "&nbsp;&nbsp;发表于" + pcmt.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + ":<br/>" + pcmt.Content;
            htmlString += " </h4> </div>";

            htmlString += "<div class=\"modal-body\">";
            //子回复
            htmlString += "<ul class='media-list' style='margin-left:20px;'>";
            foreach (var item in cmts)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='" + item.Person.Avarda +
                              "' alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body' id='Content-" + item.ID + "'>";
                htmlString += "<h5 class='media-heading'><em>" + item.Person.Name + "</em>&nbsp;&nbsp;发表于" +
                              item.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";
                htmlString += "<h6><a href='#div-editor' class='reply' onclick=\"javascript:GetQuote('" + item.ParentReply.ID + "','" + item.ID + "');\">回复</a>" +
                              "<a class='reply' style='margin:0 20px 0 40px'   onclick=\"javascript:Like('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-up'></i>(" + item.Like + ")</a>" +
                              "<a class='reply' style='margin:0 20px'   onclick=\"javascript:Hate('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></h6>";
                htmlString += "</li>";
            }
            htmlString += "</ul>";
            htmlString += "</div><div class=\"modal-footer\"></div>";
            return Json(htmlString);
        }

        /// <summary>
        /// 按分类显示专辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x => x.Genre.ID == id)
                .OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id">回复id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Like(Guid id, bool Isnot, Guid mid)
        {
            //1.判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            //2.判断用户是否对这条回复点过赞或踩
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var like = _context.LikeReply.SingleOrDefault(x => x.Person.ID == person.ID && x.Reply.ID == id);
            if (like == null)
            {
                //3.保存  reply实体中like+1或hate+1  LikeReply添加一条记录
                var reply = _context.Reply.SingleOrDefault(x => x.ID == id);
                if (Isnot) { reply.Like += 1; }
                else { reply.Hate += 1; }
                like = new LikeReply()
                {
                    IsNotLike = Isnot,
                    Person = _context.Persons.Find(person.ID),
                    Reply = reply
                };
                _context.LikeReply.Add(like);
                _context.SaveChanges();
            }

            var HtmlString = "";
            var Albums = _context.Albums.SingleOrDefault(x => x.ID == mid);

            foreach (var item in Albums.Reply.OrderByDescending(x => x.ReplyTime))
            {
                var sonCmt = _context.Reply.Where(x => x.ParentReply.ID == item.ID).ToList().Count;
                ViewBag.count = sonCmt;
                HtmlString += " <div class=\"Music-Reply\">";
                HtmlString += " <img src = " + item.Person.Avarda + " alt = 加载失败 />";
                HtmlString += "<p id='Content-" + item.ID + "'> <span> " + item.Person.Name + "：</ span >" + item.Content + " </p>";
                HtmlString += " <div class=\"Reply-time\"> <a href=\"#container\" onclick=\"javascript:GetQuote('" + item.ID + "','" + item.ID + "')\">回复</a> <a href='#'onclick=\"javascript: ShowCmt('" + item.ID + "');\">(" + sonCmt + ")</a>";
                HtmlString += " | <a  onclick=\"javascript:Like('" + item.ID + "')\";><i class=\"glyphicon glyphicon-thumbs-up\">（" + item.Like + "）</i></a> ";
                HtmlString += "| <a onclick=\"javascript:Hate('" + item.ID + "')\";><i class=\"glyphicon glyphicon-thumbs-down\">（" + item.Hate + "）</i></a>";
                HtmlString += " | 发表时间：" + item.ReplyTime + "</div>";
                HtmlString += " </div>";
            }
            //生成html 注入视图

            return Json(HtmlString);
        }

    }
}