using System;

namespace clickNVoisins.Models
{
	public class Comment
	{
		public int CommentId { get; set; }
		public string Notice { get; set; }
		public int Grade { get; set; }
		public DateTime CreationDate { get; set; }
		public User User { get; set; }
		public Article  Article { get; set; }
	}
}
