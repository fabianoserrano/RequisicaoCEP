using System.ComponentModel.DataAnnotations;

namespace CoreRequisicaoCEP
{
    public class RequisicaoCEP
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Logradouro é campo obrigatório")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "Município é campo obrigatório")]
        public Guid MunicipioId { get; set; }

        public override string ToString() =>
            $"Requisição de CEP Id {Id}, Logradouro {Logradouro}, Número {Numero}, Município Id {MunicipioId}";
    }
}
