using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_LandParcel : ICropioExtendetObject
    {
        //Not tested

        /// <summary> Cropio ID of LandParcel </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary>  </summary>
        [JsonProperty("external_id")]
        public String Id_External { get; set; }

        /// <summary>  </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>  </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> Cropio ID of FieldGroup </summary>
        [JsonProperty("field_group_id")]
        public Int32 Id_FieldGroup { get; set; }

        /// <summary> cadastral number </summary>
        [JsonProperty("cadastral_number")]
        public String CadastralNumber { get; set; }

        /// <summary> cadastral area </summary>
        [JsonProperty("cadastral_area")]
        public Single CadastralArea { get; set; }

        /// <summary> cadastral price </summary>
        [JsonProperty("cadastral_price")]
        public Single CadastralPrice { get; set; }
        
        /// <summary> permitted use </summary>
        [JsonProperty("permitted_use")]
        public String PermittedUse { get; set; }

        /// <summary> address </summary>
        [JsonProperty("address")]
        public String Address { get; set; }

        /// <summary> region </summary>
        [JsonProperty("region")]
        public String Region { get; set; }

        /// <summary> country code </summary>
        [JsonProperty("country_code")]
        public String CountryCode { get; set; }
        
        /// <summary> (writeonly) attribute for setting shape for LandParcel object </summary>
        [JsonProperty("shape_json")]
        public String ShapeJson { get; set; }

        /// <summary> your system info </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        /// <summary> description </summary>
        [JsonProperty("description")]
        public String Description { get; set; }
        
        /// <summary> planned action type: empty, [purchase] </summary>
        [JsonProperty("planned_action")]
        public Object PlannedAction { get; set; }

        /// <summary> registration_number </summary>
        [JsonProperty("registration_number")]
        public String RegistrationNumber { get; set; }
        
        /// <summary> subadministrative area name </summary>
        [JsonProperty("subadministrative_area_name")]
        public Object SubadministrativeAreaName { get; set; }

        /// <summary> village_council </summary>
        [JsonProperty("village_council")]
        public Object VillageCouncil { get; set; }

        /// <summary> invisible on maps if true </summary>
        [JsonProperty("in_archive")]
        public Boolean IsArchived { get; set; }
        
        /// <summary> series of attributes that contain original shape in different formats </summary>
        [JsonProperty("shape")]
        public String Shape { get; set; }

        /// <summary> simplified shape in GeoJSON format </summary>
        [JsonProperty("geo_json")]
        public String GeoJson { get; set; }

        /// <summary> calculated area </summary>
        [JsonProperty("calculated_area")]
        public Single CalculatedArea { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                          ").Append(Id)
                .Append(i).Append("Id_External:                 ").Append(Id_External)
                .Append(i).Append("CreatedAt:                   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                   ").Append(UpdatedAt)
                .Append(i).Append("Id_FieldGroup:               ").Append(Id_FieldGroup)
                .Append(i).Append("CadastralNumber:             ").Append(CadastralNumber)
                .Append(i).Append("CadastralArea:               ").Append(CadastralArea)
                .Append(i).Append("CadastralPrice:              ").Append(CadastralPrice)
                .Append(i).Append("PermittedUse:                ").Append(PermittedUse)
                .Append(i).Append("Address:                     ").Append(Address)
                .Append(i).Append("Region:                      ").Append(Region)
                .Append(i).Append("CountryCode:                 ").Append(CountryCode)
                .Append(i).Append("ShapeJson:                   ").Append(ShapeJson)
                .Append(i).Append("AdditionalInfo:              ").Append(AdditionalInfo)
                .Append(i).Append("Description:                 ").Append(Description)
                .Append(i).Append("PlannedAction:               ").Append(PlannedAction)
                .Append(i).Append("RegistrationNumber:          ").Append(RegistrationNumber)
                .Append(i).Append("SubadministrativeAreaName:   ").Append(SubadministrativeAreaName)
                .Append(i).Append("VillageCouncil:              ").Append(VillageCouncil)
                .Append(i).Append("IsArchived:                  ").Append(IsArchived)
                .Append(i).Append("Shape:                       ").Append(Shape)
                .Append(i).Append("GeoJson:                     ").Append(GeoJson)
                .Append(i).Append("CalculatedArea:              ").Append(CalculatedArea);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }

}
