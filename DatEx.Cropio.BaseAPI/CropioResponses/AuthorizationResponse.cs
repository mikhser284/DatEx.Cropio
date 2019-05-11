using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "USER_API_TOKEN")]
    public class AuthorizationResponse : CropioServerResponse
    {
        [JsonProperty("success")]
        public Boolean Result_IsSuccess { get; set; }

        [JsonProperty("user_api_token")]
        public String UserApiToken { get; set; }

        [JsonProperty("user_id")]
        public Int32? UserId { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("username")]
        public String Username { get; set; }

        [JsonProperty("company")]
        public String Company { get; set; }

        [JsonProperty("time_zone")]
        public String TimeZone { get; set; }

        [JsonProperty("language")]
        public String Language { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Result_IsSuccess: ").Append(Result_IsSuccess)
                .Append(i).Append("Result_Status:    ").Append(Result_Status)
                .Append(i).Append("Result_Error:     ").Append(Result_Error)
                .Append(i).Append("Result_Message:   ").Append(Result_Message)
                .Append(i).Append("UserApiToken:     ").Append(UserApiToken)
                .Append(i).Append("Id_User:           ").Append(UserId)
                .Append(i).Append("Email:            ").Append(Email)
                .Append(i).Append("Username:         ").Append(Username)
                .Append(i).Append("Company:          ").Append(Company)
                .Append(i).Append("TimeZone:         ").Append(TimeZone)
                .Append(i).Append("Language:         ").Append(Language);
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }
}
