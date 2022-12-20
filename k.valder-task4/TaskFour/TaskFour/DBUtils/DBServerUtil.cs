using MySqlConnector;

namespace TaskFour.UnionReportingDBUtils
{
    public static class DBServerUtil
    {
        public static MySqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" 
                + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}
