##Default .NET JavaScript serialization

    // Controller action method
    public JsonResult Default() {
        return Json(new {
            String = test,
            IHtmlString = MvcHtmlString.Create(test),
        }, JsonRequestBehavior.AllowGet);
    }

    // JSON output
    {
        "String": "some <span>test</span>.",
        "IHtmlString": {}
    }

##Default Json.NET serialization

    // Controller action method
    public StandardJsonNetJsonResult StandardJsonNet() {
        return new StandardJsonNetJsonResult(new {
            String = test,
            IHtmlString = MvcHtmlString.Create(test),
        }, JsonRequestBehavior.AllowGet);
    }

    // JSON output
    {
        "String": "some <span>test</span>.",
        "IHtmlString": {}
    }

##Custom Json.NET serialization (with IHtmlStringConverter)

    // Custom JsonConverter method
    public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
        IHtmlString source = value as IHtmlString;
        if (source == null) {
            return;
        }

        writer.WriteValue(source.ToString());
    }

    // Controller action method
    public CustomJsonNetJsonResult CustomJsonNet() {
        return new CustomJsonNetJsonResult(new {
            String = test,
            IHtmlString = MvcHtmlString.Create(test),
        }, JsonRequestBehavior.AllowGet);
    }

    // JSON output
    {
        "String": "some <span>test</span>.",
        "IHtmlString": "some <span>test</span>."
    }