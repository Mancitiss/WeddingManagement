using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    internal class Data
    {
        internal static void InitializeData()
        {
            InitializeRecruiterLevel();
            InitializeMaxTable();
        }
        //===================================================================================
        // recruiter level data
        private static int recruiterLevel;

        private static void InitializeRecruiterLevel()
        {
            try
            {
                using (var sql = new SqlConnection(Program.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand command = new SqlCommand("SELECT Value FROM PARAMETER where idParameter = @idParameter", sql))
                    {
                        command.Parameters.AddWithValue("@idParameter", "recruiter");
                        recruiterLevel = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        internal static int GetRecruiterLevel()
        {
            return recruiterLevel;
        }

        internal static void SetRecruiterLevel(int newRecruiterLevel)
        {
            try
            {
                using (var sql = new SqlConnection(Program.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE PARAMETER SET Value = @value WHERE idParameter = @idParameter", sql))
                    {
                        command.Parameters.AddWithValue("@value", newRecruiterLevel);
                        command.Parameters.AddWithValue("@idParameter", "recruiter");
                        command.ExecuteNonQuery();
                        recruiterLevel = newRecruiterLevel;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //=======================================================================================
        // MaxTable Data
        private static int maxTable;

        private static void InitializeMaxTable()
        {
            try
            {
                using (var sql = new SqlConnection(Program.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand command = new SqlCommand("SELECT Value FROM PARAMETER where idParameter = @idParameter", sql))
                    {
                        command.Parameters.AddWithValue("@idParameter", "maxTable");
                        maxTable = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        internal static int GetMaxTable()
        {
            return maxTable;
        }

        internal static void SetMaxTable(int newMaxTable)
        {
            try
            {
                using (var sql = new SqlConnection(Program.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE PARAMETER SET Value = @value WHERE idParameter = @idParameter", sql))
                    {
                        command.Parameters.AddWithValue("@value", newMaxTable);
                        command.Parameters.AddWithValue("@idParameter", "maxTable");
                        command.ExecuteNonQuery();
                        maxTable = newMaxTable;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //=======================================================================================
        
    }
}
