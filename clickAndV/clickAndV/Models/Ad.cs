using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorrectionCheckpoint3.Models
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
        public ICollection<Image> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public User User { get; set; }
        [NotMapped]
        public IFormFile Picture { get; set; }
        public Category category { get; set; }
    }
}
