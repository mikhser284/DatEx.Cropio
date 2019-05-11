using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_UserRolePermission : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of UserRolePermission </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> Cropio ID of UserRole </summary>
        [JsonProperty("user_role_id")]
        public Int32 Id_UserRole { get; set; }

        /// <summary> access level: no_access, read, manage, full_access </summary>
        [JsonConverter(typeof(JsonConverter_AccessLevel))]
        [JsonProperty("access_level")]
        public CE_AccessLevel AccessLevel { get; set; }


        /// <summary> upe of permission: fields, machinery </summary>
        [JsonConverter(typeof(JsonConverter_AccessFor))]
        [JsonProperty("access_for")]
        public CE_AccessFor AccessFor { get; set; }

        /// <summary> type of subject: FieldGroup, MachineRegion </summary>
        [JsonConverter(typeof(JsonConverter_UserRolePermissionSubjectType))]
        [JsonProperty("subject_type")]
        public CE_UserRolePermissionSubjectType SubjectType { get; set; }

        /// <summary> Cropio ID of subject (field group or machine region) </summary>
        [JsonProperty("subject_id")]
        public Int32 Id_Subject { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:          ").Append(Id)
                .Append(i).Append("CreatedAt:   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:   ").Append(UpdatedAt)
                .Append(i).Append("AccessLevel: ").Append(AccessLevel)
                .Append(i).Append("AccessFor:   ").Append(AccessFor)
                .Append(i).Append("SubjectType: ").Append(SubjectType)
                .Append(i).Append("Id_Subject:  ").Append(Id_Subject);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
