using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANTLR.Clases2;

namespace ANTLR
{
    class Empresa
    {
        public static List<Empresa> Empresas = new List<Empresa>();

        public string Nombre { get; set; }
        public List<Cuenta> Cuentas { get; }

        public Empresa(string nombre)
        {
            Cuentas = new List<Cuenta>();
            this.Nombre = nombre;
            Empresas.Add(this);
        }
        
        public int getCantidadDeCuentas()
        {
            return Cuentas.Count;
        }
        public Cuenta getCuenta (string nombre)
        {
            return Cuentas.Find(x => x.Nombre == nombre);
        }
        
        public void addCuenta (string nombre, int valor)
        {
            var cuenta = new Cuenta();
            cuenta.Nombre = nombre;
            cuenta.Valor = valor;
            Cuentas.Add(cuenta);
        }

        public static void OrdenarEmpresas()
        {
           
        }
    }
}
