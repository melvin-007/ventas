using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace CapaDatos
{
     public class DCategoria
    {
        //declarando atributos de tabla categoria 
        //idcategoria int 
        //nombre varchar(50)
        //descripcion varchar(256)
        private int _Idcategoria;//clic derecho sobre variable y encapsular campo
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int Idcategoria
        {
            get{ return _Idcategoria;}
            set{ _Idcategoria = value;}

        }
        public string Nombre
        {
            get{ return _Nombre;}//retorna id categoria
            set {_Nombre = value;}//almacena objeto de valor del atributo Nombre
        }

        public string Descripcion
        {
            get{return _Descripcion;}
            set{_Descripcion = value;}
        }

        public string TextoBuscar
        {
            get{return _TextoBuscar;}
            set{_TextoBuscar = value;}
        }

        //constructor vacio
        public DCategoria()
        {

        }
        //contructor vacio 
        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria; //referencia a metodo set and get categoria 
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //metodo insert,edit,delete
        //metodo insertar 
        public string Insertar(DCategoria Categoria)//devuelve valor tipo string
        {
            string rpta = "";//
            //Instancia conexion
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo 
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //comando q ejecuta sencias sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_categoria";//Procedimiento insertarcategoria en sql
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //parametro idcategoria
                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria"; //campo autonumerico es parametro de salida
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcategoria);
                //parametros nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50; //Tamaño del texto 
                ParNombre.Value = Categoria.Nombre;//metodo get
                SqlCmd.Parameters.Add(ParNombre);
                //parametros descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256; //Tamaño del texto 
                ParDescripcion.Value = Categoria.Descripcion;//metodo get
                SqlCmd.Parameters.Add(ParDescripcion);
                //ejecutamos comando 
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";//si se inserta el valor

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            //cerrando conexion 
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;


        }

        public string Editar(DCategoria Categoria)//devuelve valor tipo string
        {
            string rpta = "";//
            //Instancia conexion
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo 
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //comando q ejecuta sencias sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";//Procedimiento insertarcategoria en sql
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //parametro idcategoria
                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria"; //campo autonumerico es parametro de salida
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                //ParIdcategoria.Direction = ParameterDirection.Output;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);
                //parametros nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50; //Tamaño del texto 
                ParNombre.Value = Categoria.Nombre;//metodo get
                SqlCmd.Parameters.Add(ParNombre);
                //parametros descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256; //Tamaño del texto 
                ParDescripcion.Value = Categoria.Descripcion;//metodo get
                SqlCmd.Parameters.Add(ParDescripcion);
                //ejecutamos comando 
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";//si se inserta el valor

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            //cerrando conexion 
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public string Eliminar(DCategoria Categoria)//devuelve valor tipo string
        {
            string rpta = "";//
            //Instancia conexion
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo 
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //comando q ejecuta sencias sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_categoria";//Procedimiento insertarcategoria en sql
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //parametro idcategoria
                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria"; //campo autonumerico es parametro de salida
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                //ParIdcategoria.Direction = ParameterDirection.Output;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);
                //ejecutamos comando 
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";//si se inserta el valor

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            //cerrando conexion 
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        //metodo para mostrar registros de tabla categoria 
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        //metodo buscar nombre //metodo recibe parametro 
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

    }
}
