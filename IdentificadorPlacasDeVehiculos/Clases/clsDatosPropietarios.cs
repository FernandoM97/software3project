using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificadorPlacasDeVehiculos.Clases
{
    class clsDatosPropietarios
    {
        public clsDatosPropietarios()
        {

        }
        public clsDatosPropietarios(int cedulaCiudadania, string nombreApellidos, int idGenero, string ciudad, string direccion, string email, string nroCelular, string codigoPlaca)
        {
            this.cedulaCiudadania = cedulaCiudadania;
            this.nombreApellidos = nombreApellidos;
            this.idGenero = idGenero;
            this.ciudad = ciudad;
            this.direccion = direccion;
            this.email = email;
            this.nroCelular = nroCelular;
            this.codigoPlaca = codigoPlaca;
        }
        public int cedulaCiudadania { get; set; }
        public string nombreApellidos { get; set; }
        public int idGenero { get; set; }
        public string ciudad { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string nroCelular { get; set; }
        public string codigoPlaca { get; set; }
    }
}
