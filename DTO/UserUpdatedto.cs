using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarWashSystem.DTO
{
    public class UserUpdatedto
    {
      
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Address { get; set; }
    }
}
