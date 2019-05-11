using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> План агро работ </summary>
    /// /// <remarks>
    /// Пример json-объекта находится в JsonSamples/agri_work_plans.json
    /// 
    /// Связи:
    /// @ Id 
    /// - Id_WorkType -> CO_WorkType.Id                                             (work_type_id -> work_types.id в json)
    /// - Id_Groupable(GroupableType) -> {CO_GroupFolder.Id | CO_FieldGroup.Id}     (groupable_id(groupable_type) -> {group_folders.id | field_shapes.id} в json)
    /// - Id_ResponsiblePerson -> CO_User.Id                                        (responsible_person_id -> users.id в json)
    /// </remarks>
    [JsonObject(Title = "agri_work_plans")]
    public class CO_AgriWorkPlan : ICropioRegularObject
    {
        /// <summary> ID объекта в системе Cropio </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> Время создания объекта </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Время последнего обновления объекта </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> Статус плана агроработ (Одно из значений: 'plan', 'done') </summary>
        [JsonConverter(typeof(JsonConverter_AgriWorkPlanStatus))]
        [JsonProperty("status")]
        public CE_AgriWorkPlanStatus Status { get; set; }
        
        /// <summary> УСТАРЕЛО! Тип работ </summary>
        /// <remarks> УСТАРЕЛО! Используйте Id_WorkType (work_type_id в json) </remarks>
        [Obsolete("LEGACY! Use Id_WorkType instead")]
        [JsonProperty("work_type")]
        public String WorkType { get; set; }
        
        /// <summary> УСТАРЕЛО! Подтип работ </summary>
        /// <remarks> УСТАРЕЛО! Используйте Id_WorkType (work_type_id в json) </remarks>
        [Obsolete("LEGACY! Use work_type_id instead")]
        [JsonProperty("work_subtype")]
        public String WorkSubtype { get; set; }
        
        /// <summary> Id связанного объекта "Тип работ" </summary>
        [JsonProperty("work_type_id")]
        public Int32 Id_WorkType { get; set; }

        /// <summary> Тип объектов для которых был создан план агроработ ('CO_GroupFolder','CO_FieldGroup') (group_folders; field_shapes в json) </summary>
        [JsonProperty("groupable_type")]
        public String GroupableType { get; set; }

        /// <summary> Id связанного объекта ('CO_GroupFolder','CO_FieldGroup') (group_folders; field_shapes в json) в зависимости от значения поля GroupableType (groupable_type в json) </summary>
        [JsonProperty("groupable_id")]
        public Int32 Id_Groupable { get; set; }
        
        /// <summary> Сезон (год в формате "yyyy") с которым связан план </summary>
        [JsonProperty("season")]
        public Int32 Season { get; set; }
        
        /// <summary> Запланированая дата начала работ по плану </summary>
        [JsonProperty("planned_start_date")]
        public DateTime PlannedStartDate { get; set; }
        
        /// <summary> Запланированная дата завершения работ по плану </summary>
        [JsonProperty("planned_end_date")]
        public DateTime PlannedEndDate { get; set; }
        
        /// <summary> Дополнительная информация </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }
        
        /// <summary> Описание </summary>
        [JsonProperty("description")]
        public String Description { get; set; }
        
        /// <summary> Планируемый уровень осадков (л/га) </summary>
        [JsonProperty("planned_water_rate")]
        public Single PlannedWaterRate { get; set; }
        
        /// <summary> Планируемое растояние между рядами (см) </summary>
        [JsonProperty("planned_rows_spacing")]
        public Single? PlannedRowsSpacing { get; set; }

        /// <summary> Планируемое растояние между растениями (см) </summary>
        [JsonProperty("planned_plant_spacing")]
        public Single? PlannedPlantSpacing { get; set; }
        
        /// <summary> Планируемая глубина (см) </summary>
        [JsonProperty("planned_depth")]
        public Single? PlannedDepth { get; set; }
        
        /// <summary> Планируемая скорость (км/ч) </summary>
        [JsonProperty("planned_speed")]
        public Single? PlannedSpeed { get; set; }
        
        /// <summary> Id ответсвтенного пользователя (объект CO_User) (users.id в json) </summary>
        [JsonProperty("responsible_person_id")]
        public Int32? Id_ResponsiblePerson { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                      ").Append(Id)
                .Append(i).Append("CreatedAt:               ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:               ").Append(UpdatedAt)
                .Append(i).Append("Status:                  ").Append(Status)
                .Append(i).Append("WorkType:                ").Append(WorkType)
                .Append(i).Append("WorkSubtype:             ").Append(WorkSubtype) 
                .Append(i).Append("Id_WorkType:             ").Append(Id_WorkType)
                .Append(i).Append("GroupableType:           ").Append(GroupableType)
                .Append(i).Append("Id_Groupable:            ").Append(Id_Groupable)
                .Append(i).Append("Season:                  ").Append(Season)
                .Append(i).Append("PlannedStartDate:        ").Append(PlannedStartDate)
                .Append(i).Append("PlannedEndDate:          ").Append(PlannedEndDate)
                .Append(i).Append("AdditionalInfo:          ").Append(AdditionalInfo)
                .Append(i).Append("Description:             ").Append(Description)
                .Append(i).Append("PlannedWaterRate:        ").Append(PlannedWaterRate.F("0.00 l/ha"))
                .Append(i).Append("PlannedRowsSpacing:      ").Append(PlannedRowsSpacing.F("0.00 cm"))
                .Append(i).Append("PlannedPlantSpacing:     ").Append(PlannedPlantSpacing.F("0.00 cm"))
                .Append(i).Append("PlannedDepth:            ").Append(PlannedDepth.F("0.00 cm"))
                .Append(i).Append("PlannedSpeed:            ").Append(PlannedSpeed.F("0.00 km/h"))
                .Append(i).Append("Id_ResponsiblePerson:    ").Append(Id_ResponsiblePerson);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
