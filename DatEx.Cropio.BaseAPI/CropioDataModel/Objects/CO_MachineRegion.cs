using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_MachineRegion : ICropioExtendetObject
    {
        //Not implemented

        /// <summary> Cropio ID of MachineRegion </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }
        
        /// <summary> </summary>
        [JsonProperty("external_id")]
        public String Id_External { get; set; }

        /// <summary> </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> name of machine region </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> ancestry for current record </summary>
        [JsonProperty("ancestry")]
        public String Ancestry { get; set; }

        /// <summary> description </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> additional info for region </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Name:            ").Append(Name)
                .Append(i).Append("Ancestry:        ").Append(Ancestry)
                .Append(i).Append("Description:     ").Append(Description)
                .Append(i).Append("AdditionalInfo:  ").Append(AdditionalInfo);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
