using Gomo.CC.IBLL;
using Gomo.CC.IDAL;
using Gomo.CC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomo.CC.BLL
{
    public partial class BlogService: BaseService<Blog>, IBlogService
    {
        public BlogService(IBlogDal blogdal)
            :base(blogdal)
        {

        }
    }
}
