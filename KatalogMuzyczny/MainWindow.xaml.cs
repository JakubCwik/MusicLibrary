using KatalogMuzyczny.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KatalogMuzyczny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MusicCatalogContext _dbContext = new MusicCatalogContext();
        public static int idAlbum;
        public MainWindow()
        {
            InitializeComponent();           
            LoadAlbums();
        }

        private void LoadAlbums()
        {
            var supplierUsers = _dbContext.SupplierUsers.Where(su => su.UserId == LoginUI.idUser);
            var supplierIds = supplierUsers.Select(su => su.SupplierId);
            var albums = _dbContext.Albums
                .Where(a => supplierIds.Contains(a.SupplierId))
                .Include(a => a.Artist)
                .Include(a => a.Supplier)
                .Include(a => a.Songs)                
                .ToList();

                AlbumsDataGrid.ItemsSource = albums;
        }

        private IQueryable<Album> FilterAlbumsByCategory(IQueryable<Album> albums, string category, string filterText)
        {
            var supplierUsers = _dbContext.SupplierUsers.Where(su => su.UserId == LoginUI.idUser);
            var supplierIds = supplierUsers.Select(su => su.SupplierId);

            switch (category)
            {
                case "Nazwa artysty":
                    return albums.Where(a => supplierIds.Contains(a.SupplierId) && a.Artist.Name.StartsWith(filterText))
                        .Where(a => supplierIds.Contains(a.SupplierId));

                case "Tytul albumu":
                    return albums.Where(a => supplierIds.Contains(a.SupplierId) && a.Title.StartsWith(filterText))
                        .Where(a => supplierIds.Contains(a.SupplierId));

                case "Rok wydania albumu":
                    if (Int32.TryParse(filterText, out int year))
                    {
                        return albums.Where(a => supplierIds.Contains(a.SupplierId) && a.Year.ToString().StartsWith(year.ToString()))
                            .Where(a => supplierIds.Contains(a.SupplierId));
                    }
                    else
                    {
                        return albums.Where(a => supplierIds.Contains(a.SupplierId));
                    }

                default:
                    return albums;
            }
        }


        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (NazwaArtystyRadioButton.IsChecked == true || TytulAlbumuRadioButton.IsChecked == true || RokWydaniaAlbumuRadioButton.IsChecked == true)
            {
                string category = ((RadioButton)FilterCategoryPanel.FindName("NazwaArtystyRadioButton")).IsChecked == true ? "Nazwa artysty" :
                    ((RadioButton)FilterCategoryPanel.FindName("TytulAlbumuRadioButton")).IsChecked == true ? "Tytul albumu" :
                    ((RadioButton)FilterCategoryPanel.FindName("RokWydaniaAlbumuRadioButton")).IsChecked == true ? "Rok wydania albumu" :
                    "";

                string filterText = FilterTextBox.Text;
                if (filterText == null)
                {
                    LoadAlbums();
                }
                else
                {
                    var filteredAlbums = FilterAlbumsByCategory(_dbContext.Albums, category, filterText).ToList();
                    AlbumsDataGrid.ItemsSource = filteredAlbums;
                }
            }
        }

        private void SelectedButton_Click(object sender, RoutedEventArgs e)
        {            
            Album album = (Album)AlbumsDataGrid.SelectedItem;

            if(album != null)
            {
                string artistName = album.Artist.Name;
                string title = album.Title;
                string version = album.Version;
                int year = album.Year;
                string supplier = album.Supplier.Name;

                idAlbum = _dbContext.Albums
                .FirstOrDefault(a => a.Title == title)?.Id ?? 0;
                AlbumsDataGrid.SelectedItem = null;

                AlbumDetails albumDetails = new AlbumDetails();
                albumDetails.Show();
            }               
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginUI loginUI = new LoginUI();
            loginUI.Show();
            Close();
        }
    }
}
