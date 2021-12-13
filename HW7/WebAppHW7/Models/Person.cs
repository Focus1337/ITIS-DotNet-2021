using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Person
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Age"), Range(0, 100, ErrorMessage = "Age must be between 0 and 100")]
        public int? Age { get; set; }
        
        [Display(Name = "Sex")]
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        People,
        Female
    }
}