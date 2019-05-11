using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Удобрение </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/group_folders.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// - ParentId      (group_folders.id в json)
    /// </remarks>
    [JsonObject(Title = "group_folders")]
    public class CO_GroupFolder : ICropioExtendetObject
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

        /// <summary> Id связанного объекта CO_GroupFolder (group_folders.id в json) </summary>
        [JsonProperty("parent_id")]
        public Int32? ParentId { get; set; }

        /// <summary> Название груповой папки </summary>
        [JsonProperty("name")]
        public String Name { get; set; }
        
        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:          ").Append(Id)
                .Append(i).Append("Id_External: ").Append(Id_External)
                .Append(i).Append("CreatedAt:   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:   ").Append(UpdatedAt)
                .Append(i).Append("ParentId:    ").Append(ParentId)
                .Append(i).Append("Name:        ").Append(Name);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
