using KatalogMuzyczny.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for LoginUI.xaml
    /// </summary>
    public partial class LoginUI : Window
    {
        private readonly ObservableCollection<Supplier> suppliers = new ObservableCollection<Supplier>();
        private MusicCatalogContext _dbContext = new MusicCatalogContext();
        public static int idUser;

        public LoginUI()
        {
            InitializeComponent();

            using (var context = new MusicCatalogContext())
            {
                //Dodanie przykładowych danych, odkomentowac, zaladowac dane i zakomentowac 

               /* var addUser = new User { Login = "jan_kowalski", Password = "password123" };
                context.Users.Add(addUser);
                context.SaveChanges();

                var addSuplier = new Supplier { Name = "Sony Music Entertainment", Address = "United States" };
                context.Suppliers.Add(addSuplier);
                context.SaveChanges();

                var addArtist = new Artist { Name = "Dawid Podsiadło" };
                context.Artists.Add(addArtist);
                context.SaveChanges();

                var addAlbum = new Album { Title = "Małomiasteczkowy", Version = "Akustyczna", Year = 2018, ArtistId = addArtist.Id, SupplierId = addSuplier.Id };
                context.Albums.Add(addAlbum);
                context.SaveChanges();

                var addSupplierUser = new SupplierUser {  SupplierId = addSuplier.Id , UserId = addUser.Id};
                context.SupplierUsers.Add(addSupplierUser);
                context.SaveChanges();

                var addMusic = new Song { Title = "Nie ma fal", TrackNumber = 1, AlbumId = addAlbum.Id, SongDuration = new TimeSpan(0, 2, 55) };
                var addMusic1 = new Song { Title = "Trofea", TrackNumber = 2, AlbumId = addAlbum.Id, SongDuration = new TimeSpan(0, 3, 10) };
                var addMusic2 = new Song { Title = "Matylda", TrackNumber = 3, AlbumId = addAlbum.Id, SongDuration = new TimeSpan(0, 3, 15) };
                var addMusic3 = new Song { Title = "LIS", TrackNumber = 4, AlbumId = addAlbum.Id, SongDuration = new TimeSpan(0, 3, 25) };
                var addMusic4 = new Song { Title = "Małomiasteczkowy", TrackNumber = 5, AlbumId = addAlbum.Id, SongDuration = new TimeSpan(0, 3, 23) };
                context.Songs.Add(addMusic);
                context.Songs.Add(addMusic1);
                context.Songs.Add(addMusic2);
                context.Songs.Add(addMusic3);
                context.Songs.Add(addMusic4);
                context.SaveChanges();

                

                var addArtist1 = new Artist { Name = "Michael Jackson" };
                context.Artists.Add(addArtist1);
                context.SaveChanges();

                var addAlbum1 = new Album { Title = "Thriller", Version = "CD", Year = 1982, ArtistId = addArtist1.Id, SupplierId = addSuplier.Id };
                context.Albums.Add(addAlbum1);
                context.SaveChanges();

                var addMusic0_2 = new Song { Title = "Wanna Be Startin's Somethin", TrackNumber = 1, AlbumId = addAlbum1.Id, SongDuration = new TimeSpan(0, 2, 55) };
                var addMusic1_2 = new Song { Title = "Baby Be Mine", TrackNumber = 2, AlbumId = addAlbum1.Id, SongDuration = new TimeSpan(0, 3, 10) };
                var addMusic2_2 = new Song { Title = "The Girl Is Mine", TrackNumber = 3, AlbumId = addAlbum1.Id, SongDuration = new TimeSpan(0, 3, 15) };
                var addMusic3_2 = new Song { Title = "Thriller", TrackNumber = 4, AlbumId = addAlbum1.Id, SongDuration = new TimeSpan(0, 4, 25) };
                var addMusic4_2 = new Song { Title = "Beat It", TrackNumber = 5, AlbumId = addAlbum1.Id, SongDuration = new TimeSpan(0, 3, 00) };
                var addMusic5_2 = new Song { Title = "Billie Jean", TrackNumber = 6, AlbumId = addAlbum1.Id, SongDuration = new TimeSpan(0, 3, 13) };
                var addMusic6_2 = new Song { Title = "Human Nature", TrackNumber = 7, AlbumId = addAlbum1.Id, SongDuration = new TimeSpan(0, 3, 43) };
                var addMusic7_2 = new Song { Title = "P.Y.T", TrackNumber = 8, AlbumId = addAlbum1.Id, SongDuration = new TimeSpan(0, 3, 50) };
                var addMusic8_2 = new Song { Title = "The Lady in My Life", TrackNumber = 9, AlbumId = addAlbum1.Id, SongDuration = new TimeSpan(0, 4, 23) };
                context.Songs.Add(addMusic0_2);
                context.Songs.Add(addMusic1_2);
                context.Songs.Add(addMusic2_2);
                context.Songs.Add(addMusic3_2);
                context.Songs.Add(addMusic4_2);
                context.Songs.Add(addMusic5_2);
                context.Songs.Add(addMusic6_2);
                context.Songs.Add(addMusic7_2);
                context.Songs.Add(addMusic8_2);
                context.SaveChanges();

                var addUser0_3 = new User { Login = "piotr_nowak", Password = "password123" };
                context.Users.Add(addUser0_3);
                context.SaveChanges();

                var addSuplier1_3 = new Supplier { Name = "Kayax", Address = "Warszawa" };
                context.Suppliers.Add(addSuplier1_3);
                context.SaveChanges();

                var addArtist2_3 = new Artist { Name = "Kayah" };
                context.Artists.Add(addArtist2_3);
                context.SaveChanges();

                var addAlbum3_3 = new Album { Title = "Kamień", Version = "CD", Year = 1995, ArtistId = addArtist2_3.Id, SupplierId = addSuplier1_3.Id };
                context.Albums.Add(addAlbum3_3);
                context.SaveChanges();

                var addSupplierUser4_3 = new SupplierUser { SupplierId = addSuplier1_3.Id, UserId = addUser0_3.Id };
                context.SupplierUsers.Add(addSupplierUser4_3);
                context.SaveChanges();

                var addMusic0_3 = new Song { Title = "Nawet Deszcz", TrackNumber = 1, AlbumId = addAlbum3_3.Id, SongDuration = new TimeSpan(0, 6, 21) };
                var addMusic1_3 = new Song { Title = "Jestem Kamieniem", TrackNumber = 2, AlbumId = addAlbum3_3.Id, SongDuration = new TimeSpan(0, 3, 21) };
                var addMusic2_3 = new Song { Title = "Ja Chce Ciebie", TrackNumber = 3, AlbumId = addAlbum3_3.Id, SongDuration = new TimeSpan(0, 3, 15) };
                var addMusic3_3 = new Song { Title = "Jak Liść", TrackNumber = 4, AlbumId = addAlbum3_3.Id, SongDuration = new TimeSpan(0, 3, 25) };
                var addMusic4_3 = new Song { Title = "Fleciki", TrackNumber = 5, AlbumId = addAlbum3_3.Id, SongDuration = new TimeSpan(0, 3, 23) };
                context.Songs.Add(addMusic0_3);
                context.Songs.Add(addMusic1_3);
                context.Songs.Add(addMusic2_3);
                context.Songs.Add(addMusic3_3);
                context.Songs.Add(addMusic4_3);
                context.SaveChanges();
               */
            }

                using (var db = new MusicCatalogContext())
            {
                var supplierNames = db.Suppliers.Select(s => s.Name).Distinct().ToList();
                foreach (var name in supplierNames)
                {
                    suppliers.Add(new Supplier { Name = name });
                }
            }

            DataContext = this;
        }

        // Właściwość dostawców, którą będziemy powiązywać z ComboBoxem.
        public ObservableCollection<Supplier> Suppliers
        {
            get { return suppliers; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = tx_login.Text;
            string password = tx_password.Password;

            using (var db = new MusicCatalogContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Login == login);
                if (user == null)
                {
                    MessageBox.Show("Niepoprawny login lub hasło.");
                    return;
                }

                // sprawdź, czy hasło jest poprawne
                if (user.Password != password)
                {
                    MessageBox.Show("Niepoprawny login lub hasło.");
                    return;
                }

                idUser = _dbContext.Users
                .FirstOrDefault(u => u.Login == login && u.Password == password)?.Id ?? 0;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    }
}