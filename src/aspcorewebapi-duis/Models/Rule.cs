using System;
using aspcorewebapi_duis.Enums;

namespace aspcorewebapi_duis.Models
{
    public class Rule
    {
        public int ID { get; set; }
        private string _applicationName { get; set; }
        public string ApplicationName
        {
            get { return _applicationName.ToLower().Trim(); }
            set { _applicationName = value.ToLower().Trim(); }
        }
        private string _controller { get; set; }
        public string Controller
        {
            get { return Helpers.ControllersHelper.RemoveVersionFromControllerName(_controller.ToLower().Trim()); }
            set { _controller = Helpers.ControllersHelper.RemoveVersionFromControllerName(value.ToLower().Trim()); }
        }
        public int? DuisId { get; set; }
        public DuisEnum DuisEnum
        {
            get
            {
                if (Enum.IsDefined(typeof(DuisEnum), DuisId))
                {
                    return (DuisEnum)DuisId;
                }
                else
                {
                    return DuisEnum.None;
                }
            }
        }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}