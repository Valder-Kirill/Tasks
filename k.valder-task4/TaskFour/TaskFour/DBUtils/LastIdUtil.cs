using MySqlConnector;
using System.Data;

namespace TaskFour.DBUtils
{
    public static class LastIdUtil
    {
        public static long Get(MySqlConnection conn)
        {
            string query = "SELECT LAST_INSERT_ID() FROM test";
            MySqlCommand command = new MySqlCommand(query, conn);
            IDataReader reader = command.ExecuteReader();
            long id = 0;
            if (reader != null && reader.Read())
                id = reader.GetInt64(0);
            reader.Close();
            return id;
        }
    }
}
