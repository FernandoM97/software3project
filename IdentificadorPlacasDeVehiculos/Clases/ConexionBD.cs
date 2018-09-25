using IdentificadorPlacasDeVehiculos.Formularios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdentificadorPlacasDeVehiculos.Clases
{
    class ConexionBD
    {
        SqlConnection cn;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;
        DataRow dr;
        SqlDataReader sqldr;

        public string abrirConexion()
        {
            try
            {
                cn = new SqlConnection("Data Source =DESKTOP-I7I5QJJ\\SQLEXPRESS;Initial Catalog = ReconocimienoPlacasVehiculos; Integrated Security = True");
                cn.Open();
                return "Conectado";
            }
            catch (Exception ex)
            {
                return "No conectado: " + ex.ToString();
            }
            cn.Close();
        }

        public string insertarImagen(string codigoPlaca, PictureBox pbImagen)
        {
            string mensaje = "Se inserto la imagen correctamente";
            try
            {
                cmd = new SqlCommand("Insert into PlacasVehiculo(codigoPlaca,imagenPlaca) values(@codigoPlaca,@imagenPlaca)", cn);
                cmd.Parameters.Add("@codigoPlaca", SqlDbType.VarChar);
                cmd.Parameters.Add("@imagenPlaca", SqlDbType.Image);

                cmd.Parameters["@codigoPlaca"].Value = codigoPlaca;
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmd.Parameters["@imagenPlaca"].Value = ms.GetBuffer();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                mensaje = "No se inserto la imagen: " + ex.ToString();
            }
            IdentificadorPlacas vehiculos = new IdentificadorPlacas();
            return mensaje;
        }

        public void verImagen(PictureBox pbFoto, string codigoPlaca)
        {
            try
            {
                da = new SqlDataAdapter("Select imagenPlaca from PlacasVehiculo where codigoPlaca = '" + codigoPlaca + "'", cn);
                ds = new DataSet();
                da.Fill(ds, "PlacasVehiculo");
                byte[] datos = new byte[0];
                dr = ds.Tables["PlacasVehiculo"].Rows[0];
                datos = (byte[])dr["imagenPlaca"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);
                pbFoto.Image = System.Drawing.Bitmap.FromStream(ms);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar la Imagen: " + ex.ToString());
            }
        }

        public void cargarImagenes(ComboBox cbImg)
        {
            try
            {
               
                cmd = new SqlCommand("Select codigoPlaca from PlacasVehiculo", cn);
                sqldr = cmd.ExecuteReader();
                while (sqldr.Read())
                {
                    cbImg.Items.Add(sqldr["codigoPlaca"]);
                }
                sqldr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron las imagenes en el ComboBox: " + ex.ToString());
            }
        }
        public string cargarCodigoPLaca(string codigoPlaca="")
        {
            abrirConexion();
            List<string> resultado = new List<string>();
            string querySelect = "Select codigoPlaca from PlacasVehiculo";
            SqlCommand commandSelect = new SqlCommand(querySelect,cn);

            SqlDataReader reader =  commandSelect.ExecuteReader();
            
            while (reader.Read())
            {
                resultado.Add(Convert.ToString(reader["codigoPlaca"]));
            }
            foreach(string fila in resultado)
            {
                codigoPlaca += fila;
            }
           // cn.Close();
            return  codigoPlaca;
        }
    }

}
