using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gomo.CC.UI.Portal.Helpers.Hangfire
{
    /// <summary>
    /// 這是sample的寫法
    /// </summary>
    public class SendMessageAlert
    {

        //public IMessageNotifyService MessageNotifyService { get; set; }
        public SendMessageAlert()
        {
            //通過容器創建一個對象
            //IApplicationContext ctx = ContextRegistry.GetContext();
            //可以使用屬性注入
            //ctx.GetObject("CacheHelper");

            //也可以直接注入
            //MessageNotifyService = ctx.GetObject("MessageNotifyService") as IMessageNotifyService;
        }
        public void SendMessage()
        {
            // TODO:發送排程信件
            System.Diagnostics.Debug.WriteLine("SendMessageAlert this is 發送:" + DateTime.Now);
            //Console.WriteLine("this is 發送:"+DateTime.Now);
            Common.LogHelper.WriteLog("SendMessageAlert this is 發送:" + DateTime.Now);
        }
    }
}
