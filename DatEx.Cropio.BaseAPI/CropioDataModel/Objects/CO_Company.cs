using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [Obsolete("Не удалось подобрать соответствие названию таблицы БД (ошибка 400)")]
    [JsonObject(Title = "data")]
    public class CO_Company : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of Company </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary>  </summary>
        [Obsolete("Undefined in oficial API documentation")]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>  </summary>
        [Obsolete("Undefined in oficial API documentation")]
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> name of company </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> country code (ISO 2-letter) </summary>
        [JsonProperty("country")]
        public String Country { get; set; }

        /// <summary> limit of area, ha. </summary>
        [JsonProperty("area_limit")]
        public Single AreaLimit { get; set; }
        
        /// <summary> tenant name </summary>
        [JsonProperty("tenant")]
        public String Tenant { get; set; }

        /// <summary> links to logo images </summary>
        [JsonProperty("logo")]
        public String Logo { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:          ").Append(Id)
                .Append(i).Append("CreatedAt:   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:   ").Append(UpdatedAt)
                .Append(i).Append("Name:        ").Append(Name)
                .Append(i).Append("Country:     ").Append(Country)
                .Append(i).Append("AreaLimit:   ").Append(AreaLimit)
                .Append(i).Append("Tenant:      ").Append(Tenant)
                .Append(i).Append("Logo:        ").Append(Logo);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
