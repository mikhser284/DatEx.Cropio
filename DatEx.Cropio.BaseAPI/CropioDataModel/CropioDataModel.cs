using System;
using System.Collections.Generic;

namespace DatEx.Cropio.BaseAPI
{
    public static class CropioDataModel
    {
        public static String Name<T>() where T : ICropioObject
        {
            return NameOfDatasource[typeof(T)];
        }

        public static String DocumentableObjectTypeName<T>() where T : ICropioDocumentableObject
        {
            return TypeNameOfDocumentableObject[typeof(T)];
        }

        internal static readonly Dictionary<Type, String> TypeNameOfDocumentableObject = new Dictionary<Type, string>
        {
            { typeof(CO_Alert), "Alert" }
        };

        internal static readonly Dictionary<Type, String> NameOfDatasource = new Dictionary<Type, String>()
        {                                                                                               // Implemented
            { typeof(CO_AdditionalObjects)             , "additional_objects" },                        //  
            { typeof(CO_AgriWorkPlan)                  , "agri_work_plans" },                           // ■ yes
            { typeof(CO_AgroOperation)                 , "agro_operations" },                           // ■ yes
            { typeof(CO_Alert)                         , "alerts" },                                    //  
            { typeof(CO_AlertType)                     , "alert_types" },                               //  
            { typeof(CO_AutomaticAlert)                , "automatic_alerts" },                          //  
            { typeof(CO_ApplicationMixItem)            , "application_mix_items" },                     // ■ yes
            { typeof(CO_Chemical)                      , "chemicals" },                                 // ■ yes
            { typeof(CO_Company)                       , "companies" },                                 //  
            { typeof(CO_Counterparty)                  , "counterparties" },                            //  
            { typeof(CO_Crop)                          , "crops" },                                     // ■ yes
            { typeof(CO_RegularObjectGpsLogger)        , "data_source_gps_loggers" },                   //  
            { typeof(CO_Fertilizer)                    , "fertilizers" },                               // ■ yes
            { typeof(CO_Field)                         , "fields" },                                    // ■ yes
            { typeof(CO_FieldGroup)                    , "field_groups" },                              // ■ yes
            { typeof(CO_FieldScoutReport)              , "field_scout_reports" },                       //  
            { typeof(CO_FieldShape)                    , "field_shapes" },                              // ■ yes
            { typeof(CO_GpsLogger)                     , "gps_loggers" },                               //  
            { typeof(CO_GroupFolder)                   , "group_folders" },                             // ■ yes
            { typeof(CO_HarvestWeighing)               , "harvest_weighings" },                         //  
            { typeof(CO_HistoricalValue)               , "historical_values" },                         //  
            { typeof(CO_History_ProductivityEstimate)  , "productivity_estimate_histories" },           //  
            { typeof(CO_History_Item)                  , "history_items" },                             //  
            { typeof(CO_History_InventoryItem)         , "inventory_history_items" },                   //  
            { typeof(CO_History_WeatherItem)           , "weather_history_items" },                     //  
            { typeof(CO_Implement)                     , "implements" },                                // ■ yes
            { typeof(CO_LandDocument)                  , "land_documents" },                            //  
            { typeof(CO_LandParcel)                    , "land_parcels" },                              //  
            { typeof(CO_Machine)                       , "machines" },                                  // ■ yes
            { typeof(CO_MachineGroup)                  , "machine_groups" },                            // ■ yes
            { typeof(CO_MachineRegion)                 , "machine_regions" },                           //  
            { typeof(CO_MachineTask)                   , "machine_tasks" },                             // ■ yes
            { typeof(CO_MaintenanceRecord)             , "maintenance_records" },                       //  
            { typeof(CO_Note)                          , "notes" },                                     //  
            { typeof(CO_Photo)                         , "photos" },                                    //  
            { typeof(CO_PlantThreat)                   , "plant_threats" },                             //  
            { typeof(CO_ProductivityEstimate)          , "productivity_estimates" },                    //  
            { typeof(CO_SatelliteImage)                , "satellite_images" },                          //  
            { typeof(CO_Security)                      , "security" },                                  //  
            { typeof(CO_Seed)                          , "seeds" },                                     // ■ yes
            { typeof(CO_User)                          , "users" },                                     // ■ yes
            { typeof(CO_UserRole)                      , "user_roles" },                                // ■ yes
            { typeof(CO_UserRoleAssignment)            , "user_role_assignments" },                     // * TODO
            { typeof(CO_UserRolePermission)            , "user_role_permissions" },                     // * TODO 
            { typeof(CO_Version)                       , "versions" },                                  //  
            { typeof(CO_WorkRecord)                    , "work_records" },                              //  
            { typeof(CO_WorkType)                      , "work_types" },                                // ■ yes
            { typeof(CO_WorkTypeGroup)                 , "work_type_groups" },                          // ■ yes
            { typeof(CO_Map_FieldScout_ReportThreat)   , "field_scout_report_threat_mapping_items" },   //  
            { typeof(CO_Map_FieldShape_LandParcel)     , "field_shape_land_parcel_mapping_items" },     //  
            { typeof(CO_Map_GpsLogger)                 , "gps_logger_mapping_items" },                  //  
            { typeof(CO_Map_Implement_Region)          , "implement_region_mapping_items" },            //  
            { typeof(CO_Map_LandDocument_LandParcel)   , "land_document_land_parcel_mapping_items" },   //  
            { typeof(CO_Map_MachineRegion)             , "machine_region_mapping_items" },              //  
            { typeof(CO_Map_MachineTask_AgroOperation) , "machine_task_agro_operation_mapping_items" }, //  
            { typeof(CO_Map_MachineTask_Field)         , "machine_task_field_mapping_items" },          //  
            { typeof(CO_Map_WorkRecord_MachineRegion)  , "work_record_machine_region_mapping_items" },  //  
            { typeof(CO_Mix_AgriWorkPlan_Application)  , "agri_work_plan_application_mix_items" },      //  
            { typeof(CO_Mix_Application)               , "application_mix_items" },                     //  
        };
    }
}
                                                                                                                                                                              