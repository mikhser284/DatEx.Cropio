using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Группа типов работ </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/work_type_groups.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// </remarks>
    [JsonObject(Title = "work_type_groups")]
    public class CO_WorkTypeGroup : ICropioExtendetObject
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

        /// <summary> Описание </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> Название </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> Standard name. Reserved field for default WorkTypesGroups </summary>
        [JsonConverter(typeof(JsonConverter_StandardNameOfWorkTypeGroup))]
        [JsonProperty("standard_name")]
        public CE_StandardNameOfWorkTypeGroup? StandardName { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:           ").Append(Id)
                .Append(i).Append("Id_External:  ").Append(Id_External)
                .Append(i).Append("CreatedAt:    ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:    ").Append(UpdatedAt)
                .Append(i).Append("Description:  ").Append(Description)
                .Append(i).Append("Name:         ").Append(Name)
                .Append(i).Append("StandardName: ").Append(StandardName.AsRuString())
                ;
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
