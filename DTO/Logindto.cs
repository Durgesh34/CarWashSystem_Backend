using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace CarWashSystem.DTO
{
    public class Logindto
    {
        public string Email { get; set; }=string.Empty; 
        public string Password { get; set; } = string.Empty;    
    }
}
