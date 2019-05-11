using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Map_LandDocument_LandParcel : ICropioRegularObject
    {
        //Not implemented

        /// <summary> Cropio ID of LandDocumentLandParcelMappingItem </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> id of LandDocument </summary>
        [JsonProperty("land_document_id")]
        public Int32 Id_LandDocument { get; set; }

        /// <summary> id of LandLandParcel </summary>
        [JsonProperty("land_parcel_id")]
        public Int32 Id_LandParcel { get; set; }

        /// <summary> land type (nil, own, counterparty) </summary>
        /// <remarks> If [LandDocument] type is [exchange] there will be 2 records in [LandDocumentLandParcelMappingItem] One record will be with type [own], another one with [counterparty].</remarks>
        [JsonProperty("land_type")]
        public String LandType { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Id_LandDocument: ").Append(Id_LandDocument)
                .Append(i).Append("Id_LandParcel:   ").Append(Id_LandParcel)
                .Append(i).Append("LandType:        ").Append(LandType);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
