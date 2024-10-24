using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Models
{
    public class RespuestaConsultaModel:RespuestaModel
    {
        [JsonProperty(PropertyName = "Personas")]
        public List<PersonaModel> Personas { get; set; }
    }
}