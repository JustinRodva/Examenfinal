using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace examenfinal
{
    public partial class ENCUESTA : System.Web.UI.MasterPage
    {
        private SqlDbType nombre;
        private SqlDbType especialidad;

        public object DBConeccion { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DbConnection())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_TEC_ID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID_TEC", ID));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException )
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

             



        }

        private SqlConnection DbConnection()
        {
            throw new NotImplementedException();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DbConnection())
                {
                    SqlCommand cmd = new SqlCommand("INGRESARTECNICO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", especialidad));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

           
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close()
        {
            throw new NotImplementedException();
        }
    }
}