using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;

namespace VectorGraphicViewer.Library.Helper
{
    public class ShapeReader : Newtonsoft.Json.Converters.CustomCreationConverter<Shape>
    {
        public override Shape Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public Shape Create(Type objectType, JObject jObject)
        {
            foreach (var property in jObject)
            {
                if (property.Key == "type")
                {
                    switch (property.Value.ToString())
                    {
                        case "line":
                            return new Line();
                        case "circle":
                            return new Circle();
                        case "triangle":
                            return new Triangle();
                        default:
                            throw new ApplicationException(string.Format("The shape type {0} is not supported!", property.ToString()));
                    }
                }
                
            }
            throw new Exception("Invalid Json Format");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        { 
            JObject jObject = JObject.Load(reader);
            var target = Create(objectType, jObject);
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

    }
}
