using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Map_MachineTask_AgroOperation : ICropioRegularObject
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

        /// <summary> Cropio ID of AgroOperation </summary>
        [JsonProperty("agro_operation_id")]
        public Int32 Id_AgroOperation { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                  ").Append(Id)
                .Append(i).Append("CreatedAt:           ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:           ").Append(UpdatedAt)
                .Append(i).Append("Id_MachineTask:      ").Append(Id_MachineTask)
                .Append(i).Append("Id_AgroOperation:    ").Append(Id_AgroOperation);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
