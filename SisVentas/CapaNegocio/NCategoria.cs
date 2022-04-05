using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        //metodo para comunicar capa datos
        //metodo de insertar que llama al metodo insertar de la clase DCategoria de la capa datos
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre; //llamando metodo set de nombre
            Obj.Descripcion = descripcion; //metodo del objeto
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre; //llamando metodo set de nombre
            Obj.Descripcion = descripcion; //metodo del objeto
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idcategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
