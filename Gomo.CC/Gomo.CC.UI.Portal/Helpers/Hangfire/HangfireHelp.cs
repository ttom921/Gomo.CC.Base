using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gomo.CC.UI.Portal.Helpers.Hangfire
{
    //public interface IHangfireHelp
    //{

    //}
    public class HangfireHelp
    {
        #region Singleton
        //可參考http://csharpindepth.com/Articles/General/Singleton.aspx
        //目前SprintNet因ContextRegistry是應用程式起動之後才可以用，所以無法在
        //contructor內使用IOC來注入物件，所以使用 InitSpring來注入
        private static readonly Lazy<HangfireHelp> lazy =
        new Lazy<HangfireHelp>(() => new HangfireHelp());
        public static HangfireHelp Instance { get { return lazy.Value; } }
        public HangfireHelp()
        {
            //InitSpring();
        }
        #endregion Singleton
        public void ScheculdeJobStart()
        {
            //HANGFIRE延遲實作
            BackgroundJob.Schedule(() => DelayScheculdeJob(), TimeSpan.FromSeconds(60));
        }
        public void DelayScheculdeJob()
        {
            //加上timezoneinfo，才會正確
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
            //////每個月的4號，19:00執行Cron.Monthly(4, 19)
            //RecurringJob.AddOrUpdate<SendMessageAlert>("SendMessage", x => x.SendMessage(),
            // Cron.Monthly(4, 19), timeZoneInfo
            // );
            //測試
            RecurringJob.AddOrUpdate<SendMessageAlert>("SendMessage", x => x.SendMessage(),
             Cron.Minutely(), timeZoneInfo
            );
            // TODO:點數
            #region 訊息通知
            RecurringJob.RemoveIfExists("AutoPointScheculdeJob");
            //MessageHelp.Instance.ScheculdeJobStart();
            #endregion
        }
    }
}
