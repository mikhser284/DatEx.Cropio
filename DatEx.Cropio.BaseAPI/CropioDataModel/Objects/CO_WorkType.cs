using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Тип работ </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/work_types.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// - Id_WorkTypeGroup -> CO_WorkTypeGroup.Id     (В JSON work_type_group_id -> work_type_groups.id)
    /// </remarks>
    [JsonObject(Title = "work_types")]
    public class CO_WorkType : ICropioExtendetObject
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

        /// <summary> Id объекта CO_WorkTypeGroup (work_type_groups.id в json) </summary>
        [JsonProperty("work_type_group_id")]
        public Int32 Id_WorkTypeGroup { get; set; }

        /// <summary> Название типа работ </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> Агроработы (да/нет) </summary>
        [JsonProperty("agri")]
        public Boolean TypeIsAgri { get; set; }

        /// <summary> Внесение (да/нет) </summary>
        [JsonProperty("application")]
        public Boolean TypeIsApplication { get; set; }

        /// <summary> Посев (да/нет) </summary>
        [JsonProperty("sowing")]
        public Boolean TypeIsSowing { get; set; }

        /// <summary> Сбор (да/нет) </summary>
        [JsonProperty("harvesting")]
        public Boolean TypeIsHarvesting { get; set; }

        /// <summary> Обработка почвы (да/нет) </summary>
        [JsonProperty("soil")]
        public Boolean TypeIsSoil { get; set; }

        /// <summary> Стандартное название (зарезервировано для стандартных типов работ) </summary>
        [JsonConverter(typeof(JsonConverter_StandardNameOfWorkType))]
        [JsonProperty("standard_name")]
        public CE_StandardNameOfWorkType? StandardName { get; set; }

        /// <summary> Является ли скрытым (да/нет) </summary>
        [JsonProperty("hidden")]
        public Boolean Hidden { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                ").Append(Id)
                .Append(i).Append("Id_External:       ").Append(Id_External)
                .Append(i).Append("CreatedAt:         ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:         ").Append(UpdatedAt)
                .Append(i).Append("Description:       ").Append(Description)
                .Append(i).Append("Id_WorkTypeGroup:  ").Append(Id_WorkTypeGroup)
                .Append(i).Append("Name:              ").Append(Name)
                .Append(i).Append("TypeIsAgri:        ").Append(TypeIsAgri)
                .Append(i).Append("TypeIsApplication: ").Append(TypeIsApplication)
                .Append(i).Append("TypeIsSowing:      ").Append(TypeIsSowing)
                .Append(i).Append("TypeIsHarvesting:  ").Append(TypeIsHarvesting)
                .Append(i).Append("TypeIsSoil:        ").Append(TypeIsSoil)
                .Append(i).Append("StandardName:      ").Append(StandardName.AsRuString())
                .Append(i).Append("Hidden:            ").Append(Hidden)
                ;
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
