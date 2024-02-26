using System.ComponentModel.DataAnnotations;

namespace APIRequisicaoCEP.Dtos
{
    public class RequisicaoCepDtoCreate
    {

        [Required(ErrorMessage = "Logradouro é campo obrigatório")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "Município é campo obrigatório")]
        public Guid MunicipioId { get; set; }
    }
}
