using MySqlConnector;
using TaskFour.DBUtils;

namespace TaskFour.DBTabelsUtils
{
    public static class AuthorTableUtils
    {
        public static string GetID(MySqlConnection conn, string name)
        {
            string data = "";
            conn.Open();
            string query = $"SELECT id FROM author WHERE name = '{name}'";
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

        public static void Insert(MySqlConnection conn, string name, string login, string email)
        {
            conn.Open();
            string query = $"INSERT INTO author (id, name, login, email) " +
                $"VALUES ('{LastIdUtil.Get(conn)}','{name}','{login}','{email}')";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
