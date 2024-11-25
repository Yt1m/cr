using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApp1
{
    public class DatabaseHelper
    {
        private readonly string _connectionString = "server=localhost;database=MusicStore;user=root;password=password;";

        public DataTable ExecuteSelectQuery(string query, MySqlParameter[] parameters = null)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            using MySqlCommand command = new MySqlCommand(query, connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }
    }
}
