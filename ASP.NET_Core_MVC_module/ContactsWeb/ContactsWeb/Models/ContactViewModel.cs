using System.ComponentModel.DataAnnotations;

namespace ContactsWeb.Models
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string Number { get; set; }
    }
}
