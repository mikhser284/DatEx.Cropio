using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_SatelliteImage : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of SatelliteImage </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> md5 digest for image </summary>
        [JsonProperty("md5")]
        public String Md5 { get; set; }

        /// <summary> Cropio type of item: "FieldGroup", "Field" </summary>
        [JsonProperty("item_type")]
        public String ItemType { get; set; }

        /// <summary> Cropio ID of item (FieldGroup, Field) </summary>
        [JsonProperty("item_id")]
        public Int32 Id_Item { get; set; }

        /// <summary> image size </summary>
        [JsonProperty("size")]
        public Single Size { get; set; }

        /// <summary> image date </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary> data coverage (0.0 – 1.0) </summary>
        [JsonProperty("data_coverage")]
        public Single DataCoverage { get; set; }

        /// <summary> coverage by clouds (0.0 – 1.0) </summary>
        [JsonProperty("clouds_coverage")]
        public Single CloudsCoverage { get; set; }

        /// <summary> coverage by cirrus clouds (0.0 – 1.0) </summary>
        [JsonProperty("cirrus_coverage")]
        public Single CirrusCoverage { get; set; }

        /// <summary> source of image (satellite code name) </summary>
        [JsonProperty("source_sign")]
        public String SourceSign { get; set; }

        /// <summary> image type ('ndvi', 'groups') </summary>
        [JsonProperty("image_type")]
        public String ImageType { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Md5:             ").Append(Md5)
                .Append(i).Append("ItemType:        ").Append(ItemType)
                .Append(i).Append("Id_Item:         ").Append(Id_Item)
                .Append(i).Append("Size:            ").Append(Size)
                .Append(i).Append("Date:            ").Append(Date)
                .Append(i).Append("DataCoverage:    ").Append(DataCoverage)
                .Append(i).Append("CloudsCoverage:  ").Append(CloudsCoverage)
                .Append(i).Append("CirrusCoverage:  ").Append(CirrusCoverage)
                .Append(i).Append("SourceSign:      ").Append(SourceSign)
                .Append(i).Append("ImageType:       ").Append(ImageType);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
