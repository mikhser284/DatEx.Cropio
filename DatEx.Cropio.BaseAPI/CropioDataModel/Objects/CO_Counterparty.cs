using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Counterparty : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of Counterparty </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("external_id")]
        public DateTime? Id_External { get; set; }

        /// <summary> time when object created </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>  </summary>
        [JsonProperty("first_name")]
        public DateTime? FirstName { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("middle_name")]
        public DateTime? MiddleName { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("last_name")]
        public DateTime? LastName { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("phone_number")]
        public DateTime? PhoneNumber { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("passport_code")]
        public DateTime? PassportCode { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("email")]
        public DateTime? Email { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("passport_issuing_date")]
        public DateTime? PassportIssuingDate { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("identification_code")]
        public DateTime? IdentificationCode { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("passport_issued_by")]
        public DateTime? PassportIssuedBy { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("passport_issuing_date_presence")]
        public DateTime? PassportIssuingDatePresence { get; set; }
        
        /// <summary> natural_person, legal_person, state </summary>
        [JsonProperty("counterparty_type")]
        public DateTime? CounterpartyType { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("street")]
        public DateTime? Street { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("region")]
        public DateTime? Region { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("locality")]
        public DateTime? Locality { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("district")]
        public DateTime? District { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("house_number")]
        public DateTime? HouseNumber { get; set; }
        
        /// <summary>  </summary>
        [JsonProperty("postcode")]
        public DateTime? Postcode { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                          ").Append(Id)
                .Append(i).Append("CreatedAt:                   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                   ").Append(UpdatedAt)
                .Append(i).Append("FirstName:                   ").Append(FirstName)
                .Append(i).Append("MiddleName:                  ").Append(MiddleName)
                .Append(i).Append("LastName:                    ").Append(LastName)
                .Append(i).Append("PhoneNumber:                 ").Append(PhoneNumber)
                .Append(i).Append("PassportCode:                ").Append(PassportCode)
                .Append(i).Append("Email:                       ").Append(Email)
                .Append(i).Append("PassportIssuingDate:         ").Append(PassportIssuingDate)
                .Append(i).Append("IdentificationCode:          ").Append(IdentificationCode)
                .Append(i).Append("PassportIssuedBy:            ").Append(PassportIssuedBy)
                .Append(i).Append("PassportIssuingDatePresence: ").Append(PassportIssuingDatePresence)
                .Append(i).Append("CounterpartyType:            ").Append(CounterpartyType)
                .Append(i).Append("Street:                      ").Append(Street)
                .Append(i).Append("Region:                      ").Append(Region)
                .Append(i).Append("Locality:                    ").Append(Locality)
                .Append(i).Append("District:                    ").Append(District)
                .Append(i).Append("HouseNumber:                 ").Append(HouseNumber)
                .Append(i).Append("Postcode:                    ").Append(Postcode);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
