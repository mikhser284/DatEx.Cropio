using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_MaintenanceRecord : ICropioRegularObject
    {
        //Not implemented

        /// <summary> Cropio ID of MaintenanceRecord </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> type of object for which this record: Machine,Implement </summary>
        [JsonProperty("maintainable_type")]
        public String MaintainableType { get; set; }
        
        /// <summary> Cropio ID of object for which this record </summary>
        [JsonProperty("maintainable_id")]
        public Int32 Id_Maintainable { get; set; }
        
        /// <summary> Maintenance types and subtypes: • cleaning; • maintenance { inspection, service, other }; • repair { engine, gearbox, electronics, hydraulic, suspension, fuel_system, wheels, implements_and_equipment, other }; • other </summary>
        [JsonProperty("maintenance_type")]
        public String MaintenanceType { get; set; }
        
        /// <summary> Maintenance types and subtypes: • cleaning; • maintenance { inspection, service, other }; • repair { engine, gearbox, electronics, hydraulic, suspension, fuel_system, wheels, implements_and_equipment, other }; • other </summary>
        [JsonProperty("maintenance_subtype")]
        public String MaintenanceSubtype { get; set; }
        
        /// <summary> start time for maintenance </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }
        
        /// <summary> end time for maintenance </summary>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }
        
        /// <summary> some text description for record </summary>
        [JsonProperty("description")]
        public String Description { get; set; }
        
        /// <summary> Repair stages: • problem_identifying; • waiting_spareparts; • waitiing_for_dealer_service; • repair_works; • testing; • postpone; • other </summary>
        [JsonProperty("repair_stage")]
        public String RepairStage { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                  ").Append(Id)
                .Append(i).Append("CreatedAt:           ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:           ").Append(UpdatedAt)
                .Append(i).Append("MaintainableType:    ").Append(MaintainableType)
                .Append(i).Append("Id_Maintainable:     ").Append(Id_Maintainable)
                .Append(i).Append("MaintenanceType:     ").Append(MaintenanceType)
                .Append(i).Append("MaintenanceSubtype:  ").Append(MaintenanceSubtype)
                .Append(i).Append("StartTime:           ").Append(StartTime)
                .Append(i).Append("EndTime:             ").Append(EndTime)
                .Append(i).Append("Description:         ").Append(Description)
                .Append(i).Append("RepairStage:         ").Append(RepairStage);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
