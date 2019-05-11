using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Map_MachineTask_Field : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of MachineTaskAgroOperationMappingItem </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> Cropio ID of MachineTask </summary>
        [JsonProperty("machine_task_id")]
        public Int32 Id_MachineTask { get; set; }
        
        /// <summary> Cropio ID of Field </summary>
        [JsonProperty("field_id")]
        public Int32 Id_Field { get; set; }
        
        /// <summary> covered area </summary>
        [JsonProperty("covered_area")]
        public Single CoveredArea { get; set; }
        
        /// <summary> fuel consumption </summary>
        [JsonProperty("fuel_consumption")]
        public Single FuelConsumption { get; set; }
        
        /// <summary> machine work area </summary>
        [JsonProperty("work_area")]
        public Single WorkArea { get; set; }
        
        /// <summary> hourly covered area </summary>
        [JsonProperty("covered_area_hourly")]
        public Single CoveredAreaHourly { get; set; }
        
        /// <summary> hourly machine work area </summary>
        [JsonProperty("work_area_hourly")]
        public Single WorkAreaHourly { get; set; }
        
        /// <summary> machine distance inside a field </summary>
        [JsonProperty("work_distance")]
        public Single WorkDistance { get; set; }
        
        /// <summary> hourly machine distance inside a field </summary>
        [JsonProperty("work_distance_hourly")]
        public Single WorkDistanceHourly { get; set; }
        
        /// <summary> machine work duration inside a field (seconds) </summary>
        [JsonProperty("work_duration")]
        public Int32 WorkDuration { get; set; }
        
        /// <summary> hourly machine work duration inside a field (seconds) </summary>
        [JsonProperty("work_duration_hourly")]
        public Int32 WorkDurationHourly { get; set; }
        
        /// <summary> array of time intervals, when machine was on the field </summary>
        [Obsolete("Not fully implemented")]
        [JsonProperty("work_timetable")]
        public String WorkTimetable { get; set; }
        
        /// <summary> boolean, true if covered area was settled manually </summary>
        [JsonProperty("manually_defined_covered_area")]
        public Boolean ManuallyDefinedCoveredArea { get; set; }
        
        /// <summary> boolean, true if fuel consumption was settled manually </summary>
        [JsonProperty("manually_defined_fuel_consumption")]
        public Boolean ManuallyDefinedFuelConsumption { get; set; }
        
        /// <summary> covered area calculated with "first track rule" </summary>
        [JsonProperty("covered_area_by_track")]
        public Single CoveredAreaByTrack { get; set; }
        
        /// <summary> hourly covered area calculated with "first track rule" </summary>
        [JsonProperty("covered_area_by_track_hourly")]
        public Single CoveredAreaByTrackHourly { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                              ").Append(Id)
                .Append(i).Append("CreatedAt:                       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                       ").Append(UpdatedAt)
                .Append(i).Append("Id_MachineTask:                  ").Append(Id_MachineTask)
                .Append(i).Append("Id_Field:                        ").Append(Id_Field)
                .Append(i).Append("CoveredArea:                     ").Append(CoveredArea)
                .Append(i).Append("WorkAreaHourly:                  ").Append(WorkAreaHourly)
                .Append(i).Append("WorkDistance:                    ").Append(WorkDistance)
                .Append(i).Append("WorkDistanceHourly:              ").Append(WorkDistanceHourly)
                .Append(i).Append("WorkDuration:                    ").Append(WorkDuration)
                .Append(i).Append("WorkDurationHourly:              ").Append(WorkDurationHourly)
                .Append(i).Append("WorkTimetable:                   ").Append(WorkTimetable)
                .Append(i).Append("ManuallyDefinedCoveredArea:      ").Append(ManuallyDefinedCoveredArea)
                .Append(i).Append("ManuallyDefinedFuelConsumption:  ").Append(ManuallyDefinedFuelConsumption)
                .Append(i).Append("CoveredAreaByTrack:              ").Append(CoveredAreaByTrack);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
