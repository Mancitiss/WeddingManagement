using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeddingManagementApplication
{
    public partial class FormBill : Form
    {
        public FormBill()
        {
            InitializeComponent();
        }

        public string id;
        
        public FormBill(string id): this()
        {
            this.id = id;
            using(SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand sqlcomm = new SqlCommand("SELECT W.Representative, W.PhoneNumber, W.TablePrice, B.TablePriceTotal, B.ServicePriceTotal, B.Total, B.InvoiceDate, B.PaymentDate, B.MoneyLeft FROM BILL B, WEDDING_INFOR W WHERE IdWedding = IdBill AND IdBill = @id", sql))
                {
                    sqlcomm.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = sqlcomm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_representative.Text = reader.GetString(0);
                            tb_phone.Text = reader.GetString(1);
                            tb_lobby_price.Text = reader.GetInt64(2).ToString();
                            tb_tableTotal.Text = reader.GetInt64(3).ToString();
                            tb_serviceTotal.Text = reader.GetInt64(4).ToString();
                            tb_total.Text = reader.GetInt64(5).ToString();
                            invoiceDTP.Value = reader.GetDateTime(6);
                            paymentDTP.Value = reader[7] != DBNull.Value ? reader.GetDateTime(7) : DateTime.Now;
                            tb_moneyLeft.Text = reader.GetInt64(8).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
