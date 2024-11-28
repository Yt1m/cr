using System.Data.SQLite;
using System.Windows;
using System.Windows.Media.Media3D;

namespace MusicStoreApp
{
    public partial class RecordsWindow : Window
    {
        public RecordsWindow()
        {
            InitializeComponent();
            LoadRecords();
        }

        private void LoadRecords()
        {
            // Здесь будет ваш запрос к базе данных
            SQLiteConnection connection = new SQLiteConnection("Data Source=MusicStore.db");
            connection.Open();
            string query = "SELECT * FROM Records"; // Пример запроса, используйте свои данные
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();

            // Предположим, что Record - это ваш класс модели
            List<Record> records = new List<Record>();

            while (reader.Read())
            {
                records.Add(new Record
                {
                    Title = reader["Title"].ToString(),
                    Artist = reader["Artist"].ToString(),
                    ReleaseDate = reader["ReleaseDate"].ToString()
                });
            }

            RecordsDataGrid.ItemsSource = records;
        }
    }
}
