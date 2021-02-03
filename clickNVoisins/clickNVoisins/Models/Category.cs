using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clickNVoisins.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		public String CategoryName { get; set; }
		public DateTime CreationDate { get; set; }
		public ICollection<Article> Articles { get; set; }
		public Village Village { get; set; }
	}
}
