using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Контур поля </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/field_shapes.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// - Id_Field      (fields.id d json)
    /// </remarks>
    [JsonObject(Title = "field_shapes")]
    public class CO_FieldShape : ICropioExtendetObject
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

        /// <summary> Id связанного объекта CO_Field (fields.id в json) </summary>
        [JsonProperty("field_id")]
        public Int32 Id_Field { get; set; }

        /// <summary> Время когда контур поля стал актуальным </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary> Площащь расчитанная по контуру (га) </summary>
        [JsonProperty("calculated_area")]
        public Single CalculatedArea { get; set; }

        /// <summary> Официальная площадь (га) </summary>
        [JsonProperty("legal_area")]
        public Single LegalArea { get; set; }

        /// <summary> Обрабатываемая площадь (га) </summary>
        [JsonProperty("tillable_area")]
        public Single TillableArea { get; set; }

        /// <summary> Набор данных которые содержат его упрощенную фигуру в формате GeoJson </summary>
        [JsonProperty("shape_simplified_geojson")]
        public String ShapeSimplifiedGeojson { get; set; }

        /// <summary> Набобр данных которие содержат или позволяют задать оригинальную фигуру поля в формате GeoJson </summary>
        [JsonProperty("shape_geojson")]
        public String ShapeGeojson { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                      ").Append(Id)
                .Append(i).Append("Id_External:             ").Append(Id_External)
                .Append(i).Append("CreatedAt:               ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:               ").Append(UpdatedAt)
                .Append(i).Append("Id_Field:                ").Append(Id_Field)
                .Append(i).Append("StartTime:               ").Append(StartTime)
                .Append(i).Append("CalculatedArea:          ").Append(CalculatedArea.F("0.00 ha"))
                .Append(i).Append("LegalArea:               ").Append(LegalArea.F("0.00 ha"))
                .Append(i).Append("TillableArea:            ").Append(TillableArea.F("0.00 ha"))
                .Append(i).Append("ShapeSimplifiedGeojson:  ").Append(ShapeSimplifiedGeojson)
                .Append(i).Append("ShapeGeojson:            ").Append(ShapeGeojson);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
