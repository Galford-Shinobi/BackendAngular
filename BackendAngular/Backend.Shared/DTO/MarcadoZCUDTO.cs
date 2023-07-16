using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Shared.DTO
{
     public class MarcadoZCUDTO
    {
        public string cuv { get; set; }
        public string DocumentoOf { get; set; }
        public string NoOficio { get; set; }
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string FechaOfic { get; set; }
        public string Fraccionamiento { get; set; }
        public string TipoExcepccion { get; set; }
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string FechaRergistro { get; set; }
    }
}
