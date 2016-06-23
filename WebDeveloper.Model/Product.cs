using System;
using System.ComponentModel.DataAnnotations;

namespace WebDeveloper.Model
{
    public class Product
    {

        

        public int ID { get; set; }

        [Display(Name = "Description")]
        [MaxLength(25)]
        [Required(ErrorMessage = "This Description is required")]
        public string Description{ get; set; }

        [Display(Name = "Price")]
      //  [Range(300,3000)]
        //[Required(ErrorMessage = "This Price is required")]
        public double Price { get; set; }



        [Display(Name = "Create Date")]
             [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; }

  

    }
}
