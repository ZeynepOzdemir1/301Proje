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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Library301
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        int user_id { get; set; }
        public static ListView Books;
        Login newLogin = new Login();
        private User logedUser;
        LibraryDbContext Db = new LibraryDbContext();
        public MainWindow(User loginUser)
        {
            InitializeComponent();

            Load();
            logedUser = loginUser;
            user_id = loginUser.Id;

            
        }

        public void Load()
        {

            var myBooks = (from b in Db.Books
                           join r in Db.Rents
            on b.Id equals r.BookId
                           join u in Db.Users on r.UserId equals u.Id
                           select new
                           {
                               RentId = r.Id,
                               BookName = b.BookName,
                               Author = b.Author,
                               StartDate = r.StartDate,
                               EndDate = r.EndDate
                           }).ToList();


            BookList.ItemsSource = Db.Books.ToList();
            Books = BookList;
            MyBooksList.ItemsSource = myBooks;
        }



        private void rentBtn(object sender, RoutedEventArgs e)
        {
            int bookId = (BookList.SelectedItem as Book).Id;
            if ((BookList.SelectedItem as Book).Rented == true)
            {
                MessageBox.Show("Kitap mevcut değil.");
            }
            else
            {
                Rent newRent = new Rent()
                {
                    BookId = bookId,
                    UserId = user_id,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(14)

                };
                Db.Rents.Add(newRent);
                Db.SaveChanges();
                MessageBox.Show("Kiralandı.");
            }
            
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            newLogin.Show();
            this.Close();
        }

        private void passwordBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(logedUser);
            changePasswordWindow.ShowDialog();
        }
    }
}