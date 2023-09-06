using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rental.Models
{
    public class DefaultUser:IdentityUser
    {
        [PersonalData]
        public string  FirstName { get; set; }
        [PersonalData]
        public string Lastname { get; set; }
        [PersonalData]
        public string Address {  get; set; }
        [PersonalData]
        public string ZipCode { get; set; }
        [PersonalData]
        
        public string City { get; set; }
        [DataType (DataType.Date)]
        public DateTime UserCreationDate { get; set; } = DateTime.Now;
       
    }
}
