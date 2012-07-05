namespace JsonNetIHtmlStringTesting.Helpers {
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Newtonsoft.Json;

    public class StandardJsonNetJsonResult : JsonResult {
        public StandardJsonNetJsonResult(object data, JsonRequestBehavior behavior) {
            Data = data;
            JsonRequestBehavior = behavior;
        }
        public StandardJsonNetJsonResult(object data) : this(data, JsonRequestBehavior.DenyGet) { }

        public override void ExecuteResult(ControllerContext controllerContext) {
            if (null == controllerContext) {
                throw new ArgumentNullException("controllerContext");
            }

            HttpResponseBase response = controllerContext.HttpContext.Response;
            if (!string.IsNullOrEmpty(ContentType)) {
                // Allows ContentType to be set elsewhere
                response.ContentType = ContentType;
            }
            else {
                response.ContentType = "application/json";
            }

            if (ContentEncoding != null) {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null) {
                string json = JsonConvert.SerializeObject(Data);
                response.Write(json);
            }
        }
    }
}