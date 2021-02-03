using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clickNVoisins.Models
{
	public class Village
	{
		public int VillageId { get; set; }
		public String VillageName { get; set; }
		public DateTime CreationDate { get; set; }
		public ICollection<Category> Categories { get; set; }
		public Departement Departement { get; set; }
	}
}
