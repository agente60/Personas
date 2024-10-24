using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Personas.API.Models
{
    public class PersonaModel
    {
        /// <summary>
        /// Nonre de la persona
        /// </summary>
        [JsonProperty(PropertyName = "Nombre")]
        [StringLength(50, ErrorMessage = "El tamaño maximo del nombre es de 50 caracteres")]
        public string Nombre { get; set; }
        /// <summary>
        /// Edad numerica de la persona
        /// </summary>
        [JsonProperty(PropertyName = "Edad")]
        [Range(1, 120, ErrorMessage = "Ingrese una edad valida")]
        public int Edad { get; set; }
        /// <summary>
        /// Direccion de correo de la persona
        /// </summary>
        [JsonProperty(PropertyName = "Email")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        public string Email { get; set; }
    }
}