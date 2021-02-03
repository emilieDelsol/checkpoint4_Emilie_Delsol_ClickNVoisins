using System;
using System.Collections.Generic;

namespace clickNVoisins.Models
{
	public class Article
	{
		public int ArticleId { get; set; }
		public string Title { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime BeginDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Banner { get; set; }
		public ICollection<Image> Images { get; set; }
		public string Description { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public int CategoryId { get; set; }
		public User User { get; set; }
	}
}