using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_HarvestWeighing : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of HarvestWeighing </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("machine_id")]
        public Int32 Id_Machine { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("field_id")]
        public Int32 Id_Field { get; set; }
        
        /// <summary> Cropio ID of AdditionalObject </summary>
        [JsonProperty("weighing_place_id")]
        public Int32 Id_WeighingPlace { get; set; }
        
        /// <summary> time of departure from field </summary>
        [JsonProperty("departure_from_field_time")]
        public DateTime DepartureFromFieldTime { get; set; }
        
        /// <summary> weight </summary>
        [JsonProperty("weight")]
        public Single Weight { get; set; }
        
        /// <summary> brutto weigth </summary>
        [JsonProperty("brutto_weigh")]
        public Single BruttoWeigh { get; set; }
        
        /// <summary> seed moisture </summary>
        [JsonProperty("seed_moisture")]
        public Single SeedMoisture { get; set; }
        
        /// <summary> seed admixture (data type ?) </summary>
        [JsonProperty("seed_admixture")]
        public String SeedAdmixture { get; set; }
        
        /// <summary> time of weighing </summary>
        [JsonProperty("weighing_time")]
        public DateTime WeighingTime { get; set; }
        
        /// <summary> is this track last? (true/false) </summary>
        [JsonProperty("last_truck")]
        public Boolean LastTruck { get; set; }
        
        /// <summary> calculated track length </summary>
        [JsonProperty("track_length")]
        public Single TrackLength { get; set; }
        
        /// <summary> true if car was without logger or track was not recorded </summary>
        [JsonProperty("manually_set_track_length")]
        public Boolean IsTrackLengthSetManually { get; set; }
        
        /// <summary> your system info </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }
        
        /// <summary> description </summary>
        [JsonProperty("description")]
        public String Description { get; set; }
        
        /// <summary> Cropio ID of User created this object (from API-token) </summary>
        [JsonProperty("created_by_user_id")]
        public Int32 CreatedByUserId { get; set; }
        
        /// <summary> array with Cropio ID of unloaded Machines </summary>
        [JsonProperty("unloaded_machines")]
        public List<Int32> Ids_UnloadedMachines { get; set; }


        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            String i2 = HttpClientHelper.Indent(indentLevel + 1);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                          ").Append(Id)
                .Append(i).Append("CreatedAt:                   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                   ").Append(UpdatedAt)
                .Append(i).Append("Id_Machine:                  ").Append(Id_Machine)
                .Append(i).Append("Id_Field:                    ").Append(Id_Field)
                .Append(i).Append("Id_WeighingPlace:            ").Append(Id_WeighingPlace)
                .Append(i).Append("DepartureFromFieldTime:      ").Append(DepartureFromFieldTime)
                .Append(i).Append("Weight:                      ").Append(Weight)
                .Append(i).Append("BruttoWeigh:                 ").Append(BruttoWeigh)
                .Append(i).Append("SeedMoisture:                ").Append(SeedMoisture)
                .Append(i).Append("SeedAdmixture:               ").Append(SeedAdmixture)
                .Append(i).Append("WeighingTime:                ").Append(WeighingTime)
                .Append(i).Append("LastTruck:                   ").Append(LastTruck)
                .Append(i).Append("TrackLength:                 ").Append(TrackLength)
                .Append(i).Append("IsTrackLengthSetManually:    ").Append(IsTrackLengthSetManually)
                .Append(i).Append("AdditionalInfo:              ").Append(AdditionalInfo)
                .Append(i).Append("Description:                 ").Append(Description)
                .Append(i).Append("CreatedByUserId:             ").Append(CreatedByUserId)
                .Append(i).Append("Ids_UnloadedMachines:        ").Append(Ids_UnloadedMachines)
                .Append(i).Append("{");
            Int32 itemNo = 0;
            foreach (Int32 item in Ids_UnloadedMachines) sb.Append(i2).Append("item #: ").Append(++itemNo).Append(i2).AppendLine(item.ToString());
            sb
                .Append(i).Append("}");
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
