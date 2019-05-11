using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_FieldScoutReport : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of FieldScoutReport </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated on server </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> CropioID of Field </summary>
        [JsonProperty("field_id")]
        public Int32 Id_Field { get; set; }
        
        /// <summary> Cropio ID of User created this report </summary>
        [JsonProperty("user_id")]
        public Int32 Id_User { get; set; }
        
        /// <summary> time when user create report (e.g. from mobile device without network access) </summary>
        [JsonProperty("report_time")]
        public DateTime ReportTime { get; set; }
        
        /// <summary> growth scale for plant (for example "zadoks", contact support if you do not know what submit here) </summary>
        [JsonProperty("growth_scale")]
        public String GrowthScale { get; set; }
        
        /// <summary> stage on growth scale (for example '00', contact support if you do not know what submit here) </summary>
        [JsonProperty("growth_stage")]
        public String GrowthStage { get; set; }
        
        /// <summary> your system info </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }
        
        /// <summary> image from field as special structure </summary>
        [JsonProperty("image1")]
        public String Image1 { get; set; }
        
        /// <summary> image from field as special structure </summary>
        [JsonProperty("image2")]
        public String Image2 { get; set; }
        
        /// <summary> image from field as special structure </summary>
        [JsonProperty("image3")]
        public String Image3 { get; set; }
        
        /// <summary> you can submit this image througth multipart-form POST query </summary>
        [JsonProperty("photo1")]
        public String Photo1 { get; set; }
        
        /// <summary> you can submit this image througth multipart-form POST query </summary>
        [JsonProperty("photo2")]
        public String Photo2 { get; set; }
        
        /// <summary> you can submit this image througth multipart-form POST query </summary>
        [JsonProperty("photo3")]
        public String Photo3 { get; set; }
        
        /// <summary> time of report object created on user's devise </summary>
        [JsonProperty("created_by_user_at")]
        public DateTime CreatedByUserAt { get; set; }
        
        /// <summary> time of last updation on user's devise </summary>
        [JsonProperty("updated_by_user_at")]
        public DateTime UpdatedByUserAt { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Id_Field:        ").Append(Id_Field)
                .Append(i).Append("Id_User:         ").Append(Id_User)
                .Append(i).Append("ReportTime:      ").Append(ReportTime)
                .Append(i).Append("GrowthScale:     ").Append(GrowthScale)
                .Append(i).Append("GrowthStage:     ").Append(GrowthStage)
                .Append(i).Append("AdditionalInfo:  ").Append(AdditionalInfo)
                .Append(i).Append("Image1:          ").Append(Image1)
                .Append(i).Append("Image2:          ").Append(Image2)
                .Append(i).Append("Image3:          ").Append(Image3)
                .Append(i).Append("Photo1:          ").Append(Photo1)
                .Append(i).Append("Photo2:          ").Append(Photo2)
                .Append(i).Append("Photo3:          ").Append(Photo3)
                .Append(i).Append("CreatedByUserAt: ").Append(CreatedByUserAt)
                .Append(i).Append("UpdatedByUserAt: ").Append(UpdatedByUserAt);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
