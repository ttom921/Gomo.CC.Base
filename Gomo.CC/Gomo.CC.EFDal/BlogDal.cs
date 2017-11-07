using Gomo.CC.EFDal;
using Gomo.CC.IDAL;
using Gomo.CC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomo.CC.EFDAL
{
    public partial class BlogDal:BaseDal<Blog>, IBlogDal
    {
        public BlogDal(BloggingContext context)
            :base(context)
        {

        }
    }
}
