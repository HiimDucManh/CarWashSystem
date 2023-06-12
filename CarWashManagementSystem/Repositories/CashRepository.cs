using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagementSystem.Repositories
{
    public class CashRepository
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        public string AddCash(string change, string cashInput, Cash cash)
        {
            try
            {
                if (double.Parse(change) < 0 || cashInput.Equals(""))
                {                    
                    return "insufficient";
                }
                else
                {
                    for (int i = 0; i < cash.dgvCash.Rows.Count; i++)
                    {
                        dbcon.executeQuery("UPDATE tbCash SET status='Sold',price='" + cash.dgvCash.Rows[i].Cells[9].Value.ToString() + "' WHERE id='" + cash.dgvCash.Rows[i].Cells[1].Value.ToString() + "'");
                        dbcon.executeQuery("UPDATE tbCustomer SET points += " + 1 + " WHERE id='" + cash.customerId + "'");
                    }

                    receipt module = new receipt(cash);
                    module.loadReceipt(cashInput, change);
                    module.ShowDialog();



                    cash.loadCash();
                    
                    cash.btnAddCustomer.Enabled = true;
                    cash.btnAddService.Enabled = false;
                    cash.getTransno();

                    return "successful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public bool CheckField(string change, string cashInput, Cash cash)
        {
            if (double.Parse(change) < 0 || cashInput.Equals(""))
            {
                return false;
            }
            else return true;
        }
    }
}
