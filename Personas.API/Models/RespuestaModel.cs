using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Models
{
    public class RespuestaModel
    {
        /// <summary>
        /// Resultado de la Operacion
        /// </summary>
        [JsonProperty(PropertyName = "Resultado")]
        public bool Resultado { get; set; }
        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        [JsonProperty(PropertyName = "Mensaje")]
        public string Mensaje { get; set; }  
    }
}