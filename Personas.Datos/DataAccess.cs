
using Personas.Datos.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Personas.Datos
{
    public class DataAccess
    {

       
        public List<PersonaDTO> SelectQuery(string id)
        {
            List<PersonaDTO> personasBD = new List<PersonaDTO>(); 
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conSql"].ConnectionString))
                {
                    using (SqlCommand cmds = con.CreateCommand())
                    {
                        cmds.CommandText = "SP_OBTIENEPERSONA";
                        cmds.CommandType = CommandType.StoredProcedure;

                        if (string.IsNullOrWhiteSpace(id))
                        {
                            cmds.Parameters.Add(new SqlParameter("@P_ID", DBNull.Value));
                        }
                        else 
                        {
                            cmds.Parameters.Add(new SqlParameter("@P_ID", id));
                        }

                        SqlDataReader r = cmds.ExecuteReader();

                        while (r.Read())
                        {
                            personasBD.Add(new PersonaDTO { Nombre = r.GetString(0), Edad = r.GetInt32(1), Email = r.GetString(2), Id = r.GetInt32(3) });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Guardar Log 
            }
            return personasBD;
        }

        public bool InsertQuery(PersonaDTO persona)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conSql"].ConnectionString))
                {
                    using (SqlCommand cmds = con.CreateCommand())
                    {
                        cmds.CommandText = "SP_INSERTAPERSONA";
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add(new SqlParameter("@P_NOMBRE", persona.Nombre));
                        cmds.Parameters.Add(new SqlParameter("@P_EDAD", persona.Edad));
                        cmds.Parameters.Add(new SqlParameter("@P_EMAIL", persona.Email));

                        int exec = cmds.ExecuteNonQuery();

                        resultado = exec > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                //Guardar Log 
                resultado = false;
            }

            return resultado;
        }
    }
}
