using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_Hander.DTOs
{
	public class ProductAddDto
	{
		[Required,MaxLength(50)]
		public string Name { get; set; }
		public string Desc { get; set; }
		[Required,Range(0,1000)]
		public double? Price { get; set; }
	}
	public class ProductUpdateDto
	{
		[Required]
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; }
		public string Desc { get; set; }

	}
	public class ProductGetDto
	{
		public Guid Id { get; set; }
		public DateTime? CreatedAt { get; set; }
		public string  Name { get; set; }
		public string Desc { get; set; }
		public double Price { get; set; }
	}
}