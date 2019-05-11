using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_LandDocument : ICropioExtendetObject
    {
        //Not implemented - Не реализовано полностью (см. офиц. документацию)
        //Not tested

        /// <summary> Cropio ID of LandDocument </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> Cropio ID of LandDocument </summary>
        [JsonProperty("external_id")]
        public String Id_External { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> date of document </summary>
        [JsonProperty("document_date")]
        public DateTime DocumentDate { get; set; }

        /// <summary> document type: 'sold', 'rented','subrented', 'rented_out', 'subrented_out', 'purchased', 'exchange' </summary>
        [JsonProperty("document_type")]
        public String DocumentType { get; set; }

        /// <summary> document subtype (can be empty): rented - fixed_in_currency, natural, in_dollars, fixed_in_percents_to_nmv </summary>
        [JsonProperty("document_subtype")]
        public String DocumentSubtype { get; set; }

        /// <summary> agent name </summary>
        [JsonProperty("agent")]
        public String Agent { get; set; }

        /// <summary> document start date </summary>
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        /// <summary> document end date </summary>
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        /// <summary> some additional info </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        /// <summary> some description </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> document number </summary>
        [JsonProperty("document_number")]
        public String DocumentNumber { get; set; }

        /// <summary> document version </summary>
        [JsonProperty("document_version")]
        public String DocumentVersion { get; set; }

        /// <summary> can be: empty, signed, registered </summary>
        [JsonProperty("document_status")]
        public String DocumentStatus { get; set; }

        /// <summary> normative monetary value </summary>
        [JsonProperty("normative_monetary_value")]
        public String NormativeMonetaryValue { get; set; }

        /// <summary> year of normative monetary value </summary>
        [JsonProperty("year_of_nmv")]
        public Int32? NMV_Year { get; set; }

        /// <summary> normative monetary value currency ('USD', 'EUR', 'RUB', 'UAH') </summary>
        [JsonProperty("nmv_currency")]
        public String NMV_Currency { get; set; }

        /// <summary> price per year </summary>
        [JsonProperty("price_per_year")]
        public Single? PricePerYear { get; set; }

        /// <summary> price per year currency ('USD', 'EUR', 'RUB', 'UAH') </summary>
        [JsonProperty("price_per_year_currency")]
        public String PricePerYear_Currency { get; set; }

        /// <summary> document price </summary>
        [JsonProperty("price")]
        public String Price { get; set; }

        /// <summary> document price currency (see available currencies below) </summary>
        [JsonProperty("currency")]
        public String Currency { get; set; }

        /// <summary> share of land in percents (from 0 to 100) </summary>
        [JsonProperty("share_of_land")]
        public String ShareOfLand { get; set; }

        /// <summary> can be: empty, [certificate], [state_act], [certificate_of_ownership] </summary>
        [JsonProperty("ownership_of_land_type")]
        public String OwnershipOfLandType { get; set; }

        /// <summary> location of document </summary>
        [JsonProperty("location")]
        public String Location { get; set; }

        /// <summary> array ids of counterparties </summary>
        [JsonProperty("counterparty_ids")]
        public List<Int32> Ids_Counterparty { get; set; }

        /// <summary> array ids of own land parcels, for [exchange] document type </summary>
        [JsonProperty("own_land_parcel_ids")]
        public List<Int32> Ids_OwnLandParcel { get; set; }

        /// <summary> array ids of counterparties land parcels, for [exchange] document type </summary>
        [JsonProperty("counterparty_land_parcel_ids")]
        public List<Int32> Ids_CounterpartyLandParcel { get; set; }

        /// <summary> array of protected documents (some photo, pdf, etc.). See below </summary>
        [JsonProperty("protected_documents")]
        public String[] ProtectedDocuments { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                          ").Append(Id)
                .Append(i).Append("CreatedAt:                   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                   ").Append(UpdatedAt)
                .Append(i).Append("DocumentDate:                ").Append(DocumentDate)
                .Append(i).Append("DocumentType:                ").Append(DocumentType)
                .Append(i).Append("DocumentSubtype:             ").Append(DocumentSubtype)
                .Append(i).Append("Agent:                       ").Append(Agent)
                .Append(i).Append("StartDate:                   ").Append(StartDate)
                .Append(i).Append("EndDate:                     ").Append(EndDate)
                .Append(i).Append("AdditionalInfo:              ").Append(AdditionalInfo)
                .Append(i).Append("Description:                 ").Append(Description)
                .Append(i).Append("DocumentNumber:              ").Append(DocumentNumber)
                .Append(i).Append("DocumentVersion:             ").Append(DocumentVersion)
                .Append(i).Append("DocumentStatus:              ").Append(DocumentStatus)
                .Append(i).Append("NormativeMonetaryValue:      ").Append(NormativeMonetaryValue)
                .Append(i).Append("NMV_Year:                    ").Append(NMV_Year)
                .Append(i).Append("NMV_Currency:                ").Append(NMV_Currency)
                .Append(i).Append("PricePerYear:                ").Append(PricePerYear)
                .Append(i).Append("PricePerYear_Currency:       ").Append(PricePerYear_Currency)
                .Append(i).Append("Price:                       ").Append(Price)
                .Append(i).Append("Price:                       ").Append(Price)
                .Append(i).Append("Currency:                    ").Append(Currency)
                .Append(i).Append("ShareOfLand:                 ").Append(ShareOfLand)
                .Append(i).Append("OwnershipOfLandType:         ").Append(OwnershipOfLandType)
                .Append(i).Append("Location:                    ").Append(Location)
                .Append(i).Append("Ids_Counterparty:            ").Append(Ids_Counterparty)
                .Append(i).Append("Ids_OwnLandParcel:           ").Append(Ids_OwnLandParcel)
                .Append(i).Append("Ids_CounterpartyLandParcel:  ").Append(Ids_CounterpartyLandParcel)
                .Append(i).Append("ProtectedDocuments:          ").Append(ProtectedDocuments);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
