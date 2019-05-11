using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Группа полей </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/field_groups.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// - Id_GroupFolder   (group_folders.id в json) 
    /// </remarks>
    [JsonObject(Title = "field_groups")]
    public class CO_FieldGroup : ICropioExtendetObject
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
        [JsonProperty("group_folder_id")]
        public Int32? Id_GroupFolder { get; set; }

        /// <summary> Название группы полей </summary>
        [JsonProperty("name")]
        public String Name { get; set; }
        
        /// <summary> Описание </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> Административная область (например: страна, штат, район) </summary>
        [JsonProperty("administrative_area_name")]
        public String AdministrativeAreaName { get; set; }

        /// <summary> Субадминистративная область (например: регион, и т.п.) </summary>
        [JsonProperty("subadministrative_area_name")]
        public String SubadministrativeAreaName { get; set; }

        /// <summary> Местонахождение (например: город, деревня, и т.п.) </summary>
        [JsonProperty("locality")]
        public String Locality { get; set; }
        
        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                          ").Append(Id)
                .Append(i).Append("Id_External:                 ").Append(Id_External)
                .Append(i).Append("CreatedAt:                   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                   ").Append(UpdatedAt)
                .Append(i).Append("Id_GroupFolder:              ").Append(Id_GroupFolder)
                .Append(i).Append("Name:                        ").Append(Name)
                .Append(i).Append("Description:                 ").Append(Description)
                .Append(i).Append("AdministrativeAreaName:      ").Append(AdministrativeAreaName)
                .Append(i).Append("SubadministrativeAreaName:   ").Append(SubadministrativeAreaName)
                .Append(i).Append("Locality:                    ").Append(Locality);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }

}
