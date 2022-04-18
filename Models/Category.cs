using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRockyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required] // обязательное поле
        public string Name { get; set; }

        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Должно быть более 0")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
