﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Models
{
    public class Shoping
    {
        public int Id { get; set; }
       public int ProductId {  set; get; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        [Range (1,1000,ErrorMessage ="please enter a value between 1 and 1000")]
        public int Count { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AllUser Alluser { get; set; }
    }
}
