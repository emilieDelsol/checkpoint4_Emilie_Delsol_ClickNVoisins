using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clickAndV.Models
{
	public class Village
	{
		public int VillageId { get; set; }
		public String VillageName { get; set; }
		public String VillageDescription { get; set; }
		public DateTime CreationDate { get; set; }
		public virtual ICollection<Category> Categories { get; set; }
		public virtual Int32 DepartementId { get; set; }
		public virtual Departement Departement { get; set; }
	}
}
