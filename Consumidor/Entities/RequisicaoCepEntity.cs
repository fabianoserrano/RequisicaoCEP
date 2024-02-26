using System.ComponentModel.DataAnnotations;

namespace ServiceRequisicaoCEP.Entities
{
    public class RequisicaoCepEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        [Required]
        public Guid MunicipioId { get; set; }

        //public MunicipioEntity Municipio { get; set; }
    }
}
