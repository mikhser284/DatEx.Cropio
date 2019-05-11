using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "users")]
    public class CO_User : ICropioExtendetObject
    {
        //Not tested

        /// <summary> Cropio ID of Field </summary>
        /// <remarks> In ELMA: Int32 Id_InCropio (Id в Cropio)</remarks>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary>  </summary>
        /// <remarks> In ELMA: Guid Uid (Уникальный идентификатор) </remarks>
        [JsonProperty("external_id")]
        public String Id_External { get; set; }

        /// <summary> Server time when object was created </summary>
        /// <remarks> In ELMA: DateTime CreatedAt (Дата создания)</remarks>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Server time when object was updated </summary>
        /// <remarks> In ELMA: DateTime? UpdatedAt (Дата обновления)</remarks>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> user name </summary>
        /// <remarks> In ELMA: String UserName (Имя пользователя) </remarks>
        [JsonProperty("username")]
        public String UserName { get; set; }

        /// <summary> email (that is using as login) </summary>
        /// <remarks> In ELMA: String Email (Email) </remarks>
        [JsonProperty("email")]
        public String Email { get; set; }
        
        /// <summary> password (!!! writeonly field) </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("password")]
        public String Password { get; set; }
        
        /// <summary> mobile phone </summary>
        /// <remarks> In ELMA: String MobilePhone (Мобильный тел.) </remarks>
        [JsonProperty("mobile_phone")]
        public String MobilePhone { get; set; }
        
        /// <summary> avatar </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("avatar")]
        [JsonConverter(typeof(JsonAvatarConverter))]
        public Avatar Avatar { get; set; }

        /// <summary> position </summary>
        /// <remarks> In ELMA: String Position (Должность) </remarks>
        [JsonProperty("position")]
        public String Position { get; set; }
        
        /// <summary> language: English: 'en', Русский: 'ru', Português: 'pt', Français: 'fr', Español: 'es', Română: 'ro' </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("language")]
        public String Language { get; set; }

        /// <summary> time zone (e.g. "Kyiv") </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("time_zone")]
        public String TimeZone { get; set; }
        
        /// <summary> yield units: 'tonn_per_ha', '100kg_per_ha' </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("yield_units")]
        public String YieldUnits { get; set; }

        /// <summary> status: 'no_access', 'user', 'admin' </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("status")]
        public String Status { get; set; }

        /// <summary> is dispetcher? (true/false) </summary>
        /// <remarks> In ELMA: Boolean IsDispatcher (Диспетчер) </remarks>
        [JsonProperty("dispatcher")]
        public Boolean IsDispatcher { get; set; }

        /// <summary> is driver: true/false </summary>
        /// <remarks> In ELMA: Boolean IsDriver (Является водителем) </remarks>
        [JsonProperty("driver")]
        public Boolean IsDriver { get; set; }

        /// <summary> RFID, iButton or another unique identification key. Only 0-9 and A-F letters </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("rfid")]
        public String Rfid { get; set; }

        /// <summary> your system info </summary>
        /// <remarks> In ELMA: String AdditionalInfo (Дополнительная информация) </remarks>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        /// <summary> description </summary>
        /// <remarks> In ELMA: String Description (Описание) </remarks>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> time of last sign in to Cropio </summary>
        /// <remarks> In ELMA: DateTime? CropioLastSignInAt (Дата последнего входа в систему Cropio) </remarks>
        [JsonProperty("last_sign_in_at")]
        public DateTime? CropioLastSignInAt { get; set; }

        /// <summary> time of current sign in to Cropio </summary>
        /// <remarks> In ELMA: DateTime? CropioCurrentSignInAt (Дата текущего входа в систему Cropio) </remarks>
        [JsonProperty("current_sign_in_at")]
        public DateTime? CropioCurrentSignInAt { get; set; }

        /// <summary>  </summary>
        /// <remarks> In ELMA: — </remarks>
        [Obsolete("Property not described in oficial API documentations")]
        [JsonProperty("auth_method")]
        public String AuthMethod { get; set; }

        /// <summary>  </summary>
        /// <remarks> In ELMA: — </remarks>
        [Obsolete("Property not described in oficial API documentations")]
        [JsonProperty("units_table")]
        public Units_Table UnitsTable { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("IdExternal:      ").Append(Id_External)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Username:        ").Append(UserName)
                .Append(i).Append("Email:           ").Append(Email)
                .Append(i).Append("Password:        ").Append(Password)
                .Append(i).Append("MobilePhone:     ").Append(MobilePhone)
                .Append(i).Append("Avatar:          ").Append(Avatar.ToString(indentLevel + 1))
                .Append(i).Append("Position:        ").Append(Position)
                .Append(i).Append("Language:        ").Append(Language)
                .Append(i).Append("TimeZone:        ").Append(TimeZone)
                .Append(i).Append("YieldUnits:      ").Append(YieldUnits)
                .Append(i).Append("Status:          ").Append(Status)
                .Append(i).Append("IsDispatcher:    ").Append(IsDispatcher)
                .Append(i).Append("IsDriver:        ").Append(IsDriver)
                .Append(i).Append("Rfid:            ").Append(Rfid)
                .Append(i).Append("AdditionalInfo:  ").Append(AdditionalInfo)
                .Append(i).Append("Description:     ").Append(Description)
                .Append(i).Append("LastSignInAt:    ").Append(CropioLastSignInAt)
                .Append(i).Append("CurrentSignInAt: ").Append(CropioCurrentSignInAt)
                .Append(i).Append("AuthMethod:      ").Append(AuthMethod)
                .Append(i).Append("UnitsTable:      ").Append(UnitsTable.ToString(indentLevel + 1));
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }

    public class Units_Table
    {
        [JsonProperty("area")]
        public String Area { get; set; }

        [JsonProperty("depth")]
        public String Depth { get; set; }

        [JsonProperty("fuel_consumption")]
        public String FuelConsumption { get; set; }

        [JsonProperty("length")]
        public String Length { get; set; }

        [JsonProperty("machinery_weight")]
        public String MachineryWeight { get; set; }

        [JsonProperty("plant_spacing")]
        public String PlantSpacing { get; set; }

        [JsonProperty("precipitation_level")]
        public String PrecipitationLevel { get; set; }

        [JsonProperty("productivity")]
        public String Productivity { get; set; }

        [JsonProperty("row_spacing")]
        public String RowSpacing { get; set; }

        [JsonProperty("short_length")]
        public String ShortLength { get; set; }

        [JsonProperty("speed")]
        public String Speed { get; set; }

        [JsonProperty("tank_volume")]
        public String TankVolume { get; set; }

        [JsonProperty("temperature")]
        public String Temperature { get; set; }

        [JsonProperty("volume")]
        public String Volume { get; set; }

        [JsonProperty("water_rate")]
        public String WaterRate { get; set; }

        [JsonProperty("weight")]
        public String Weight { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Area:                ").Append(Area)
                .Append(i).Append("Depth:               ").Append(Depth)
                .Append(i).Append("FuelConsumption:     ").Append(FuelConsumption)
                .Append(i).Append("Length:              ").Append(Length)
                .Append(i).Append("MachineryWeight:     ").Append(MachineryWeight)
                .Append(i).Append("PlantSpacing:        ").Append(PlantSpacing)
                .Append(i).Append("PrecipitationLevel:  ").Append(PrecipitationLevel)
                .Append(i).Append("Productivity:        ").Append(Productivity)
                .Append(i).Append("RowSpacing:          ").Append(RowSpacing)
                .Append(i).Append("ShortLength:         ").Append(ShortLength)
                .Append(i).Append("Speed:               ").Append(Speed)
                .Append(i).Append("TankVolume:          ").Append(TankVolume)
                .Append(i).Append("Temperature:         ").Append(Temperature)
                .Append(i).Append("Volume:              ").Append(Volume)
                .Append(i).Append("WaterRate:           ").Append(WaterRate)
                .Append(i).Append("Weight:              ").Append(Weight);
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    [JsonConverter(typeof(JsonAvatarConverter))]
    public class Avatar
    {
        public String Url { get; set; }
        public String AvatarTiny { get; set; }
        public String AvatarSmall { get; set; }
        public String AvatarMid { get; set; }
        public String AvatarLarge { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Url:         ").Append(Url)
                .Append(i).Append("AvatarTiny:  ").Append(AvatarTiny)
                .Append(i).Append("AvatarSmall: ").Append(AvatarSmall)
                .Append(i).Append("AvatarMid:   ").Append(AvatarMid)
                .Append(i).Append("AvatarLarge: ").Append(AvatarLarge);
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    public class JsonAvatarConverter : JsonConverter
    {
        public override Boolean CanConvert(Type objectType)
        {
            return objectType == typeof(Avatar);
        }

        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null) return String.Empty;

            JObject obj = JObject.Load(reader);
            JToken root = obj["avatar"];

            return new Avatar()
            {
                Url = (String)root["url"],
                AvatarTiny = (String)root["avatar_tiny"]["url"],
                AvatarSmall = (String)root["avatar_small"]["url"],
                AvatarMid = (String)root["avatar_mid"]["url"],
                AvatarLarge = (String)root["avatar_large"]["url"]
            };
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
