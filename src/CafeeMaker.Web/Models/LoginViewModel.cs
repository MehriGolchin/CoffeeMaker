using System.ComponentModel.DataAnnotations;

namespace CafeeMaker.Web.Models {

    public class LoginViewModel {

        [Required]
        public int EmployeeId { get; set; }

    }

}