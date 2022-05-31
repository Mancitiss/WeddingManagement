using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WeddingManagementApplication
{
    public partial class NhanTiec : Form
    {
        public static string currentWeddingId = "";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table1 = new DataTable();
        
        public NhanTiec()
        {
            InitializeComponent();
            load_gridView_wedding();
            load_comboBox_shift();
            load_comboBox_lobby();
            load_comboBox_menu();
            load_comboBox_service();
        }

        void Load_data_wedding()
        {
            using(SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT LobbyName, ShiftName, Representative, PhoneNumber, BookingDate, WeddingDate, GroomName, BrideName, AmountOfTable, " +
                "AmountOfContingencyTable, TablePrice, Deposit FROM LOBBY LB, SHIFT S, WEDDING_INFOR WD WHERE WD.idShift = S.idShift AND WD.idLobby = LB.idLobby AND WD.available > 0", sql))
                {
                    adapter.SelectCommand = cmd;
                    table1.Clear();
                    adapter.Fill(table1);
                    dataWedding.DataSource = table1;
                }
            }
        }

        // đổ dữ liệu từ db lên gridView
        void load_gridView_wedding()
        {
            //load_data_wedding();
            DataColumn column;
            DataRow row;
            // Create first column and add to the DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "lobbyName";
            column.AutoIncrement = false;
            column.Caption = "Lobby name";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the column to the DataColumnCollection.
            table1.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "shiftName";
            column.AutoIncrement = false;
            column.Caption = "Shift";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create third column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "representative";
            column.AutoIncrement = false;
            column.Caption = "Representative";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create fourth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "phoneNumber";
            column.AutoIncrement = false;
            column.Caption = "Phone number";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create fifth column
            column = new DataColumn();
            // set datetype as datetime
            column.DataType = System.Type.GetType("System.DateTime");
            // set format as dd/MM/yyyy
            column.DateTimeMode = DataSetDateTime.Unspecified;
            column.ColumnName = "bookingDate";
            column.AutoIncrement = false;
            column.Caption = "Booking date";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);
            
            // create sixth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            // dd/MM/yyyy
            column.DateTimeMode = DataSetDateTime.Unspecified;
            column.ColumnName = "weddingDate";
            column.AutoIncrement = false;
            column.Caption = "Wedding date";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create seventh column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "groomName";
            column.AutoIncrement = false;
            column.Caption = "Groom name";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create eighth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "brideName";
            column.AutoIncrement = false;
            column.Caption = "Bride name";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create ninth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "amountOfTable";
            column.AutoIncrement = false;
            column.Caption = "Amount of table";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create tenth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "amountOfContingencyTable";
            column.AutoIncrement = false;
            column.Caption = "Amount of contingency table";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create eleventh column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "tablePrice";
            column.AutoIncrement = false;
            column.Caption = "Table price";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create twelfth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "deposit";
            column.AutoIncrement = false;
            column.Caption = "Deposit";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create thirteenth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "idWedding";
            column.AutoIncrement = false;
            column.Caption = "idWedding";
            column.ReadOnly = false;
            column.Unique = false;
            column.ColumnMapping = MappingType.Hidden;
            table1.Columns.Add(column);

            dataWedding.DataSource = table1;
            foreach (DataGridViewColumn col in dataWedding.Columns)
            {
                col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
            }
            dataWedding.Columns["bookingDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataWedding.Columns["weddingDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataWedding.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataWedding_RowHeaderMouseClick);
        }

        private void dataWedding_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // select weddingID
            NhanTiec.currentWeddingId = table1.Rows[e.RowIndex]["idWedding"].ToString();
            Console.WriteLine(NhanTiec.currentWeddingId);
        }


        // đổ dữ liệu từ db lên comboBox shift
        void load_comboBox_shift()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT idShift, ShiftName, Starting, Ending FROM SHIFT where available > 0", sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            WeddingClient.listShifts = new List<ShiftData>();
                            var dt = new DataTable();
                            dt.Load(dr);
                            cbb_shift.DataSource = dt;
                            cbb_shift.DisplayMember = "ShiftName";
                            foreach (DataRow row in dt.Rows)
                            {
                                WeddingClient.listShifts.Add(new ShiftData()
                                {
                                    idShift = row["idShift"].ToString(),
                                    name = row["ShiftName"].ToString(),
                                    startingTime = (TimeSpan)row["Starting"],
                                    endingTime = (TimeSpan)row["Ending"]
                                });;
                            }
                        }
                    }
                }
            }
        }

        // đổ dữ liệu từ db lên comboBox lobby
        void load_comboBox_lobby()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT idLobby, idLobbyType, LobbyName, MaxTable, Note FROM LOBBY WHERE available > 0", sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            WeddingClient.listLobbies = new List<LobbyData>();
                            var dt = new DataTable();
                            dt.Load(dr);
                            dr.Dispose();
                            cbb_lobby.DataSource = dt;
                            cbb_lobby.DisplayMember = "LobbyName";
                            foreach (DataRow row in dt.Rows)
                            {
                                WeddingClient.listLobbies.Add(new LobbyData(row["idLobby"].ToString(), row["idLobbyType"].ToString(), row["LobbyName"].ToString(), Convert.ToInt32(row["MaxTable"]), row["Note"].ToString()));
                            }
                        }
                    }
                }
            }
        }

        // đổ dữ liệu từ db lên comboBox menu
        void load_comboBox_menu()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT idDishes, DishesName, DishesPrice FROM MENU where available > 0", sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            WeddingClient.listDishes = new List<DishesData>();
                            var dt = new DataTable(); 
                            dt.Load(dr);
                            cbb_dishes.DataSource = dt;
                            cbb_dishes.DisplayMember = "DishesName";
                            // create list dishes from dt
                            foreach (DataRow row in dt.Rows)
                            {
                                WeddingClient.listDishes.Add(new DishesData()
                                {
                                    idDishes = (row["idDishes"]).ToString(),
                                    DishesName = row["DishesName"].ToString(),
                                    DishesPrice = Convert.ToInt64(row["DishesPrice"])
                                });
                            }
                            tb_price_dishes.Text = WeddingClient.listDishes[0].DishesPrice.ToString() + " VND";
                        }
                    }
                }
            }
        }


        // đổ dữ liệu từ db lên comboBox service
        void load_comboBox_service()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT idService, ServiceName, ServicePrice, Note FROM SERVICE where available > 0", sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            WeddingClient.listServices = new List<Service>();
                            var dt = new DataTable();
                            dt.Load(dr);
                            cbb_service.DataSource = dt;
                            cbb_service.DisplayMember = "ServiceName";
                            // create list dishes from dt
                            foreach (DataRow row in dt.Rows)
                            {
                                WeddingClient.listServices.Add(new Service()
                                {
                                    idService = (row["idService"]).ToString(),
                                    ServiceName = row["ServiceName"].ToString(),
                                    ServicePrice = Convert.ToInt64(row["ServicePrice"]),
                                    Note = row["Note"].ToString()
                                });
                            }
                            tb_service_price.Text = WeddingClient.listDishes[0].DishesPrice.ToString() + " VND";
                        }
                    }
                }
            }
        }
        
        private void cbb_dishes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get index of selected item
            int index = cbb_dishes.SelectedIndex;
            // get DishesData from listDishes at index
            DishesData dishes = WeddingClient.listDishes[index];
            // set textbox price
            tb_price_dishes.Text = dishes.DishesPrice.ToString() + " VND";
        }

        private void cbb_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get index of selected item
            int index = cbb_service.SelectedIndex;
            // get DishesData from listDishes at index
            Service service = WeddingClient.listServices[index];
            // set textbox price
            tb_service_price.Text = service.ServicePrice.ToString() + " VND";
        }




        // cái hàm này để khi ấn vô cái dòng dữ liệu thì mấy ô mình nhập hiện lên các dữ liệu của dòng đó
        //private void table1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //int i;
        //    //i = dataWedding.CurrentRow.Index;
        //    //tb_representative.Text = dataWedding.Rows[i].Cells[0].Value.ToString();
        //    //tb_phone.Text = dataWedding.Rows[i].Cells[1].Value.ToString();
        //    //date_booking.Text = dataWedding.Rows[i].Cells[2].Value.ToString();
        //    //date_wedding.Text = dataWedding.Rows[i].Cells[3].Value.ToString();
        //    //tb_groom.Text = dataWedding.Rows[i].Cells[4].Value.ToString();
        //    //tb_bride.Text = dataWedding.Rows[i].Cells[5].Value.ToString();
        //    //tb_table.Text = dataWedding.Rows[i].Cells[6].Value.ToString();
        //    //tb_contigency.Text = dataWedding.Rows[i].Cells[7].Value.ToString();
        //    //tb_deposit.Text = dataWedding.Rows[i].Cells[8].Value.ToString();
        //}


        // set sự kiện button xem chi tiết thông tin menu
        private void btn_detail_dishes_Click(object sender, EventArgs e)
        {
            gridView_dishes show = new gridView_dishes();
            show.ShowDialog();

        }

        // sự kiện cho button detail service
        private void btn_detail_service_Click(object sender, EventArgs e)
        {
            gridView_service show = new gridView_service();
            show.ShowDialog();
        }


        // sự kiện cho btn add wedding
        private void btn_add_wedding_Click(object sender, EventArgs e)
        {
            // get index of selected item from shift combobox
            int index = cbb_shift.SelectedIndex;
            // get shift from listShift at index
            ShiftData shift = WeddingClient.listShifts[index];
            // get index of selected item from lobby combobox
            int indexLobby = cbb_lobby.SelectedIndex;
            // get lobbyType in listLobbyType at index
            LobbyData lobby = WeddingClient.listLobbies[indexLobby];
            
            using(SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                // complete command for me
                string newId = "WD" + WeddingClient.GetNewIdFromTable("WD").ToString();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO WEDDING_INFOR (idWedding, idLobby, idShift, BookingDate, WeddingDate, PhoneNumber, GroomName, BrideName, AmountOfTable, AmountOfContingencyTable, TablePrice, Deposit, representative) VALUES (@idWedding, @idLobby, @idShift, @BookingDate, @WeddingDate, @PhoneNumber, @GroomName, @BrideName, @AmountOfTable, @AmountOfContingencyTable, @TablePrice, @Deposit, @representative )", sql))
                {
                    cmd.Parameters.AddWithValue("@idWedding", newId);
                    cmd.Parameters.AddWithValue("@idLobby", lobby.idLobby);
                    cmd.Parameters.AddWithValue("@idShift", shift.idShift);
                    cmd.Parameters.AddWithValue("@BookingDate", date_booking.Value);
                    cmd.Parameters.AddWithValue("@WeddingDate", date_wedding.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", tb_phone.Text);
                    cmd.Parameters.AddWithValue("@GroomName", tb_groom.Text);
                    cmd.Parameters.AddWithValue("@BrideName", tb_bride.Text);
                    cmd.Parameters.AddWithValue("@AmountOfTable", Convert.ToInt32(tb_table.Text));
                    cmd.Parameters.AddWithValue("@AmountOfContingencyTable", Convert.ToInt32(tb_contigency.Text));
                    cmd.Parameters.AddWithValue("@TablePrice", 0);
                    cmd.Parameters.AddWithValue("@Deposit", Convert.ToInt32(tb_deposit.Text));
                    cmd.Parameters.AddWithValue("@representative", tb_representative.Text);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        //Load_data_wedding();
                        // add wedding information to table 1
                        //dataWedding.Rows.Add(lobby.LobbyName, shift.name, tb_representative.Text, tb_phone.Text, date_booking.Value.ToString(), date_wedding.Value.ToString(), tb_groom.Text, tb_bride.Text, tb_table.Text, tb_contigency.Text, tb_deposit.Text);
                        // add the above row to table1
                        DataRow row = table1.NewRow();
                        row.ItemArray = new object[] { lobby.LobbyName, shift.name, tb_representative.Text, tb_phone.Text, date_booking.Value.ToString(), date_wedding.Value.ToString(), tb_groom.Text, tb_bride.Text, tb_table.Text, tb_contigency.Text, 0, tb_deposit.Text, newId };
                        table1.Rows.Add(row);
                        MessageBox.Show("New wedding created", "SUCCESS", MessageBoxButtons.OK);
                    }
                }
            }
        }

        // set sự kiện cho btn delete wedding
        private void btn_delete_wedding_Click(object sender, EventArgs e)
        {
            // chck if currentWeddingId is not null and length is 21
            if (currentWeddingId != null && currentWeddingId.Length == 21)
            {
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    // complete command for me
                    using (SqlCommand cmd = new SqlCommand("UPDATE WEDDING_INFOR set available = 0 WHERE idWedding = @idWedding", sql))
                    {
                        cmd.Parameters.AddWithValue("@idWedding", currentWeddingId);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            //Load_data_wedding();
                            // delete row in table1
                            //dataWedding.Rows.RemoveAt(dataWedding.CurrentRow.Index);
                            table1.Rows.RemoveAt(dataWedding.CurrentRow.Index);
                            MessageBox.Show("Wedding deleted", "SUCCESS", MessageBoxButtons.OK);
                            NhanTiec.currentWeddingId = "";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a wedding to delete", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }
    }
}
