using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace clickAndV.Models
{
    public class Ad
    {
        public Guid AdId { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Banner { get; set; }
        public int CategoryId { get; set; }
        public String UserId { get; set; }
        public  virtual ICollection<Image> Images { get; set; }
        public  virtual ICollection<Comment> Comments { get; set; }
        public virtual  User User { get; set; }
        public  virtual Category Category { get; set; }
        [NotMapped]
        public IFormFile Picture { get; set; }
       
    }
}
