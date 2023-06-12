using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashTester
{
    public class dbConnect
    {
        SqlCommand cm = new SqlCommand();
        public SqlDataReader dr;
        private SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\UIT\Study\Semester6\SE113_KiemChungPhanMem\Project\CarWashManagementSystem-master\CarWashManagementSystem\DBCarWash.mdf;Integrated Security=True");
        public SqlConnection connect()
        {
            return cn;
        }
        public void open()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();
        }

        public void close()
        {
            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public int Query(string sql)
        {
            try
            {
                open();
                cm = new SqlCommand(sql, connect());
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    close();
                    return 1;

                }
                else
                {
                    close();
                    return 0;
                }

            }
            catch (Exception ex)
            {
                
                return -1;
            }
        }
    }
}
