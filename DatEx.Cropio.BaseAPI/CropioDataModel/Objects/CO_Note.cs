using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Note : ICropioRegularObject
    {
        //Not tested

        /// <summary>  </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary>  </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>  </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("notable_id")]
        public Int32 Id_Notable { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("notable_type")]
        public String NotableType { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("user_id")]
        public Int32 Id_User { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("title")]
        public String Title { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("description")]
        public String Description { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("photo1")]
        [JsonConverter(typeof(JsonPhotoConverter))]
        public Photo Photo1 { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("photo2")]
        [JsonConverter(typeof(JsonPhotoConverter))]
        public Photo Photo2 { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("photo3")]
        [JsonConverter(typeof(JsonPhotoConverter))]
        public Photo Photo3 { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("photo1_md5")]
        public Object Photo1Md5 { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("photo2_md5")]
        public Object Photo2Md5 { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("photo3_md5")]
        public Object Photo3Md5 { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("created_by_user_at")]
        public DateTime CreatedByUserAt { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("updated_by_user_at")]
        public DateTime UpdatedByUserAt { get; set; }
        
        
        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:       ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Id_Notable:      ").Append(Id_Notable)
                .Append(i).Append("NotableType:     ").Append(NotableType)
                .Append(i).Append("Id_User:         ").Append(Id_User)
                .Append(i).Append("Title:           ").Append(Title)
                .Append(i).Append("Description:     ").Append(Description)
                .Append(i).Append("Photo1:          ").Append(Photo1.ToString(indentLevel + 1))
                .Append(i).Append("Photo2:          ").Append(Photo2.ToString(indentLevel + 1))
                .Append(i).Append("Photo3:          ").Append(Photo3.ToString(indentLevel + 1))
                .Append(i).Append("Photo1Md5:       ").Append(Photo1Md5)
                .Append(i).Append("Photo2Md5:       ").Append(Photo2Md5)
                .Append(i).Append("Photo3Md5:       ").Append(Photo3Md5)
                .Append(i).Append("CreatedByUserAt: ").Append(CreatedByUserAt)
                .Append(i).Append("UpdatedByUserAt: ").Append(UpdatedByUserAt);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }

    [JsonConverter(typeof(JsonPhotoConverter))]
    public class Photo
    {
        public String Url { get; set; }
        public String Preview_200 { get; set; }
        public String Preview_400 { get; set; }
        public String Preview_1000 { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Url:             ").Append(Url)
                .Append(i).Append("Preview_200:     ").Append(Preview_200)
                .Append(i).Append("Preview_400:     ").Append(Preview_400)
                .Append(i).Append("Preview_1000:    ").Append(Preview_1000);
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    public class JsonPhotoConverter : JsonConverter
    {
        public override Boolean CanConvert(Type objectType)
        {
            return objectType == typeof(Photo);
        }

        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null) return String.Empty;

            JObject obj = JObject.Load(reader);
            var childrens = obj.Children().FirstOrDefault();
            var objRoot = childrens.First;

            return new Photo()
            {
                Url = (string)objRoot["url"],
                Preview_200 = (string)objRoot["preview_200"]["url"],
                Preview_400 = (string)objRoot["preview_400"]["url"],
                Preview_1000 = (string)objRoot["preview_1000"]["url"],
            };
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
