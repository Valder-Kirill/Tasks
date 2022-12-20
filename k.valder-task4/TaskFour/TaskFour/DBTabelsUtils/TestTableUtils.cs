using MySqlConnector;
using System;
using TaskFour.DBUtils;

namespace TaskFour.DBTabelsUtils
{
    public static class TestTableUtils
    {
        public static long Insert(MySqlConnection conn, string name, int status_id, string method_name, long project_id,
            long session_id, string start_time, string end_time, string env, string browser, long userID)
        {
            conn.Open();

            if (name == "")
                name = "NULL";
            if (method_name == "")
                method_name = "NULL";
            if (env == "")
                env = "NULL";
            if (browser == "")
                browser = "NULL";
            long id = LastIdUtil.Get(conn);
            string query = $"INSERT INTO test (id, name, status_id, method_name, project_id, session_id, " +
                $"start_time, end_time, env, browser, author_id) " +
                $"VALUES ('{id}','{name}', '{status_id}', '{method_name}', '{project_id}', '{session_id}', '{start_time}'," +
                $" '{end_time}', '{env}', '{browser}', '{userID}')";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
            return id;
        }

        public static string[] GetAllID(MySqlConnection conn)
        {
            string[] data = new string[1];
            conn.Open();
            string query = $"SELECT id FROM test";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            int n = 1;
            while (reader.Read())
            {
                Array.Resize(ref data, data.Length + 1);
                data[n] = reader[0].ToString();
                n++;
            }
            reader.Close();
            conn.Close();
            return data;
        }

        public static string[] GetDataIfID(MySqlConnection conn, string id)
        {
            string[] data = new string[1];
            conn.Open();
            string query = $"SELECT name, status_id, method_name, project_id, session_id, " +
                $"start_time, end_time, env, browser  FROM test WHERE id = {id}";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < 9; i++)
                {
                    Array.Resize(ref data, data.Length + 1);
                    data[i] = reader[i].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return data;
        }

        public static void Delete(MySqlConnection conn, string name, string method_name, long project_id,
            long session_id, string start_time, string end_time, string env, string browser, long authorID)
        {
            conn.Open();
            string query = $"DELETE FROM test WHERE name = '{name}' AND method_name = '{method_name}' AND" +
                $" project_id = '{project_id}' AND session_id = '{session_id}' AND start_time = '{start_time}' AND" +
                $" end_time = '{end_time}' AND env = '{env}' AND browser = '{browser}' AND author_id = '{authorID}'";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
