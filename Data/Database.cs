using MySQL.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace BlazorAppMySQL.Data
{
    public class Database
    {
        private readonly string MySQLConnectionString;

        public Database()
        {
            MySQLConnectionString = "server=127.0.0.1; Database=EmployeeDB; Uid=root; pwd=;";
        }

        public DataTable MySQLConnection_DataTable()
        {
            DataTable dtDaten = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
            {
                conn.Open();

                MySqlCommand selectCommand1 = new MySqlCommand("SELECT * FROM employee LIMIT 15", conn);

                using (MySqlDataReader rdr1 = selectCommand1.ExecuteReader())
                {
                    dtDaten.Load(rdr1);
                }

                conn.Close();
            }

            return dtDaten;
        }
    public void AddEmployee(string empId, string firstName, string lastName, string gender)
    {
        using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
        {
            conn.Open();

            // สร้างคำสั่ง SQL เพื่อเพิ่มข้อมูลลงในตาราง employee
            string sql = $"INSERT INTO employee (emp_id, first_name, last_name, gender) VALUES ('{empId}', '{firstName}', '{lastName}', '{gender}')";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
     public void DeleteEmployee(string empId)
    {
        using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
        {
            conn.Open();

            // สร้างคำสั่ง SQL เพื่อลบข้อมูลจากตาราง employee โดยใช้ employeeId เป็นเงื่อนไข
            string sql = $"DELETE FROM employee WHERE emp_id = '{empId}'";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

    // เมธอดอัปเดตข้อมูลในตาราง employee
    public void UpdateEmployee(string empId, string firstName, string lastName, string gender)
    {
        using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
        {
            conn.Open();

            // สร้างคำสั่ง SQL เพื่ออัปเดตข้อมูลในตาราง employee โดยใช้ employeeId เป็นเงื่อนไข
            string sql = $"UPDATE employee SET first_name = '{firstName}', last_name = '{lastName}', gender = '{gender}' WHERE emp_id = '{empId}'";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
        public DataTable GetDepartmentData()
        {
            DataTable dtDepartment = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
            {
                conn.Open();

                MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM department", conn);

                using (MySqlDataReader rdr = selectCommand.ExecuteReader())
                {
                    dtDepartment.Load(rdr);
                }

                conn.Close();
            }

            return dtDepartment;
        }
        public DataTable GetProjectData()
{
    DataTable dtProject = new DataTable();

    using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
    {
        conn.Open();

        MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM project", conn);

        using (MySqlDataReader rdr = selectCommand.ExecuteReader())
        {
            dtProject.Load(rdr);
        }

        conn.Close();
    }

    return dtProject;
}

    }
}
