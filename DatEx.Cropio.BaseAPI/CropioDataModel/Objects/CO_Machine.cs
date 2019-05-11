using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Машина </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/machines.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// - Id_MachineGroup -> CO_MachineGroup.Id   (В JSON machine_group_id -> machine_groups.id)
    /// - Id_DefaultImplement -> CO_Implement.Id  (В JSON default_implement_id -> implements.id)
    /// </remarks>
    [JsonObject(Title = "machines")]
    public class CO_Machine : ICropioExtendetObject
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

        /// <summary> Название машины </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> Пользовательское название машины. (В случае если пользовательское название машины не задано оно формируется как 'Производитель' + 'Модель' </summary>
        [JsonProperty("custom_name")]
        public String CustomName { get; set; }

        /// <summary> Модель </summary>
        [JsonProperty("model")]
        public String Model { get; set; }

        /// <summary> Производитель </summary>
        [JsonProperty("manufacture")]
        public String Manufacturer { get; set; }

        /// <summary> Год выпуска </summary>
        [JsonProperty("year")]
        public Int32? Year { get; set; }

        /// <summary> Регистрационный номер </summary>
        [JsonProperty("registration_number")]
        public String RegistrationNumber { get; set; }

        /// <summary> Инвентарный номер </summary>
        [JsonProperty("inventory_number")]
        public String InventoryNumber { get; set; }

        /// <summary> Id связанного объекта CO_MachineGroup (machine_groups.id в json) </summary>
        [JsonProperty("machine_group_id")]
        public String Id_MachineGroup { get; set; }

        /// <summary> Тип машины (Принимает значания: 'agri', 'transport') </summary>
        [JsonConverter(typeof(JsonConverter_TypeOfMachine))]
        [JsonProperty("machine_type")]
        public CE_TypeOfMachine MachineType { get; set; }

        /// <summary> Подтип машины (Принимает значения: 'lorrie', 'tipper', 'car', 'fuel_bowser', 'harvester', 
        /// 'sprayer', 'tractor', 'buldozer', 'telehandler', 'maintenance', 'minibus', 'truck_crane', 'other') </summary>
        [JsonConverter(typeof(JsonConverter_SybtypeOfMachine))]
        [JsonProperty("machine_subtype")]
        public CE_SybtypeOfMachine? MachineSubtype { get; set; }

        /// <summary> Аватар </summary>
        [JsonProperty("avatar_id")]
        //[JsonConverter(typeof(JsonAvatarConverter))]
        public Int32 Id_Avatar { get; set; }

        /// <summary> Серийный номер шасси </summary>
        [JsonProperty("chassis_serial_number")]
        public String SerialNumberOfChassis { get; set; }

        /// <summary> Серийный номер двигателя </summary>
        [JsonProperty("engine_serial_number")]
        public String SerialNumberOfEngine { get; set; }

        /// <summary> Мощность двигателя (ед. изм. ?) </summary>
        [JsonProperty("engine_power")]
        public Single? EnginePower { get; set; }

        /// <summary> Тип топлива (Принимает значения: 'gas', 'diesel', 'natural_gas', 'other') </summary>
        [JsonConverter(typeof(JsonConverter_TypeOfFuel))]
        [JsonProperty("fuel_type")]
        public CE_TypeOfFuel FuelType { get; set; }

        /// <summary> Объем топливного бака </summary>
        [JsonProperty("fuel_tank_size")]
        public Single? FuelTankSize { get; set; }

        /// <summary> Нормальный расход топлива </summary>
        [JsonProperty("fuel_consumption_norm")]
        public Single? FuelConsumptionNorm { get; set; }

        /// <summary> Компания </summary>
        [JsonProperty("legal_company")]
        public String LegalCompany { get; set; }

        /// <summary> Описание </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> Id связанного объекта CO_Implement (implements.id в json) </summary>
        [JsonProperty("default_implement_id")]
        public String Id_DefaultImplement { get; set; }

        /// <summary> Дополнительно 1 (Сериализированные данные) </summary>
        [JsonProperty("additional_1")]
        public String Additional_1 { get; set; }

        /// <summary> Дополнительно 2 (Сериализированные данные) </summary>
        [JsonProperty("additional_2")]
        public String Additional_2 { get; set; }

        /// <summary> Дополнительная информация </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                    ").Append(Id)
                .Append(i).Append("Id_External:           ").Append(Id_External)
                .Append(i).Append("CreatedAt:             ").Append(CreatedAt.F("yyyy.MM.dd HH:mm:ss"))
                .Append(i).Append("UpdatedAt:             ").Append(UpdatedAt.F("yyyy.MM.dd HH:mm:ss"))
                .Append(i).Append("Name:                  ").Append(Name)
                .Append(i).Append("CustomName:            ").Append(CustomName)
                .Append(i).Append("Model:                 ").Append(Model)
                .Append(i).Append("Manufacturer:          ").Append(Manufacturer)
                .Append(i).Append("Year:                  ").Append(Year)
                .Append(i).Append("RegistrationNumber:    ").Append(RegistrationNumber)
                .Append(i).Append("InventoryNumber:       ").Append(InventoryNumber)
                .Append(i).Append("Id_MachineGroup:       ").Append(Id_MachineGroup)
                .Append(i).Append("MachineType:           ").Append(MachineType)
                .Append(i).Append("MachineSubtype:        ").Append(MachineSubtype)
                .Append(i).Append("Id_Avatar:             ").Append(Id_Avatar)
                .Append(i).Append("SerialNumberOfChassis: ").Append(SerialNumberOfChassis)
                .Append(i).Append("SerialNumberOfEngine:  ").Append(SerialNumberOfEngine)
                .Append(i).Append("EnginePower:           ").Append(EnginePower.F("0.00"))
                .Append(i).Append("FuelType:              ").Append(FuelType)
                .Append(i).Append("FuelTankSize:          ").Append(FuelTankSize.F("0.00"))
                .Append(i).Append("FuelConsumptionNorm:   ").Append(FuelConsumptionNorm.F("0.00"))
                .Append(i).Append("LegalCompany:          ").Append(LegalCompany)
                .Append(i).Append("Description:           ").Append(Description)
                .Append(i).Append("Id_DefaultImplement:   ").Append(Id_DefaultImplement)
                .Append(i).Append("Additional_1:          ").Append(Additional_1)
                .Append(i).Append("Additional_2:          ").Append(Additional_2)
                .Append(i).Append("AdditionalInfo:        ").Append(AdditionalInfo);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
