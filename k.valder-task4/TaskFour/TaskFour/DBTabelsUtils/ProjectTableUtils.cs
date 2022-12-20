using MySqlConnector;
using TaskFour.DBUtils;

namespace TaskFour.DBTabelsUtils
{
    public static class ProjectTableUtils
    {
        public static string GetID(MySqlConnection conn, string name)
        {
            string data = "";
            conn.Open();
            string query = $"SELECT id FROM project WHERE name = '{name}'";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data = reader[0].ToString();
            }
            reader.Close();
            conn.Close();
            return data;
        }

        public static void Insert(MySqlConnection conn, string name)
        {
            conn.Open();
            string query = $"INSERT INTO project (id, name) " +
                $"VALUES ('{LastIdUtil.Get(conn)}','{name}')";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
