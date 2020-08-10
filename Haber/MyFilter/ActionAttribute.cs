using Haber.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Haber.MyFilter
{
    internal class ActionAttribute : ActionFilterAttribute
    {
        //Actiondan önceki log işlemi (Executing).
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sb = new StringBuilder();

            foreach (var parameter in filterContext.ActionParameters)
            {
                sb.Append($"{parameter.Key} = {parameter.Value}");
            }

            using (HaberContext context = new HaberContext())
            {
                Log log = new Log();
                log.IsBefore = true;
                log.LogCaption = $"{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName} - " +
                    $"{filterContext.ActionDescriptor.ActionName}";

                if(HttpContext.Current.User.Identity.Name != null)
                {
                    log.Username = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    log.Username = "Guest";
                }

                if(sb != null)
                {
                    log.LogDetails = sb.ToString();
                }

                log.LogDetails = "Parameterless";
                log.Date = DateTime.Now;

                context.Loglar.Add(log);
                context.SaveChanges();
            }
            base.OnActionExecuting(filterContext);
        }

        //Actiondan sonraki log işlemi (Executed).
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            using (HaberContext context = new HaberContext())
            {
                Log log = new Log();
                log.IsBefore = false;
                log.LogCaption = $"{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName} - " +
                    $"{filterContext.ActionDescriptor.ActionName}";

                if (HttpContext.Current.User.Identity.Name != null)
                {
                    log.Username = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    log.Username = "Guest";
                }

                log.LogDetails = "Quit";
                log.Date = DateTime.Now;

                context.Loglar.Add(log);
                context.SaveChanges();
            }

            base.OnActionExecuted(filterContext);
        }
    }
}