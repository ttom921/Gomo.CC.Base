﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gomo.CC.IDAL;
using Gomo.CC.EFDAL;
using Gomo.CC.Model.Models;

namespace Gomo.CC.UI.Portal.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogDal _BlogDal;
        
        public BlogsController(IBlogDal blogDal)
        {
            _BlogDal = blogDal;
        }
        public IActionResult Index()
        {
            //IBlogDal.GetEntities()
            List<Blog> lst= _BlogDal.GetEntities(u => true).ToList();
            return View(lst);
        }
    }
}