using System.Data.SQLite;
using System.Windows;

namespace MusicStoreApp
{
    public partial class MusicalWorksWindow : Window
    {
        public MusicalWorksWindow()
        {
            InitializeComponent();
            LoadMusicalWorks();
        }

        private void LoadMusicalWorks()
        {
            // Здесь будет ваш запрос к базе данных
            SQLiteConnection connection = new SQLiteConnection("Data Source=MusicStore.db");
            connection.Open();
            string query = "SELECT * FROM MusicalWorks"; // Пример запроса, используйте свои данные
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();

            // Предположим, что MusicalWork - это ваш класс модели
            List<MusicalWork> works = new List<MusicalWork>();

            while (reader.Read())
            {
                works.Add(new MusicalWork
                {
                    Name = reader["Name"].ToString(),
                    Composer = reader["Composer"].ToString()
                });
            }

            MusicalWorksDataGrid.ItemsSource = works;
        }
    }
}
