using System;

namespace CorrectionCheckpoint3.Models
{
	public class Comment
	{
		public int CommentId { get; set; }
		public string Notice { get; set; }
		public int Grade { get; set; }
		public DateTime CreationDate { get; set; }
	}
}