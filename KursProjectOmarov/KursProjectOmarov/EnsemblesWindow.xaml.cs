using System.Data.SQLite;
using System.Windows;

namespace MusicStoreApp
{
    public partial class EnsemblesWindow : Window
    {
        public EnsemblesWindow()
        {
            InitializeComponent();
            LoadEnsembles();
        }

        private void LoadEnsembles()
        {
            // Здесь будет ваш запрос к базе данных
            SQLiteConnection connection = new SQLiteConnection("Data Source=MusicStore.db");
            connection.Open();
            string query = "SELECT * FROM Ensembles"; // Пример запроса, используйте свои данные
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();

            // Предположим, что Ensemble - это ваш класс модели
            List<Ensemble> ensembles = new List<Ensemble>();

            while (reader.Read())
            {
                ensembles.Add(new Ensemble
                {
                    Name = reader["Name"].ToString(),
                    Genre = reader["Genre"].ToString()
                });
            }

            EnsemblesDataGrid.ItemsSource = ensembles;
        }
    }
}
