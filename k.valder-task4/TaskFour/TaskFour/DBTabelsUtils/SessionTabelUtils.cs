using MySqlConnector;
using TaskFour.DBUtils;

namespace TaskFour.DBTabelsUtils
{
    public static class SessionTabelUtils
    {
        public static string GetID(MySqlConnection conn, string sessionKey)
        {
            string data = "";
            conn.Open();
            string query = $"SELECT id FROM session WHERE session_key = '{sessionKey}'";
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

        public static void Insert(MySqlConnection conn, string session_key, string created_time, long build_number)
        {
            conn.Open();
            string query = $"INSERT INTO session (id, session_key, created_time, build_number) " +
                $"VALUES ('{LastIdUtil.Get(conn)}','{session_key}','{created_time}','{build_number}')";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
