using System.ComponentModel.DataAnnotations;

namespace Orders.Shared.Entities
{
	public class Country
	{
		public int Id { get; set; }

		//Data notations
		[Display(Name = "País")]
		[MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
		[Required(ErrorMessage = "El campo {0} es requerido!")]//Data notation para definir que es requerido en la database
		public string Name { get; set; } = null!; //No puede ser null para evitar el error en name resaltado
	}
}