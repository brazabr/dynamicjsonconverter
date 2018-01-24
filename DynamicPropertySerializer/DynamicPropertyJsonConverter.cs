using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPropertySerializer
{
    public class DynamicPropertyJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IEnumerable<BalanceJson>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var listOfBalance = new List<BalanceJson>();

            if (reader.TokenType == JsonToken.StartObject)
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        var currencyCode = reader.Value;
                        reader.Read();
                        var balanceObject = serializer.Deserialize<BalanceJson>(reader);
                        balanceObject.currencyCode = currencyCode.ToString();
                        listOfBalance.Add(balanceObject);
                    }
                }
            }

            return listOfBalance;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
