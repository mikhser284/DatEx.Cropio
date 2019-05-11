using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Map_FieldScout_ReportThreat : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of field scout report threat mapping item </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> Cropio ID of related field scout report </summary>
        [JsonProperty("field_scout_report_id")]
        public Int32 Id_FieldScoutReport { get; set; }

        /// <summary> Cropio ID of related plant threat </summary>
        [JsonProperty("plant_threat_id")]
        public Int32 Id_PlantThreat { get; set; }

        /// <summary> comment about threat </summary>
        [JsonProperty("comment")]
        public String Comment { get; set; }

        /// <summary> you can submit this image througth multipart-form POST query </summary>
        [JsonProperty("photo")]
        public String Photo { get; set; }

        /// <summary> object describing image </summary>
        [JsonProperty("image")]
        public String Image { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                  ").Append(Id)
                .Append(i).Append("CreatedAt:           ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:           ").Append(UpdatedAt)
                .Append(i).Append("Id_FieldScoutReport: ").Append(Id_FieldScoutReport)
                .Append(i).Append("Id_PlantThreat:      ").Append(Id_PlantThreat)
                .Append(i).Append("Comment:             ").Append(Comment)
                .Append(i).Append("Photo:               ").Append(Photo)
                .Append(i).Append("Image:               ").Append(Image);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
