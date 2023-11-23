using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ADPProject.DataTests.Converters;

public class NullableIntArrayConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JToken token = JToken.Load(reader);
        
        if (token.Type == JTokenType.Array && objectType == typeof(int[]))
        {
            var array = token.ToObject<int?[]>();

            var newArray = new int[array.Length];

            for (int i = 0; i < array.Length; i ++)
            {
                newArray[i] = array[i] ?? (int)0;
            }

            return newArray;
        }
        
        throw new JsonSerializationException("Unexpected token type: " + 
                                             token.Type.ToString());
    }

    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(Nullable<int>[]));
    }
}