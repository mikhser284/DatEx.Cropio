using DatEx.Cropio.BaseAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatEx.Cropio.Proxy.Model
{
    public class Alert
    {
        public Int32 Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Int32 Id_AlertType { get; set; }
        public Int32 Id_AlertableObject { get; set; }
        public String AlertableObjectType { get; set; }
        public DateTime EventStartTime { get; set; }
        public CE_StatusOfAllert Status { get; set; }
        public String Description { get; set; }
        public Int32? Id_ResponsiblePerson { get; set; }
        public Int32? Id_CreatedByUser { get; set; }
        public User CreatedByUser { get; set; }
        public DateTime? EventStopTime { get; set; }
        public DateTime? AlertClosedAt { get; set; }
        public Int32? Id_AutomaticAlert { get; set; }


        public static Alert FromCropioObj(CO_Alert co)
        {
            Alert e = new Alert()
            {
                Id = co.Id,
                CreatedAt = co.CreatedAt,
                UpdatedAt = co.UpdatedAt,
                Id_AlertType = co.Id_AlertType,
                Id_AlertableObject = co.Id_AlertableObject,
                AlertableObjectType = co.AlertableObjectType,
                EventStartTime = co.EventStartTime,
                Status = co.Status,
                Description = co.Description,
                Id_ResponsiblePerson = co.Id_ResponsiblePerson,
                Id_CreatedByUser = co.Id_CreatedByUser,
                EventStopTime = co.EventStopTime,
                AlertClosedAt = co.AlertClosedAt,
                Id_AutomaticAlert = co.Id_AutomaticAlert
            };
            return e;
        }
    }
}
