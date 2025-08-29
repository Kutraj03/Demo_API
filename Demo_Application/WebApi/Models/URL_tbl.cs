using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static WebApi.Helpers.Validation;

namespace WebApi.Model
{
    public class URL_tbl
    {
        [Key]                       
        public int Id { get; set; }
        
        public string URL { get; set; }
        public string Display_URL { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }

    }

    public class URL_tblViewmodel
    {
        [Required]
        [CustomValidation(typeof(URLValidator), nameof(URLValidator.ValidateUrl))]
        public string URL { get; set; }
        public bool? Active { get; set; }

    }
}
