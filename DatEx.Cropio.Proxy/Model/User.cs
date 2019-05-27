using DatEx.Cropio.BaseAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatEx.Cropio.Proxy.Model
{
    public class User
    {
        public Int32 Id { get; set; }
        public String Id_External { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String MobilePhone { get; set; }
        public String Position { get; set; }
        public String Language { get; set; }
        public String TimeZone { get; set; }
        public String YieldUnits { get; set; }
        public CE_UserStatus Status { get; set; }
        public Boolean IsDispatcher { get; set; }
        public Boolean IsDriver { get; set; }
        public String Rfid { get; set; }
        public String AdditionalInfo { get; set; }
        public String Description { get; set; }
        public DateTime? CropioLastSignInAt { get; set; }
        public DateTime? CropioCurrentSignInAt { get; set; }
        public String AuthMethod { get; set; }   
        
        public static User FromCropioObj(CO_User e)
        {
            User obj = new User()
            {
                Id = e.Id,
                Id_External = e.Id_External,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt,
                UserName = e.UserName,
                Email = e.Email,
                Password = e.Password,
                MobilePhone = e.MobilePhone,
                Position = e.Position,
                Language = e.Language,
                TimeZone = e.TimeZone,
                YieldUnits = e.YieldUnits,
                Status = e.Status,
                IsDispatcher = e.IsDispatcher,
                IsDriver = e.IsDriver,
                Rfid = e.Rfid,
                AdditionalInfo = e.AdditionalInfo,
                Description = e.Description,
                CropioCurrentSignInAt = e.CropioCurrentSignInAt,
                CropioLastSignInAt = e.CropioLastSignInAt,
                AuthMethod = e.AuthMethod
            };
            return obj;
        }
    }
}
