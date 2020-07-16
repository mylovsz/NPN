using System.Web.Mvc;

namespace LumluxSY.Areas.Lamp
{
    public class LampAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Lamp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Lamp_default",
                "Lamp/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
