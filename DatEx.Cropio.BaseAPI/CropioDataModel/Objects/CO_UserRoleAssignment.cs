using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "user_role_assignments")]
    public class CO_UserRoleAssignment : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of UserRoleAssignment </summary>
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

        /// <summary> Cropio ID of User </summary>
        [JsonProperty("user_id")]
        public Int32 Id_User { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:          ").Append(Id)
                .Append(i).Append("CreatedAt:   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:   ").Append(UpdatedAt)
                .Append(i).Append("Id_UserRole: ").Append(Id_UserRole)
                .Append(i).Append("Id_User:     ").Append(Id_User);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
