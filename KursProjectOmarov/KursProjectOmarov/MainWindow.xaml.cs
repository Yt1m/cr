using System.Windows;

namespace MusicStoreApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowMusicalWorks_Click(object sender, RoutedEventArgs e)
        {
            // Создание окна для отображения музыкальных произведений
            MusicalWorksWindow musicalWorksWindow = new MusicalWorksWindow();
            musicalWorksWindow.Show();
        }

        private void ShowEnsembles_Click(object sender, RoutedEventArgs e)
        {
            // Создание окна для отображения ансамблей
            EnsemblesWindow ensemblesWindow = new EnsemblesWindow();
            ensemblesWindow.Show();
        }

        private void ShowRecords_Click(object sender, RoutedEventArgs e)
        {
            // Создание окна для отображения пластинок
            RecordsWindow recordsWindow = new RecordsWindow();
            recordsWindow.Show();
        }
    }
}
