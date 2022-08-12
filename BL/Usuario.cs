using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {


        public static ML.Result GetAll()

        {
            ML.Result result = new ML.Result();
            try
            {

                using (var context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    //var sql = "UsuarioGetAll";
                    var lst = context.Query<ML.Usuario>("UsuarioGetAll").ToList(); //Dapper

                    result.Objects = new List<object>();
                    foreach (var obj in lst)
                    {

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = obj.IdUsuario;
                        usuario.Nombre = obj.Nombre;
                        usuario.ApellidoPaterno = obj.ApellidoPaterno;
                        usuario.ApellidoMaterno = obj.ApellidoMaterno;

                        result.Objects.Add(usuario);
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMensage = ex.Message;
            }

            return result;
        }



        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    var lst = context.Query<ML.Usuario>($"UsuarioGetById {IdUsuario}").AsEnumerable().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (lst != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = lst.IdUsuario;
                        usuario.Nombre = lst.Nombre;
                        usuario.ApellidoPaterno = lst.ApellidoPaterno;
                        usuario.ApellidoMaterno = lst.ApellidoMaterno;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMensage = ex.Message;
            }
            return result;
        }


        public static ML.Result Add(ML.Usuario usuario)

        {

            ML.Result result = new ML.Result();
            try { 

            using (var context = new SqlConnection(DL.Conexion.GetConnection()))
            {

                    //Utiliza Dapper en Execute
                    var lst = context.Execute($"UsuarioAdd '{usuario.Nombre}','{usuario.ApellidoMaterno}','{usuario.ApellidoPaterno}'");

                    if (lst > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMensage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }



        public static ML.Result Update(ML.Usuario usuario)

        {

            ML.Result result = new ML.Result();
            try
            {

                using (var context = new SqlConnection(DL.Conexion.GetConnection()))
                {


                    var lst = context.Execute($"UsuarioUpdate {usuario.IdUsuario},'{usuario.Nombre}','{usuario.ApellidoMaterno}','{usuario.ApellidoPaterno}'");//Utiliza Dapper

                    if (lst > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMensage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }



        public static ML.Result Delete(ML.Usuario usuario)

        {

            ML.Result result = new ML.Result();
            try
            {

                using (var context = new SqlConnection(DL.Conexion.GetConnection()))
                {


                    var lst = context.Execute($"UsuarioDelete {usuario.IdUsuario}");//Utiliza Dapper

                    if (lst > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMensage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }



    }

    


        
            
    
}
