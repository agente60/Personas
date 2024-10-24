using Personas.API.Models;
using Personas.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Personas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/persona")]
    public class PersonaController : ApiController
    {
        [Route("agregar")]
        [HttpPost]
        public IHttpActionResult AgregaPersona(PersonaModel model)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                if (ModelState.IsValid)
                {
                    Personas.Datos.DataAccess da = new DataAccess();

                    var resultadoBD = da.InsertQuery(new Datos.DTO.PersonaDTO { Nombre = model.Nombre, Edad = model.Edad, Email = model.Email });

                    new RespuestaModel { Resultado = resultadoBD, Mensaje = resultadoBD ? "Ingreso correcto" : "No se pudo completar el ingreso." };
                }
                else 
                {
                    string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)); 

                    respuesta = new RespuestaModel { Resultado = false, Mensaje = $"Json invalido: {messages}" };
                }

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error interno en el servicio {ex.Message}"));
                //respuesta = new RespuestaModel { Resultado = false, Mensaje = $"Error interno en el servicio {ex.Message}"};
            }
            
        }

        [Route("consultar")]
        [HttpGet]
        public IHttpActionResult ObtienePersonas(string id)
        {
            RespuestaConsultaModel respuesta = new RespuestaConsultaModel();
            try
            {
                Personas.Datos.DataAccess da = new DataAccess();
                List<Datos.DTO.PersonaDTO> resultadoPersonas = new List<Datos.DTO.PersonaDTO>();

                if (string.IsNullOrWhiteSpace(id))
                {
                    resultadoPersonas = da.SelectQuery(string.Empty);
                    
                }
                else 
                {
                    resultadoPersonas = da.SelectQuery(id);
                }
                
                if (resultadoPersonas.Count > 0)
                {
                    respuesta.Personas = resultadoPersonas.Select(x => new PersonaModel { Nombre = x.Nombre, Edad = x.Edad, Email = x.Email }).ToList();
                }
                else 
                {
                    respuesta = new RespuestaConsultaModel { Resultado = false, Mensaje = $" Sin informacion encontrada" };
                }

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                //respuesta = new RespuestaConsultaModel { Resultado = false, Mensaje = $"Error interno en el servicio {ex.Message}" };

                return InternalServerError(new Exception($"Error interno en el servicio {ex.Message}"));
            }

        }
    }
}
