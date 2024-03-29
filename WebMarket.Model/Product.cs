﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="عنوان اجباری است")]
        [DisplayName("عنوان")]
        [MaxLength(150,ErrorMessage ="عنوان باید بین 1 تا 150 باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage ="توضیحات اجباری است")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("توضیحات کوتاه")]
        public string ShortDescription { get; set; }

        [DisplayName("شابک")]
        [Required(ErrorMessage ="شابک اجباری است")]
        [MaxLength(15,ErrorMessage ="شابک باید حداکثر 15 حرف باشد")]
        public string ISBN { get; set; }
        [Required(ErrorMessage ="نام نویسنده اجباری است")]
        [DisplayName("نام نویسنده")]
        [MaxLength(150,ErrorMessage ="نام نویسنده حداکثر باید 150 حرف باشد")]
        public string Author { get; set; }

        [Required(ErrorMessage ="لیست قیمت ها اجباری است")]
        [DisplayName("لیست قیمت ها")]
        public double ListPrice { get; set; }

        [Required(ErrorMessage = " قیمت اجباری است")]
        [DisplayName(" قیمت ")]
        public double Price { get; set; }

        [Required(ErrorMessage ="قیمت 50 عدد اجباری است")]
        [DisplayName("قیمت 50 عدد")]
        public double Price50 { get; set; }

        [Required(ErrorMessage = "قیمت 100 عدد اجباری است")]
        [DisplayName("قیمت 100 عدد")]
        public double Price100 { get; set; }

        [DisplayName("تصویر")]
        [ValidateNever]
        public string ImgeUrl { get; set; }

        [DisplayName("عنوان تصویر")]
        [MaxLength(50,ErrorMessage ="عنوان تصویر باید حداکثر 50 حرف باشد")]
        public string ImageTitle { get; set; }

        [DisplayName("متن جایگزین تصویر")]
        [MaxLength(50,ErrorMessage ="متن جایگزین تصویر باید حداکثر 50 حرف باشد")]
        public string ImageAlt { get; set; }

        

        [Required(ErrorMessage = "دسته اجباریست")]
        [Display(Name = "دسته")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required(ErrorMessage = "کاورتایپ اجباریست")]
        [DisplayName("کاورتایپ")]
        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        [ValidateNever]
        public CoverType CoverType { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;


    }
}
