using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace peru_fails.Models{
    public class Fail{
        public int Id { get; set; }

        
        [Required(ErrorMessage="¡Por favor, Ingrese un Título!")]
        [Display(Name="Título del fail")]
        public string titulo { get; set; }
        public DateTime fec_envio { get; set; }

        public string nom_usuario{get;set;}

        [Required(ErrorMessage="¡Por favor, Ingrese una url!")]
        [Display(Name="Url del fail")]
        public string url_imagen { get; set; }
    }
}