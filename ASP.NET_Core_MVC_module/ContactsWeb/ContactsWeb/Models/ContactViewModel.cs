using ContactsWeb.Resources;
using System.ComponentModel.DataAnnotations;

namespace ContactsWeb.Models
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public string Number { get; set; }
    }
}
