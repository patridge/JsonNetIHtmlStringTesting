namespace JsonNetIHtmlStringTesting.Controllers {
    using System.Web.Mvc;
    using JsonNetIHtmlStringTesting.Helpers;

    public class JsonSerializationController : Controller {
        private const string test = "some <span>test</span>.";
        public JsonResult Default() {
            return Json(new {
                String = test,
                IHtmlString = MvcHtmlString.Create(test),
            }, JsonRequestBehavior.AllowGet);
        }
        public StandardJsonNetJsonResult StandardJsonNet() {
            return new StandardJsonNetJsonResult(new {
                String = test,
                IHtmlString = MvcHtmlString.Create(test),
            }, JsonRequestBehavior.AllowGet);
        }
        public CustomJsonNetJsonResult CustomJsonNet() {
            return new CustomJsonNetJsonResult(new {
                String = test,
                IHtmlString = MvcHtmlString.Create(test),
            }, JsonRequestBehavior.AllowGet);
        }
    }
}