using DatEx.Cropio.BaseAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEx.Cropio.CUI
{
    class View_Field
    {
        public String AdministrativeAreaName               { get; set; }
        public Single CalculatedArea                       { get; set; }
        public String Description                          { get; set; }
        public Int32 Id                                    { get; set; }
        public Int32 Id_FieldGroup                         { get; set; }
        public Single? LegalArea                           { get; set; }
        public String Locality                             { get; set; }
        public String Name                                 { get; set; }
        public String SubadministrativeAreaName            { get; set; }
        public Single? TillableArea                        { get; set; }
        public String FieldsGroupDescription               { get; set; }
        public Int32? Id_FieldsGroupFolder                  { get; set; }
        public String FieldsGroupName                      { get; set; }
        public String FieldsGroupSubadministrativeAreaName { get; set; }
        public Int32? Id_Crop                              { get; set; }
        public Boolean HistoryItemIsActive                 { get; set; }
        public String HistoryItemVariety                   { get; set; }
        public String HistoryItemDescription               { get; set; }
        public String CropName                             { get; set; }
        public String CropShortName                        { get; set; }
        public CE_CropStandardName? CropStandardName       { get; set; }

        public override string ToString()
        {
            String str = ""
                + $"{Id,5} | {FieldsGroupName,-25} | {Name,-15} | {LegalArea,7} га. | {TillableArea,7} га. | {CalculatedArea,7} га. | {Description, -50} | {CropName,-25} | {HistoryItemVariety,-25}" ;
            String view = ""
                + $"\n FieldsGroupName:                      {FieldsGroupName}"
                + $"\n Name:                                 {Name}"
                + $"\n LegalArea:                            {LegalArea}"
                + $"\n TillableArea:                         {TillableArea}"
                + $"\n CalculatedArea:                       {CalculatedArea}"
                + $"\n Description:                          {Description}"
                + $"\n CropName:                             {CropName}"
                + $"\n HistoryItemVariety:                   {HistoryItemVariety}"
                + $"\n CropShortName:                        {CropShortName}"
                + $"\n CropStandardName:                     {CropStandardName}"
                + $"\n AdministrativeAreaName:               {AdministrativeAreaName}"
                + $"\n SubadministrativeAreaName:            {SubadministrativeAreaName}"
                + $"\n Locality:                             {Locality}"
                + $"\n FieldsGroupDescription:               {FieldsGroupDescription}"
                + $"\n FieldsGroupSubadministrativeAreaName: {FieldsGroupSubadministrativeAreaName}"
                + $"\n HistoryItemIsActive:                  {HistoryItemIsActive}"
                + $"\n HistoryItemDescription:               {HistoryItemDescription}"
                + $"\n Id:                                   {Id}"
                + $"\n Id_FieldGroup:                        {Id_FieldGroup}"
                + $"\n Id_Crop:                              {Id_Crop}"
                + $"\n Id_FieldsGroupFolder:                 {Id_FieldsGroupFolder}"
                ;
            return str;
        }
    }
}
