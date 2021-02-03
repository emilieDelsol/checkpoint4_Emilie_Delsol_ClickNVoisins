using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionCheckpoint3.Models
{
	public class Village
	{
		public int VillageId { get; set; }
		public String VillageName { get; set; }
		public DateTime CreationDate { get; set; }
		public virtual ICollection<Category> Categories { get; set; }
	}
}
