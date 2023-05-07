using KatalogMuzyczny.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KatalogMuzyczny
{
    /// <summary>
    /// Interaction logic for AlbumDetails.xaml
    /// </summary>
    public partial class AlbumDetails : Window
    {
        private MusicCatalogContext _dbContext = new MusicCatalogContext();
        public AlbumDetails()
        {
            InitializeComponent();
            LoadMusic();


        }
        private void LoadMusic()
        {
            var music = _dbContext.Songs
            .Where(s => s.AlbumId == MainWindow.idAlbum)
            .Select(s => new
            {
                Artysta = s.Album.Artist.Name,
                Tytul = s.Title,
                RokWydania = s.Album.Year,
                CzasTrwania = s.SongDuration
            })
        .ToList();

            AlbumDetailsGrid.ItemsSource = music;
        }
    }

}

