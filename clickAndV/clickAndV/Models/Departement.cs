using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionCheckpoint3.Models
{
	public class Departement
	{
		public int DepartementId { get; set; }
		public String DepartementName { get; set; }
		public DateTime CreationDate { get; set; }
		public  virtual  ICollection<Village> Villages { get; set; }

	}
}
