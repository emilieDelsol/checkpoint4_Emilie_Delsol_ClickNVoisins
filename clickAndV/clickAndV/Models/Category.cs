using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionCheckpoint3.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		public String CategoryName { get; set; }
		public DateTime CreationDate { get; set; }
		public virtual ICollection<Ad> Ads { get; set; }
	}
}
