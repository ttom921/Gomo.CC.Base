using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gomo.CC.IDAL;
using Gomo.CC.EFDAL;
using Gomo.CC.Model.Models;
using Gomo.CC.IBLL;

namespace Gomo.CC.UI.Portal.Controllers
{
    public class BlogsController : Controller
    {
        #region 使用dal
        //private readonly IBlogDal _BlogDal;

        //public BlogsController(IBlogDal blogDal)
        //{
        //    _BlogDal = blogDal;
        //}
        //public IActionResult Index()
        //{
        //    //IBlogDal.GetEntities()
        //    List<Blog> lst = _BlogDal.GetEntities(u => true).ToList();
        //    return View(lst);
        //}
        #endregion
        private readonly IBlogService _BlogService;

        public BlogsController(IBlogService blogService)
        {
            _BlogService = blogService;
        }
        public IActionResult Index()
        {
            List<Blog> lst = _BlogService.GetEntities(u => true).ToList();
            return View(lst);
        }

    }
}