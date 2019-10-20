using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Incorporo el espacio de nombre System.Data.SqlClient
using System.Data.SqlClient;
using System.Data;

namespace GTData
{
    public class Connection
    {
        private SqlConnection objConexion;
        private string stringConnection = "";


        /* -------------------- private void Conectar() ------------ 
         * Este metodo como indica su nombre... me permite conectarme con la 
         * base de datos (en este caso, SqlServer)
         * 
         */
        private void Connect()
        {
            stringConnection = "Integrated Security=SSPI;" +
                "Persist Security" +
                " Info=False;Initial" +
                " Catalog=GeekTrade;" +
                "Data Source=.\\SQLEXPRESS";

            //Instanció un objeto del tipo SqlConnection
            objConexion = new SqlConnection();
            objConexion.ConnectionString = stringConnection;
            objConexion.Open();
        }

        /* -------------------- private void Desconectar() ------------ 
         * Este metodo como indica su nombre... me permite desconectarme de la
         * base de datos (en este caso, SqlServer)
         * 
         */
        private void Disconnect()
        {
            objConexion.Close();
            objConexion.Dispose();
        }

        public DataTable ReadByStoreProcedure(string storeProcedureName, SqlParameter[] sqlParameters = null)
        {
            //Instancio un objeto del tipo DataTable
            var aTable = new DataTable();

            //Instancio un objeto del tipo SqlCommand
            var objCommand = new SqlCommand();

            //Me conecto...
            this.Connect();


            try
            {
                objCommand.CommandText = storeProcedureName;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = this.objConexion;

                if (sqlParameters != null)
                {
                    //Lleno los SqlParameters a la lista de parametros
                    objCommand.Parameters.AddRange(sqlParameters);
                }

                //Instancio un adaptador con el parametro SqlCommand
                var objAdapter = new SqlDataAdapter(objCommand);

                //Lleno la tabla, el objeto unaTabla con el adaptador
                objAdapter.Fill(aTable);
            }
            catch (Exception)
            {
                //Como hay error... por el motivo que sea asigno el resultado a null
                aTable = null;

                throw;
            }
            finally
            {

                //Pase lo que pase me desconecto
                this.Disconnect();
            }


            return aTable;
        }

        public DataTable ReadByCommand(string command)
        {
            //Instancio un objeto del tipo DataTable
            var aTable = new DataTable();

            //Instancio un objeto del tipo SqlCommand
            var objCommand = new SqlCommand();

            //Me conecto...
            this.Connect();

            try
            {


                //Parametrizo el objeto SqlCommand con sus valores respectivos
                objCommand.CommandType = CommandType.Text;
                objCommand.Connection = this.objConexion;
                objCommand.CommandText = command;

                //Instancio un adaptador con el parametro SqlCommand
                var objAdapter = new SqlDataAdapter(objCommand);

                //Lleno la tabla, el objeto unaTabla con el adaptador
                objAdapter.Fill(aTable);

            }
            catch
            {
                //Como hay error... por el motivo que sea asigno el resultado a null
                aTable = null;

                throw;
            }
            finally
            {
                //Siempre, por más que salga bien o mal el llenado, me desconecto
                this.Disconnect();
            }

            return aTable;
        }

        public int WriteByCommand(string text)
        {
            //Instanció una variable filasAfectadas que va a terminar devolviendo la cantidad de filas afectadas.
            int RowsAffected = 0;

            //Instancio un objeto del tipo SqlCommand
            var objCommand = new SqlCommand();

            //Me conecto...
            this.Connect();

            try
            {
                objCommand.CommandText = text;
                objCommand.CommandType = CommandType.Text;
                objCommand.Connection = this.objConexion;

                //El método ExecuteNonQuery() me devuelve la cantidad de filas afectadas.
                RowsAffected = objCommand.ExecuteNonQuery();


            }
            catch (Exception)
            {
                RowsAffected = -1;
                throw;
            }
            finally
            {
                //Me desconecto
                this.Disconnect();
            }


            return RowsAffected;
        }


        public int WriteByStoreProcedure(string text, SqlParameter[] sqlParameter)
        {
            //Instanció una variable filasAfectadas que va a terminar devolviendo la cantidad de filas afectadas.
            int rowsAffected = 0;

            //Instancio un objeto del tipo SqlCommand
            var objCommand = new SqlCommand();

            //Me conecto...
            this.Connect();

            try
            {
                objCommand.CommandText = text;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = this.objConexion;

                if (sqlParameter.Length > 0)
                {
                    objCommand.Parameters.AddRange(sqlParameter);
                    //El método ExecuteNonQuery() me devuelve la cantidad de filas afectadas.
                    rowsAffected = objCommand.ExecuteNonQuery();
                }
                else
                {
                    //retorno -1 porque la lista de parametros Sql tiene 0 ítems...
                    rowsAffected = -1;
                }



            }
            catch (Exception)
            {
                rowsAffected = -1;
                throw;
            }
            finally
            {
                //Me desconecto
                this.Disconnect();
            }


            return rowsAffected;
        }

        #region Parametros
        public SqlParameter CreateParameter(string name, string value)
        {

            SqlParameter objParameter = new SqlParameter();

            objParameter.ParameterName = name;
            objParameter.Value = value;
            objParameter.DbType = DbType.String;

            return objParameter;
        }



        public SqlParameter CreateParameter(string text, double value)
        {

            SqlParameter objParameter = new SqlParameter();

            objParameter.ParameterName = text;
            objParameter.Value = value;
            objParameter.DbType = DbType.Double;

            return objParameter;
        }


        public SqlParameter CreateParameter(string name, DateTime value)
        {

            SqlParameter objParameter = new SqlParameter();

            objParameter.ParameterName = name;
            objParameter.Value = value;
            objParameter.DbType = DbType.DateTime;

            return objParameter;
        }


        public SqlParameter CreateParameter(string text, int value)
        {

            SqlParameter objParameter = new SqlParameter();

            objParameter.ParameterName = text;
            objParameter.Value = value;
            objParameter.DbType = DbType.Int32;

            return objParameter;
        }


        public SqlParameter CreateParameter(string text, Boolean value)
        {

            SqlParameter objParameter = new SqlParameter();

            objParameter.ParameterName = text;
            objParameter.Value = value;
            objParameter.DbType = DbType.Boolean;

            return objParameter;
        }
        #endregion


    }
}
