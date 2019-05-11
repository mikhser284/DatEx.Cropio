using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Поле </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/fields.json
    /// 
    /// @ Id
    /// @ Id_External
    /// - Id_FieldGroup     (field_groups.id в json)
    /// - Id_CurrentShape   (field_shapes.id в json
    /// </remarks>
    [JsonObject(Title = "fields")]
    public class CO_Field : ICropioExtendetObject
    {
        /// <summary> ID объекта в Cropio </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> ID объекта во внешней системе </summary>
        [JsonProperty("external_id")]
        public String Id_External { get; set; }

        /// <summary> Время создания объекта </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Время последнего обновления объекта </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> Id связанного объекта CO_FieldGroup (field_groups.id в json) </summary>
        [JsonProperty("field_group_id")]
        public Int32 Id_FieldGroup { get; set; }
        
        /// <summary> Название поля </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> Дополнительная информация </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }
        
        /// <summary> Описание </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> Набор данных которые содержат его упрощенную фигуру в формате GeoJson </summary>
        [JsonProperty("shape_simplified_geojson")]
        public String ShapeSimplifiedGeojson { get; set; }
        
        /// <summary> Набобр данных которие содержат или позволяют задать оригинальную фигуру поля в формате GeoJson </summary>
        [JsonProperty("shape_geojson")]
        public String ShapeGeojson { get; set; }
        
        /// <summary> Id связанного объекта CO_FieldShape (field_shapes.id в json) </summary>
        [JsonProperty("current_shape_id")]
        public Int32 Id_CurrentShape { get; set; }
        
        /// <summary> Площадь поля расчитаная по его фигуру (га) </summary>
        [JsonProperty("calculated_area")]
        public Single CalculatedArea { get; set; }

        /// <summary> Официальная площадь (га) </summary>
        [JsonProperty("legal_area")]
        public Single? LegalArea { get; set; }
        
        /// <summary> time when shape end become actual </summary>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary> Обрабатываемая площадь (га) </summary>
        [JsonProperty("tillable_area")]
        public Single? TillableArea { get; set; }

        /// <summary> Административная область (например: страна, штат, район) </summary>
        [JsonProperty("administrative_area_name")]
        public String AdministrativeAreaName { get; set; }

        /// <summary> Субадминистративная область (например: регион, и т.п.) </summary>
        [JsonProperty("subadministrative_area_name")]
        public String SubadministrativeAreaName { get; set; }

        /// <summary> Местонахождение (например: город, деревня, и т.п.) </summary>
        [JsonProperty("locality")]
        public String Locality { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                        ").Append(Id)
                .Append(i).Append("Id_External:               ").Append(Id_External)
                .Append(i).Append("CreatedAt:                 ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                 ").Append(UpdatedAt)
                .Append(i).Append("Id_FieldGroup:             ").Append(Id_FieldGroup)
                .Append(i).Append("Name:                      ").Append(Name)
                .Append(i).Append("AdditionalInfo:            ").Append(AdditionalInfo)
                .Append(i).Append("Description:               ").Append(Description)
                .Append(i).Append("ShapeSimplifiedGeojson:    ").Append(ShapeSimplifiedGeojson)
                .Append(i).Append("ShapeGeojson:              ").Append(ShapeGeojson)
                .Append(i).Append("Id_CurrentShape:           ").Append(Id_CurrentShape)
                .Append(i).Append("CalculatedArea:            ").Append(CalculatedArea.F("0.00 ha"))
                .Append(i).Append("LegalArea:                 ").Append(LegalArea.F("0.00 ha"))
                .Append(i).Append("EndTime:                   ").Append(EndTime)
                .Append(i).Append("TillableArea:              ").Append(TillableArea.F("0.00 ha"))
                .Append(i).Append("AdministrativeAreaName:    ").Append(AdministrativeAreaName)
                .Append(i).Append("SubadministrativeAreaName: ").Append(SubadministrativeAreaName)
                .Append(i).Append("Locality:                  ").Append(Locality);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }

}
