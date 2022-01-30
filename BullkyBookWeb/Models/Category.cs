using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BullkyBookWeb.Models
{
    public class Category
    {
        // Use Data Annotations to Define coulmns in table and used to validations if you need reed more about it go to official documentation 
        // https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100 , ErrorMessage = "Display Order Must be Between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

    }
}
