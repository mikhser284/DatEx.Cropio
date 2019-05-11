using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Задание для машины </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/machine_tasks.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// - Id_Machine -> CO_Machine.Id     (В JSON machine_id -> machines.id)
    /// - Id_WorkType -> CO_WorkType.Id   (В JSON work_type_id -> work_types.id)
    /// - Id_Driver -> CO_User.Id         (В JSON driver_id -> users.id)
    /// - Id_Implement -> CO_Implement.Id (В JSON implement_id -> implements.id)
    /// </remarks>
    [JsonObject(Title = "machine_tasks")]
    public class CO_MachineTask : ICropioExtendetObject
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

        /// <summary> Дополнительная информация </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        /// <summary> Id связанного объекта CO_Machine (machines.id в Json) </summary>
        [JsonProperty("machine_id")]
        public Int32 Id_Machine { get; set; }

        /// <summary> Дата начала задания </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary> Дата завершения задания </summary>
        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        /// <summary> УСТАРЕЛО! Тип действия </summary>
        /// <remarks> УСТАРЕЛО! Вместо данного свойства используйте Id_WorkType (work_type_id в json) </remarks>
        [Obsolete("LEGACY! Use [work_type_id] instead")]
        [JsonProperty("action_type")]
        public String ActionType { get; set; }

        /// <summary> УСТАРЕЛО! Подтип действия </summary>
        /// <remarks> УСТАРЕЛО! Вместо данного свойства используйте Id_WorkType (work_type_id в json) </remarks>
        [Obsolete("LEGACY! Use [work_type_id] instead")]
        [JsonProperty("action_subtype")]
        public String ActionSubtype { get; set; }

        /// <summary> Id связанного объекта CO_WorkType (work_types.id в json) </summary>
        [JsonProperty("work_type_id")]
        public Int32 Id_WorkType { get; set; }

        /// <summary> Id связанного объекта CO_User (users.id в json) </summary>
        [JsonProperty("driver_id")]
        public Int32? Id_Driver { get; set; }

        /// <summary> Id связанного объекта CO_Implement (implements.id в json) </summary>
        [JsonProperty("implement_id")]
        public Int32? Id_Implement { get; set; }

        /// <summary> Это работа для подрядчиков (да/нет) </summary>
        [JsonProperty("work_for_contractors")]
        public Boolean IsWorkForContractors { get; set; }

        /// <summary> Это работа для владельцев (да/нет) </summary>
        [JsonProperty("work_for_land_owners")]
        public Boolean IsWorkForLandOwners { get; set; }

        /// <summary> Реальная ширина агрегата (ед. изм. ?) </summary>
        [JsonProperty("real_implement_width")]
        public Single? RealImplementWidth { get; set; }

        /// <summary> Общее расстояние (ед. изм. ?) </summary>
        [JsonProperty("total_distance")]
        public Single TotalDistance { get; set; }

        /// <summary> Общее расстояние почасово (ед. изм. ?) </summary>
        [JsonConverter(typeof(JsonConverter_TimestampedValue<Single>))]
        [JsonProperty("total_distance_hourly")]
        public List<TimestamedValue<Single>> TotalDistanceByHours { get; set; }

        /// <summary> Рабочее расстояние (ед. изм. ?) </summary>
        [JsonProperty("work_distance")]
        public Single WorkDistance { get; set; }

        /// <summary> Рабочее расстояние почасово (ед. изм. ?) </summary>
        [JsonConverter(typeof(JsonConverter_TimestampedValue<Single>))]
        [JsonProperty("work_distance_hourly")]
        public List<TimestamedValue<Single>> WorkDistanceByHours { get; set; }

        /// <summary> Рабочая зона (ед. изм. ?) </summary>
        [JsonProperty("work_area")]
        public Single WorkArea { get; set; }

        /// <summary> Рабочая зона почасово (ед. изм. ?) </summary>
        [JsonConverter(typeof(JsonConverter_TimestampedValue<Single>))]
        [JsonProperty("work_area_hourly")]
        public List<TimestamedValue<Single>> WorkAreaByHours { get; set; }

        /// <summary> Покрытая зона (ед. изм. ?) </summary>
        [JsonProperty("covered_area")]
        public Single CoveredArea { get; set; }

        /// <summary> Покрытая зона почасово (ед. изм. ?) </summary>
        [JsonConverter(typeof(JsonConverter_TimestampedValue<Single>))]
        [JsonProperty("covered_area_hourly")]
        public List<TimestamedValue<Single>> CoveredAreaByHours { get; set; }

        /// <summary> Продолжительность работы (ед. изм. ?) </summary>
        [JsonProperty("work_duration")]
        public Single WorkDuration { get; set; }

        /// <summary> Продолжительность работы почасово (ед. изм. ?)</summary>
        [JsonConverter(typeof(JsonConverter_TimestampedValue<Single>))]
        [JsonProperty("work_duration_hourly")]
        public List<TimestamedValue<Single>> WorkDurationByHours { get; set; }

        /// <summary> График работы </summary>
        [JsonConverter(typeof(JsonConverter_TimeInverval))]
        [JsonProperty("work_timetable")]
        public List<TimeInverval> WorkTimetable { get; set; }

        /// <summary> Сезон (год в формате "yyyy") </summary>
        [JsonProperty("season")]
        public Int32 Season { get; set; }

        /// <summary> Статус задания (Принимает значения: 'done', 'in_progress', 'planned') </summary>
        [JsonConverter(typeof(JsonConverter_StatusOfMachineTask))]
        [JsonProperty("status")]
        public CE_StatusOfMachineTask Status { get; set; }

        /// <summary> Таблица остановок на дороге </summary>
        /// <remarks> Отсуствует в официальном API </remarks>
        [JsonConverter(typeof(JsonConverter_TimeInverval))]
        [JsonProperty("stops_on_road_timetable")]
        public List<TimeInverval> StopsOnRoadTimetable { get; set; }

        /// <summary> Общая продолжительность остановок на дороге </summary>
        /// <remarks> Отсуствует в официальном API </remarks>
        [JsonProperty("stops_on_road_duration")]
        public Int32 StopsOnRoadDuration { get; set; }

        /// <summary> Таблица почавовой продолжительности остановок на дороге </summary>
        /// <remarks> Отсуствует в официальном API </remarks>
        [JsonConverter(typeof(JsonConverter_TimestampedValue<Int32>))]
        [JsonProperty("stops_on_road_duration_hourly")]
        public List<TimestamedValue<Int32>> StopsOnRoadDurationHourly { get; set; }

        /// <summary> Таблица передвижений на догоре </summary>
        /// <remarks> Отсуствует в официальном API </remarks>
        [JsonConverter(typeof(JsonConverter_TimeInverval))]
        [JsonProperty("movements_on_road_timetable")]
        public List<TimeInverval> MovementsOnRoadTimetable { get; set; }

        /// <summary> Общая продолжительность остановок на дороге </summary>
        /// <remarks> Отсуствует в официальном API </remarks>
        [JsonProperty("movements_on_road_duration")]
        public Int32 MovementsOnRoadDuration { get; set; }

        /// <summary> Таблица почасовых передвижений по дороге </summary>
        /// <remarks> Отсуствует в официальном API </remarks>
        [JsonConverter(typeof(JsonConverter_TimestampedValue<Int32>))]
        [JsonProperty("movements_on_road_duration_hourly")]
        public List<TimestamedValue<Int32>> MovementsOnRoadDurationHourly { get; set; }

        /// <summary> Время без GPS-логирования </summary>
        /// <remarks> Отсуствует в официальном API </remarks>
        [JsonProperty("time_without_gps_data")]
        public Int32 TimeWithoutGpsData { get; set; }

        /// <summary> Track integrity coeficient (Не знаю что это такое ?) </summary>
        /// <remarks> Отсуствует в официальном API </remarks>
        [JsonProperty("track_integrity_coef")]
        public Single TrackIntegrityCoef { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                            ").Append(Id)
                .Append(i).Append("Id_External:                   ").Append(Id_External)
                .Append(i).Append("CreatedAt:                     ").Append(CreatedAt.F("yyyy.MM.dd HH:mm:ss"))
                .Append(i).Append("UpdatedAt:                     ").Append(UpdatedAt.F("yyyy.MM.dd HH:mm:ss"))
                .Append(i).Append("Description:                   ").Append(Description)
                .Append(i).Append("AdditionalInfo:                ").Append(AdditionalInfo)
                .Append(i).Append("Id_Machine:                    ").Append(Id_Machine)
                .Append(i).Append("StartTime:                     ").Append(StartTime.F("yyyy.MM.dd HH:mm:ss"))
                .Append(i).Append("EndTime:                       ").Append(EndTime.F("yyyy.MM.dd HH:mm:ss"))
                .Append(i).Append("ActionType:                    ").Append(ActionType)
                .Append(i).Append("ActionSubtype:                 ").Append(ActionSubtype)
                .Append(i).Append("Id_WorkType:                   ").Append(Id_WorkType)
                .Append(i).Append("Id_Driver:                     ").Append(Id_Driver)
                .Append(i).Append("Id_Implement:                  ").Append(Id_Implement)
                .Append(i).Append("IsWorkForContractors:          ").Append(IsWorkForContractors)
                .Append(i).Append("IsWorkForLandOwners:           ").Append(IsWorkForLandOwners)
                .Append(i).Append("RealImplementWidth:            ").Append(RealImplementWidth.F("0.00"))
                .Append(i).Append("TotalDistance:                 ").Append(TotalDistance.F("0.00"))
                .Append(i).Append("TotalDistanceByHours:          ").Append(TotalDistanceByHours.F())
                .Append(i).Append("WorkDistance:                  ").Append(WorkDistance.F("0.00"))
                .Append(i).Append("WorkDistanceByHours:           ").Append(WorkDistanceByHours.F())
                .Append(i).Append("WorkArea:                      ").Append(WorkArea.F("0.00"))
                .Append(i).Append("WorkAreaByHours:               ").Append(WorkAreaByHours.F())
                .Append(i).Append("CoveredArea:                   ").Append(CoveredArea.F("0.00"))
                .Append(i).Append("CoveredAreaHourly:             ").Append(CoveredAreaByHours.F())
                .Append(i).Append("WorkDuration:                  ").Append(WorkDuration)
                .Append(i).Append("WorkDurationHourly:            ").Append(WorkDurationByHours.F())
                .Append(i).Append("WorkTimetable:                 ").Append(WorkTimetable.F())
                .Append(i).Append("Season:                        ").Append(Season)
                .Append(i).Append("Status:                        ").Append(Status)
                .Append(i).Append("StopsOnRoadTimetable:          ").Append(StopsOnRoadTimetable.F())
                .Append(i).Append("StopsOnRoadDuration:           ").Append(StopsOnRoadDuration)
                .Append(i).Append("StopsOnRoadDurationHourly:     ").Append(StopsOnRoadDurationHourly.F())
                .Append(i).Append("MovementsOnRoadTimetable:      ").Append(MovementsOnRoadTimetable.F())
                .Append(i).Append("MovementsOnRoadDuration:       ").Append(MovementsOnRoadDuration)
                .Append(i).Append("MovementsOnRoadDurationHourly: ").Append(MovementsOnRoadDurationHourly.F())
                .Append(i).Append("TimeWithoutGpsData:            ").Append(TimeWithoutGpsData)
                .Append(i).Append("TrackIntegrityCoef:            ").Append(TrackIntegrityCoef);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
