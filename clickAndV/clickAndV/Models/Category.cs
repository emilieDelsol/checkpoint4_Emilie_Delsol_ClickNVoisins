using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clickAndV.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		public String CategoryName { get; set; }
		public String Banner { get; set; }
		public DateTime CreationDate { get; set; }
		public virtual ICollection<Ad> Ads { get; set; }
	}
}
