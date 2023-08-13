
using System.ComponentModel.DataAnnotations;

namespace FptBookStore.ViewModel
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
