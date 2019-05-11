using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_AdditionalObjects : ICropioRegularObject
    {
        //Not tested

        [JsonProperty("id")]
        public Int32 Id { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> FieldGroup ID (AdditionalObject belongs to). Required </summary>
        [JsonProperty("field_group_id")]
        public String Id_FieldGroup { get; set; }
        
        /// <summary> Name </summary>
        [JsonProperty("name")]
        public String Name { get; set; }
        
        /// <summary> Type of object. Could be any string. Example: 'Road', 'Building', etc. </summary>
        [JsonProperty("object_type")]
        public String ObjectType { get; set; }
        
        /// <summary> Geometry type of objects. Could be one of: point, line, polygon </summary>
        [JsonProperty("geometry_type")]
        public String GeometryType { get; set; }
        
        /// <summary> (readonly) Area of object (defined only for polygons). Calculated automatically </summary>
        [JsonProperty("calculated_area")]
        public Double CalculatedAarea { get; set; }
        
        [JsonProperty("administrative_area_name")]
        public String AdministrativeAreaName { get; set; }
        
        [JsonProperty("subadministrative_area_name")]
        public String SubadministrativeAreaName { get; set; }
        
        /// <summary> (readonly) Simplified shape in GeoJSON format </summary>
        [JsonProperty("geo_json")]
        public String GeoJson { get; set; }
        
        /// <summary> (writeonly) attribute for setting shape for Additional object. (in GeoJSON format) </summary>
        [JsonProperty("shape_json")]
        public String ShapeJson { get; set; }
        
        /// <summary> Additional info </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }
        
        /// <summary> Some description </summary>
        [JsonProperty("description")]
        public String Description { get; set; }
        
        [JsonProperty("locality")]
        public String Locality { get; set; }
        
        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                          ").Append(Id)
                .Append(i).Append("CreatedAt:                   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                   ").Append(UpdatedAt)
                .Append(i).Append("Id_FieldGroup:               ").Append(Id_FieldGroup)
                .Append(i).Append("Name:                        ").Append(Name)
                .Append(i).Append("ObjectType:                  ").Append(ObjectType)
                .Append(i).Append("GeometryType:                ").Append(GeometryType)
                .Append(i).Append("CalculatedAarea:             ").Append(CalculatedAarea)
                .Append(i).Append("AdministrativeAreaName:      ").Append(AdministrativeAreaName)
                .Append(i).Append("SubadministrativeAreaName:   ").Append(SubadministrativeAreaName)
                .Append(i).Append("GeoJson:                     ").Append(GeoJson)
                .Append(i).Append("ShapeJson:                   ").Append(ShapeJson)
                .Append(i).Append("AdditionalInfo:              ").Append(AdditionalInfo)
                .Append(i).Append("Description:                 ").Append(Description)
                .Append(i).Append("Locality:                    ").Append(Locality);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
