using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Order
    {

        //Не палить id
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Сюда пиши имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не больше 25 символов, алло")]
        public string Name { get; set; }

        [Display(Name = "Сюда пиши где живешь")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина родины не менее 50 символов, ю ноу?")]
        public string Address { get; set; }

        [Display(Name = "Сюда пиши телефончик")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Просто напиши телефон, без всяких выкрутасов")]
        public string Phone { get; set; }

        [Display(Name = "Сюда пиши виртуальную почту")]
        [StringLength(40)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email >= 40 символам")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)] //полностью скрыть даже в исходнике
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }


    }
}
