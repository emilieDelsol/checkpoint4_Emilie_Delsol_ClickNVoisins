namespace clickNVoisins.Models
{
	public class Image
	{
		public int ImageId { get; set; }
		public string Picture { get; set; }
		public Article Article { get; set; }
	}
}