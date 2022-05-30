using System;
using System.Collections.Concurrent;
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
    public partial class FormServices : Form
    {
        public static ConcurrentDictionary<string, Services> knownServices = new ConcurrentDictionary<string, Services>();
        public static ConcurrentDictionary<string, byte> selectedServiceIDs = new System.Collections.Concurrent.ConcurrentDictionary<string, byte>();

        public FormServices()
        {
            InitializeComponent();
        }
        
        private void Services_Load(object sender, System.EventArgs e)
        {
            // load services from database
            List<Service> services = new List<Service>();
            using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand("select * from SERVICE where availiable > 0", sql))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            services.Add(new Service(reader["idService"].ToString(), reader["ServiceName"].ToString(), (long)reader["ServicePrice"], reader["Note"].ToString()));
                        }
                    }
                }
            }
            AddServices(services);
        }
        
        private void AddServices(List<Service> services)
        {
            foreach (Service s in services)
            {
                Services ss = new Services(s);
                if (!knownServices.ContainsKey(s.idService))
                {
                    this.flowLayoutPanel1.Controls.Add(ss);
                }
                FormServices.knownServices.AddOrUpdate(s.idService, ss, (key, oldValue) => ss);
            }
        }
        
        private void AddOneService(Service service)
        {
            Services ss = new Services(service);
            if (!knownServices.ContainsKey(ss.service.idService))
            {
                this.flowLayoutPanel1.Controls.Add(ss);
            }
            FormServices.knownServices.AddOrUpdate(ss.service.idService, ss, (key, oldValue) => ss);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "" || tbPrice.Text == "")
                {
                    MessageBox.Show("Nội dung bị thiếu");
                }
                else
                {
                    Service s = new Service();
                    s.idService = "";
                    s.ServiceName = this.tbName.Text;
                    s.ServicePrice = int.Parse(this.tbPrice.Text);
                    s.Note = (tbDetail.Text != null) ? tbDetail.Text : "";
                    using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();
                        // add menu to database
                        // if success add menu to list
                        s.idService = "SV" + WeddingClient.GetNewIdFromTable("SV").ToString().PadLeft(19, '0');
                        using (SqlCommand command = new SqlCommand("insert into SERVICE (idService, ServiceName, ServicePrice, Note) values (@idService, @ServiceName, @ServicePrice, @Note)", sql))
                        {
                            command.Parameters.AddWithValue("@idService", s.idService);
                            command.Parameters.AddWithValue("@ServiceName", s.ServiceName);
                            command.Parameters.AddWithValue("@ServicePrice", s.ServicePrice);
                            command.Parameters.AddWithValue("@Note", s.Note);
                            if (command.ExecuteNonQuery() > 0)
                            {
                                this.AddOneService(s);
                            }
                            else
                            {
                                MessageBox.Show("Thêm dịch vụ thất bại");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (string id in FormServices.selectedServiceIDs.Keys)
            {
                try
                {
                    Services s;
                    if (FormServices.knownServices.TryGetValue(id, out s))
                    {
                        Console.WriteLine(s.service.idService);
                        var service = s.service;
                        // delete from database, if success delete from list
                        using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
                        {
                            sql.Open();
                            using (SqlCommand command = new SqlCommand("update SERVICE set available = 0 where idService = @idService", sql))
                            {
                                command.Parameters.AddWithValue("@idService", service.idService);
                                if (command.ExecuteNonQuery() > 0)
                                {
                                    this.flowLayoutPanel1.Controls.Remove(s);
                                    FormServices.knownServices.TryRemove(service.idService, out Services _);
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi xảy ra");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
