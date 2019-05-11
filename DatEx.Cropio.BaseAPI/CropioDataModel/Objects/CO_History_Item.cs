using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_History_Item : ICropioExtendetObject
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

        /// <summary> Cropio ID of related Field </summary>
        /// <remarks> 
        /// In ELMA: Cropio_Field Field (Поле) 
        /// In ELMA: Int64 Id_Field (Id_Field) 
        /// </remarks>
        [JsonProperty("field_id")]
        public Int32 Id_Field { get; set; }

        /// <summary> year </summary>
        /// <remarks> In ELMA: Int64 Year (Год) </remarks>
        [JsonProperty("year")]
        public Int32 Year { get; set; }

        /// <summary> is this item active </summary>
        /// <remarks> In ELMA: Boolean IsActive (Активно) </remarks>
        [JsonProperty("active")]
        public Boolean IsActive { get; set; }

        /// <summary> Cropio ID of the Crop </summary>
        /// <remarks>
        /// In ELMA: Cropio_Crop Crop (Культура)
        /// In ELMA: Int64 Id_Crop (Id_Crop)
        /// </remarks>
        [JsonProperty("crop_id")]
        public Int32? Id_Crop { get; set; }

        /// <summary> variety </summary>
        /// <remarks> In ELMA: String Variety (Сорт) </remarks>
        [JsonProperty("variety")]
        public String Variety { get; set; }

        /// <summary> till type </summary>
        /// <remarks> In ELMA: String TillType (Обработка почвы) </remarks>
        [JsonProperty("till_type")]
        public String TillType { get; set; }

        /// <summary> productivity </summary>
        /// <remarks> In ELMA: Double? Productivity (Урожайность [ц/га]) </remarks>
        [JsonProperty("productivity")]
        public Single? Productivity { get; set; }

        /// <summary> productivity estimate </summary>
        /// <remarks> In ELMA: Double? ProductivityEstimate (Оценка урожайности [ц/га]) </remarks>
        [JsonProperty("productivity_estimate")]
        public Single? ProductivityEstimate { get; set; }

        /// <summary> date of the sowing </summary>
        /// <remarks> In ELMA: DateTime? SowingDate (Дата сева) </remarks>
        [JsonProperty("sowing_date")]
        public DateTime? SowingDate { get; set; }

        /// <summary> date of the harvesting </summary>
        /// <remarks> In ELMA:  DateTime? HarvestingDate (Дата уборки) </remarks>
        [JsonProperty("harvesting_date")]
        public DateTime? HarvestingDate { get; set; }

        /// <summary> description </summary>
        /// <remarks> In ELMA: String Description (Описание) </remarks>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> some additional info from user </summary>
        /// <remarks> In ELMA: String AdditionalInfo (Дополнительная информация) </remarks>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                      ").Append(Id)
                .Append(i).Append("Id_External:             ").Append(Id_External)
                .Append(i).Append("CreatedAt:               ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:               ").Append(UpdatedAt)
                .Append(i).Append("Id_Field:                ").Append(Id_Field)
                .Append(i).Append("Year:                    ").Append(Year)
                .Append(i).Append("IsActive:                ").Append(IsActive)
                .Append(i).Append("Id_Crop:                 ").Append(Id_Crop)
                .Append(i).Append("Variety:                 ").Append(Variety)
                .Append(i).Append("TillType:                ").Append(TillType)
                .Append(i).Append("Productivity:            ").Append(Productivity)
                .Append(i).Append("ProductivityEstimate:    ").Append(ProductivityEstimate)
                .Append(i).Append("SowingDate:              ").Append(SowingDate)
                .Append(i).Append("HarvestingDate:          ").Append(HarvestingDate) 
                .Append(i).Append("Description:             ").Append(Description)
                .Append(i).Append("AdditionalInfo:          ").Append(AdditionalInfo);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }

}
