using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="عنوان دسته اجباری است")]
        [DisplayName("عنوان دسته")]
        public string Name { get; set; }
        [Required(ErrorMessage ="ترتیب نمایش اجباری است")]
        [DisplayName("ترتیب نمایش")]
        [Range(1,100,ErrorMessage ="ترتیب نمایش باید بین 1 تا 100 باشد")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
