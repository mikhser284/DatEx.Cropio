using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Map_FieldShape_LandParcel : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of FieldShapeLandParcelMappingItem </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> id of FieldShape </summary>
        [JsonProperty("field_shape_id")]
        public Int32 Id_FieldShape { get; set; }

        /// <summary> id of LandParcel </summary>
        [JsonProperty("land_parcel_id")]
        public Int32 Id_LandParcel { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Id_FieldShape:   ").Append(Id_FieldShape)
                .Append(i).Append("Id_LandParcel:   ").Append(Id_LandParcel);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
