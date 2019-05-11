using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Агрооперация </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/agro_operations.json
    /// 
    /// Связи:
    /// @ Id
    /// @ Id_External
    /// - Id_Field                      (fields.id в json)
    /// - Id_AgriWorkPlan               (agri_work_plans.id в json)
    /// - Id_WorkType                   (work_types.id в json)
    /// * Ids_ApplicationMixItems       (application_mix_items.id в json)
    /// * Ids_MachineTasks              (machine_tasks.id в json)
    /// - Id_FieldShape                 (field_shapes.id в json)
    /// </remarks>
    [JsonObject(Title = "agro_operations")]
    public class CO_AgroOperation : ICropioExtendetObject
    {
        /// <summary> ID объекта в системе Cropio </summary>
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
        
        /// <summary> Id связанного объекта "Поле" (fields.id в json) </summary>
        [JsonProperty("field_id")]
        public Int32 Id_Field { get; set; }
        
        /// <summary> Id связанного объекта "План работ" (agri_work_plans.id в json) </summary>
        [JsonProperty("agri_work_plan_id")]
        public Int32? Id_AgriWorkPlan { get; set; }
        
        /// <summary> УСТАРЕЛО! Тип операции </summary>
        /// <remarks> УСТАРЕЛО! Используйте свойство Id_WorkType (work_type_id в json) </remarks>
        [Obsolete("LEGACY! Use work_type_id instead")]
        [JsonProperty("operation_type")]
        public String OperationType { get; set; }

        /// <summary> УСТАРЕЛО! Подтип операции </summary>
        /// <remarks> УСТАРЕЛО! Используйте свойство Id_WorkType (work_type_id в json) </remarks>
        [Obsolete("LEGACY! Use work_type_id instead")]
        [JsonProperty("operation_subtype")]
        public String OperationSubtype { get; set; }
        
        /// <summary> Id связанного объекта "Тип работ" (work_types.id в json) </summary>
        [JsonProperty("work_type_id")]
        public Int32 Id_WorkType { get; set; }
        
        /// <summary> Номер операции </summary>
        [JsonProperty("operation_number")]
        public Int32? OperationNumber { get; set; }

        //TODO Выяснить единицы измерения (скорее всего га)
        /// <summary> Планируемая площадь агрооперации (ед. измерения га?) </summary>
        [JsonProperty("planned_area")]
        public Single PlannedArea { get; set; }

        //TODO Выяснить единицы измерения (скорее всего га)
        /// <summary> Завершенная площадь агрооперации (ед. измерения га?) </summary>
        [JsonProperty("completed_area")]
        public Single CompletedArea { get; set; }

        //TODO Выяснить единицы измерения (скорее всего тонны)
        /// <summary> Вес урожая для агрооперации (ед. измерения т?) </summary>
        [JsonProperty("harvested_weight")]
        public Single? HarvestedWeight { get; set; }

        /// <summary> Статус агроооперации (одно из значений: 'planned', 'in_progress', 'done', 'canceled') </summary>
        [JsonConverter(typeof(JsonConverter_AgroOperationStatus))]
        [JsonProperty("status")]
        public CE_AgroOperationStatus Status { get; set; }

        /// <summary> Планируемая дата начала агрооперации </summary>
        [JsonProperty("planned_start_date")]
        public DateTime? PlannedStartDate { get; set; }

        /// <summary> Планируемая дата завершения агрооперации </summary>
        [JsonProperty("planned_end_date")]
        public DateTime? PlannedEndDate { get; set; }

        /// <summary> УСТАРЕЛО! Актуальная дата завершения агрооперации </summary>
        /// <remarks> УСТАРЕЛО! Используйте свойство CompletedDatetime (completed_datetime в json) </remarks>
        [JsonProperty("completed_date")]
        [Obsolete("actual end date of agro operation (deprecated, completed_datetime should be used)")]
        public String CompletedDate { get; set; }

        /// <summary> Актуальное время завершения агрооперации </summary>
        [JsonProperty("completed_datetime")]
        public DateTime? CompletedDatetime { get; set; }

        /// <summary> Рабочий сезон (год в формате yyyy) </summary>
        [JsonProperty("season")]
        public Int32 Season { get; set; }

        /// <summary> Планируемый уровень осадков (л/га) </summary>
        [JsonProperty("planned_water_rate")]
        public Single? PlannedWaterRate { get; set; }

        /// <summary> Фактический уровень осадков (л/га) </summary>
        [JsonProperty("fact_water_rate")]
        public Single? FactWaterRate { get; set; }

        /// <summary> Планируемое междурядное растояние (см) </summary>
        [JsonProperty("planned_row_spacing")]
        public Single? PlannedRowSpacing { get; set; }

        /// <summary> Планируемая глубина обработки (см) </summary>
        [JsonProperty("planned_depth")]
        public Single? PlannedDepth { get; set; }

        /// <summary> Планируемая скорость обработки (км/ч) </summary>
        [JsonProperty("planned_speed")]
        public Single? PlannedSpeed { get; set; }

        /// <summary> Процент завершения агрооперации </summary>
        [JsonProperty("completed_percents")]
        public Single CompletedPercents { get; set; }
        
        /// <summary> Является ли операция частично завершенной </summary>
        [JsonProperty("partially_completed")]
        public Boolean PartiallyCompleted { get; set; }
        
        //TODO Выяснить ед. измерения (скорее всего га)
        /// <summary> Завершенная площадь (заданная в ручную) (ед. изм. га?) </summary>
        [JsonProperty("partially_completed_manually_defined_area")]
        public Single PartiallyCompletedManuallyDefinedArea { get; set; }

        //TODO Выяснить ед. измерения (скорее всего га)
        /// <summary> Псевдоним для свойства CoveredAreaByTrack (covered_area_by_track в json) (ед. изм. га?) </summary>
        [JsonProperty("covered_area")]
        public Single? CoveredArea { get; set; }

        //TODO Выяснить ед. измерения (скорее всего га)
        /// <summary> Актуальная площадь обработанная машинами (исключая пересечения) (ед. изм. га?) </summary>
        [JsonProperty("covered_area_by_track")]
        public Single? CoveredAreaByTrack { get; set; }

        //TODO Выяснить ед. измерения (скорее всего га)
        /// <summary> Площадь обработанная при помощи машинной обработки (длинна трека * ширина обработки) (ед. изм. га?) </summary>
        [JsonProperty("machine_work_area")]
        public Single? MachineWorkArea { get; set; }

        /// <summary> Потребление топлива (л) </summary>
        [JsonProperty("fuel_consumption")]
        public Single? FuelConsumption { get; set; }

        /// <summary> Удельное потребление топлива (л/га) </summary>
        [JsonProperty("fuel_consumption_per_ha")]
        public Single? FuelConsumptionPerHa { get; set; }

        /// <summary> Дополнительная информация </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        /// <summary> Описание </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> Набор объектов "Внесение" (Внесение семян, удобрений, химикатов, ...) (application_mix_items.id в json) </summary>
        [JsonProperty("application_mix_items")]
        public List<CO_ApplicationMixItem> ApplicationMixItems { get; set; }

        /// <summary> Набор идентификаторов объектов "Машинное задание" (machine_tasks.id в json) </summary>
        [JsonProperty("machine_tasks")]
        public List<Int32> Ids_MachineTasks { get; set; }
        
        /// <summary> Актуальная дата начала агрооперации </summary>
        /// <remarks> Данное свойство не указанно в официальном API </remarks>
        [JsonProperty("actual_start_datetime")]
        public DateTime ActualStartDatetime { get; set; }
        
        /// <summary> Пользовательское название агрооперации (По умолчанию "тип/подтип") </summary>
        /// <remarks> Данное свойство не указанно в официальном API </remarks>
        [JsonProperty("custom_name")]
        public String CustomName { get; set; }
        
        /// <summary> Id связанного объекта "Контур поля" (field_shapes.id в json) </summary>
        /// <remarks> Данное свойство не указанно в официальном API </remarks>
        [JsonProperty("field_shape_id")]
        public Int32 Id_FieldShape { get; set; }
        
        /// <summary> Является ли агрооперация заблокированной для изменений </summary>
        /// <remarks> Данное свойство не указанно в официальном API </remarks>
        [JsonProperty("locked_to_edit")]
        public Boolean LockedToEdit { get; set; }
        
        //TODO Выяснить единицы измерения
        /// <summary> Планируемое растояние между растениями (ед измерения ?) </summary>
        /// <remarks> Данное свойство не указанно в официальном API </remarks>
        [JsonProperty("planned_plant_spacing")]
        public Single? PlannedPlantSpacing { get; set; }
        
        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            String i2 = HttpClientHelper.Indent(indentLevel + 1);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                                    ").Append(Id)
                .Append(i).Append("Id_External:                           ").Append(Id_External)
                .Append(i).Append("CreatedAt:                             ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                             ").Append(UpdatedAt)
                .Append(i).Append("Id_Field:                              ").Append(Id_Field)
                .Append(i).Append("Id_AgriWorkPlan:                       ").Append(Id_AgriWorkPlan)
                .Append(i).Append("[Obsolete] OperationType:              ").Append(OperationType)
                .Append(i).Append("[Obsolete] OperationSubtype:           ").Append(OperationSubtype)
                .Append(i).Append("Id_WorkType:                           ").Append(Id_WorkType)
                .Append(i).Append("OperationNumber:                       ").Append(OperationNumber)
                .Append(i).Append("PlannedArea:                           ").Append(PlannedArea.F("0.00 ha"))
                .Append(i).Append("CompletedArea:                         ").Append(CompletedArea.F("0.00"))
                .Append(i).Append("HarvestedWeight:                       ").Append(HarvestedWeight.F("0.00"))
                .Append(i).Append("Status:                                ").Append(Status)
                .Append(i).Append("PlannedStartDate:                      ").Append(PlannedStartDate)
                .Append(i).Append("PlannedEndDate:                        ").Append(PlannedEndDate)
                .Append(i).Append("CompletedDate:                         ").Append(CompletedDate)
                .Append(i).Append("CompletedDatetime:                     ").Append(CompletedDatetime)
                .Append(i).Append("Season:                                ").Append(Season)
                .Append(i).Append("PlannedWaterRate:                      ").Append(PlannedWaterRate.F("0.00 l/ha"))
                .Append(i).Append("FactWaterRate:                         ").Append(FactWaterRate.F("0.00 l/ha"))
                .Append(i).Append("PlannedRowSpacing:                     ").Append(PlannedRowSpacing.F("0.00 cm"))
                .Append(i).Append("PlannedDepth:                          ").Append(PlannedDepth.F("0.00 cm"))
                .Append(i).Append("PlannedSpeed                           ").Append(PlannedSpeed.F("0.00 km/h"))
                .Append(i).Append("CompletedPercents:                     ").Append(CompletedPercents.F("0.00"))
                .Append(i).Append("PartiallyCompleted:                    ").Append(PartiallyCompleted)
                .Append(i).Append("PartiallyCompletedManuallyDefinedArea: ").Append(PartiallyCompletedManuallyDefinedArea.F("0.00 ha"))
                .Append(i).Append("CoveredArea:                           ").Append(CoveredArea.F("0.00"))
                .Append(i).Append("CoveredAreaByTrack:                    ").Append(CoveredAreaByTrack.F("0.00"))
                .Append(i).Append("MachineWorkArea:                       ").Append(MachineWorkArea.F("0.00"))
                .Append(i).Append("FuelConsumption:                       ").Append(FuelConsumption.F("0.00 l"))
                .Append(i).Append("FuelConsumptionPerHa:                  ").Append(FuelConsumptionPerHa.F("0.00 l/ha"))
                .Append(i).Append("AdditionalInfo:                        ").Append(AdditionalInfo)
                .Append(i).Append("Description:                           ").Append(Description)
                .Append(i).Append("Ids_ApplicationMixItems:               ")
                .Append(i).Append("{");
            Int32 itemNo = 0;
            foreach (CO_ApplicationMixItem applicationMixItemId in ApplicationMixItems) sb.Append(i2).Append("item #: ").Append(++itemNo).Append(i2).AppendLine(applicationMixItemId.GetTextView(indentLevel + 1));
            sb
                .Append(i).Append("}")
                .Append(i).Append("Ids_MachineTasks:                     ")
                .Append(i).Append("{");
            itemNo = 0;
            if(Ids_MachineTasks != null && Ids_MachineTasks.Count > 0)
                foreach (Int32 machineTaskId in Ids_MachineTasks) sb.Append(i2).Append("item #: ").Append(++itemNo).Append(i2).AppendLine(machineTaskId.ToString());
            sb
                .Append(i).Append("}")
                .Append(i).Append("ActualStartDatetime:                     ").Append(ActualStartDatetime)
                .Append(i).Append("CustomName:                              ").Append(CustomName)
                .Append(i).Append("Id_FieldShape:                           ").Append(Id_FieldShape)
                .Append(i).Append("LockedToEdit:                            ").Append(LockedToEdit)
                .Append(i).Append("PlannedPlantSpacing:                     ").Append(PlannedPlantSpacing.F("0.00"));
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
