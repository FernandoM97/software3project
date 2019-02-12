using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibConexionBD;

namespace IdentificadorPlacasDeVehiculos.Clases
{
    class clsDatos
    {
        private static string mensaje;
        private static ConexionBD conexion = new ConexionBD("Parametros.xml");
        public static string Mensaje { get { return mensaje; } }
        public static bool ValidarUsuario(string usuario, string clave)
        { 
            if (!conexion.AbrirConexion())
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return false;
            }
            conexion.SQL = "select (1) from Usuario where Usuario = '" + usuario + "' and Clave = '" + clave + "'";
            if (!conexion.ConsultarValorUnico(false))
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return false;
            }
            if (conexion.ValorUnico == null)
            {
                mensaje = "Usuario o Contraseña no validas";
                conexion.CerrarConexion();
                return false;
            }
            conexion.CerrarConexion();
            return true;
        }
        public static clsDatosPropietarios consultarDatosPropietarios(int cedulaCiudadania)
        {
            if (!conexion.AbrirConexion())
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return null;
            }
            conexion.SQL= "select * from DatosPropietarioVehiculo where cedulaCiudadania=" + cedulaCiudadania;
            conexion.LlenarDataSet(false);
            if (conexion.Ds.Tables[0].Rows.Count == 0)
            {
                mensaje = "Codigo placa no existe";
                conexion.CerrarConexion();
                return null;
            }
            clsDatosPropietarios propietarios = new clsDatosPropietarios();
            propietarios.cedulaCiudadania = Convert.ToInt32(conexion.Ds.Tables[0].Rows[0].ItemArray[0]);
            propietarios.nombreApellidos = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[1]);
            propietarios.idGenero = Convert.ToInt32(conexion.Ds.Tables[0].Rows[0].ItemArray[2]);
            propietarios.ciudad = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[3]);
            propietarios.direccion = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[4]);
            propietarios.email = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[5]);
            propietarios.nroCelular = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[6]);
            propietarios.codigoPlaca = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[7]);

            mensaje = "Codigo placa consultado";
            conexion.CerrarConexion();
            return propietarios;
        }
        public static bool ActualizarDatosPropietarios(clsDatosPropietarios propietarios)
        {
            if (!conexion.AbrirConexion())
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return false;
            }
            conexion.SQL = "update DatosPropietarioVehiculo set nombreApellidos='"+propietarios.nombreApellidos+ "',idGenero=" + propietarios.idGenero + ",ciudad='" + propietarios.ciudad + "',direccion='" + propietarios.direccion + "',email='" + propietarios.email + "',nroCelular='" + propietarios.nroCelular + "',codigoPlaca='" + propietarios.codigoPlaca + "' where cedulaCiudadania="+propietarios.cedulaCiudadania;
            if (!conexion.EjecutarSentencia(false))
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return false;
            }
            mensaje = "Registro actualizado";
            conexion.CerrarConexion();
            return true;
        }
        public static bool NuevoDatosPropietarios(clsDatosPropietarios propietarios)
        {
            if (!conexion.AbrirConexion())
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return false;
            }
            conexion.SQL = "insert into DatosPropietarioVehiculo(cedulaCiudadania,nombreApellidos,idGenero,ciudad,direccion,email,nroCelular,codigoPlaca)values("+propietarios.cedulaCiudadania+",'"+propietarios.nombreApellidos+"',"+propietarios.idGenero+",'"+propietarios.ciudad+"','"+propietarios.direccion+"','"+propietarios.email+"','"+propietarios.nroCelular+"','"+propietarios.codigoPlaca+"')";
            if (!conexion.EjecutarSentencia(false))
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return false;
            }
            mensaje = "Se ingresó el registro correctamente";
            conexion.CerrarConexion();
            return true;
        }
        public static bool eliminarDatosPropietarios(int cedulaCiudadania)
        {
            if (!conexion.AbrirConexion())
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return false;
            }
            conexion.SQL = "DELETE FROM DatosPropietarioVehiculo WHERE cedulaCiudadania=" +cedulaCiudadania;
            if (!conexion.EjecutarSentencia(false))
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return false;
            }
            mensaje = "Registro eliminado";
            conexion.CerrarConexion();
            return true;
        }
        public static clsUsuario consultarUsuario(string IDUsuario)
        {
            if (!conexion.AbrirConexion())
            {
                mensaje = conexion.Error;
                conexion.CerrarConexion();
                return null;
            }
            conexion.SQL = "select * from Usuario where Usuario='" + IDUsuario + "'";
            conexion.LlenarDataSet(false);
            if (conexion.Ds.Tables[0].Rows.Count == 0)
            {
                mensaje = "Usuario no existe";
                conexion.CerrarConexion();
                return null;
            }
            clsUsuario usuario = new clsUsuario();
            usuario.IDUsuario = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[0]);
            usuario.Clave = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[1]);
            usuario.Nombres = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[2]);
            usuario.Apellidos = Convert.ToString(conexion.Ds.Tables[0].Rows[0].ItemArray[3]);
            usuario.IDPerfil = Convert.ToInt32(conexion.Ds.Tables[0].Rows[0].ItemArray[4]);
           

            mensaje = "Usuario consultado";
            conexion.CerrarConexion();
            return usuario;
        }
    }
}
