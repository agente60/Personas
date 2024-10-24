using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Models.DTO
{
    public class PersonaDTO
    {
        public string Nombre{ get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
    }
}