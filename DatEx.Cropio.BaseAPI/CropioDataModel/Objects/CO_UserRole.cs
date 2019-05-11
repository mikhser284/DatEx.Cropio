using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "user_roles")]
    public class CO_UserRole : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of UserRole </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> name of UserRole </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> description of UserRole </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:          ").Append(Id)
                .Append(i).Append("CreatedAt:   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:   ").Append(UpdatedAt)
                .Append(i).Append("Name:        ").Append(Name)
                .Append(i).Append("Description: ").Append(Description);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
