﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWashManagementSystem
{
    //to get connection string between application and database   
    public class dbConnect
    {
        SqlCommand cm = new SqlCommand();
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

        public void executeQuery(string sql)
        {
            try
            {
                open();
                cm = new SqlCommand(sql, connect());
                cm.ExecuteNonQuery();
                close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Car Wash Management System");
            }
        }
        public int Query (string sql)
        {
            try
            {
                open();
                cm = new SqlCommand(sql, connect());
                int res =cm.ExecuteNonQuery();
                close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Car Wash Management System");
                return -1;
            }
        }
    }
}
