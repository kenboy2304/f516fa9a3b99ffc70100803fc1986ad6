using System.Web.Mvc;

namespace CDNVN.BibleOnline.V2.Areas.BibleAdmin
{
    public class BibleAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BibleAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BibleAdmin_default",
                "BibleAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}