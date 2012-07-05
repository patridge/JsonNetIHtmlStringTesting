namespace JsonNetIHtmlStringTesting.Helpers {
    using System;
    using System.Web;

    /// <summary>
    /// Allows JSON serialization of Expando objects into expected results (e.g., "x: 1, y: 2") instead of the default dictionary serialization.
    /// </summary>
    public class IHtmlStringConverter : Newtonsoft.Json.JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(IHtmlString).IsAssignableFrom(objectType);
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
            IHtmlString source = value as IHtmlString;
            if (source == null) {
                return;
            }

            writer.WriteValue(source.ToString());
        }
    }
}