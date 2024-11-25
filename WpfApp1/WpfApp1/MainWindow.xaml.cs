using System.Collections.ObjectModel;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Ensemble> Ensembles { get; set; } = new ObservableCollection<Ensemble>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadEnsembles();
        }

        private void LoadEnsembles()
        {
            string query = "SELECT EnsembleID, Name FROM Ensembles";
            DataTable table = new DatabaseHelper().ExecuteSelectQuery(query);

            Ensembles.Clear();
            foreach (DataRow row in table.Rows)
            {
                Ensembles.Add(new Ensemble
                {
                    EnsembleID = (int)row["EnsembleID"],
                    Name = (string)row["Name"]
                });
            }
        }

        private void ShowMusicPieceCount_Click(object sender, RoutedEventArgs e)
        {
            if (EnsembleListBox.SelectedItem is Ensemble selectedEnsemble)
            {
                string query = "SELECT COUNT(*) FROM MusicPieces WHERE EnsembleID = @EnsembleID";
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@EnsembleID", selectedEnsemble.EnsembleID)
                };

                DataTable table = new DatabaseHelper().ExecuteSelectQuery(query, parameters);
                int count = int.Parse(table.Rows[0][0].ToString());
                MessageBox.Show($"Количество музыкальных произведений: {count}");
            }
        }

        private void ShowAlbumTitles_Click(object sender, RoutedEventArgs e)
        {
            if (EnsembleListBox.SelectedItem is Ensemble selectedEnsemble)
            {
                string query = "SELECT Title FROM Albums WHERE EnsembleID = @EnsembleID";
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@EnsembleID", selectedEnsemble.EnsembleID)
                };

                DataTable table = new DatabaseHelper().ExecuteSelectQuery(query, parameters);
                string titles = string.Join(", ", table.AsEnumerable().Select(row => row["Title"].ToString()));
                MessageBox.Show($"Альбомы: {titles}");
            }
        }

        private void ShowTopSellers_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT Title FROM Albums ORDER BY SoldThisYear DESC LIMIT 5";
            DataTable table = new DatabaseHelper().ExecuteSelectQuery(query);

            string titles = string.Join(", ", table.AsEnumerable().Select(row => row["Title"].ToString()));
            MessageBox.Show($"Лидеры продаж: {titles}");
        }

        private void OpenAlbumWindow_Click(object sender, RoutedEventArgs e)
        {
            new AlbumWindow().ShowDialog();
        }

        private void OpenEnsembleWindow_Click(object sender, RoutedEventArgs e)
        {
            new EnsembleWindow().ShowDialog();
        }
    }

    public class Ensemble
    {
        public int EnsembleID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
