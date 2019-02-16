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

namespace DeNiro
{
    /// <summary>
    /// Interaction logic for movielist.xaml
    /// </summary>
    public partial class movielist : Page
    {
        //Movie book = new Movie();
        public movielist(int default_font = 12)
        {
            int f_size = 12; //default font size

            if(default_font != 12) //if movielist( have argument )
            {
                f_size = default_font;
            }

            InitializeComponent();

            //Get Data for each movie and generate list dynamically 
            int current_row = 0;
            for(int i = 0; i<Movie.Moviez.Count; i++)
            {
                string m_name = Movie.Moviez[i].Name;
                string m_genre = Movie.Moviez[i].genre;
                string m_year = Movie.Moviez[i].year;
                string m_price = Movie.Moviez[i].price;
                string m_image = Movie.Moviez[i].image;

                //set unique name for each panel
                StackPanel sp = new StackPanel()
                {
                    Name = "stackpanel" + i,
                };

                //Each stack panel settings
                sp.Background = Brushes.LavenderBlush;
                sp.Margin = new Thickness(100,5,100,5);

                //Add stack panel to movie list stack panel
                movie_list_sp.Children.Add(sp);

                //Add stack panel to next row for each iteration
                current_row = current_row + 1;
                Grid.SetRow(sp, current_row);

                //Add movie image and settings
                //Import feature does not support images atm :: check is image path null
                if(m_image != null)
                {
                    Image Img = new Image();
                    Img.Source = new BitmapImage(new Uri(m_image));
                    Img.Width = 400;
                    Img.Height = 300;
                    sp.Children.Add(Img);
                }

                //Text box for each movie
                sp.Children.Add(new TextBox {
                    Text = "Name: " + m_name + "\n" + "Year: " + m_year + "\n" + "Genre: " + m_genre + "\n" + "Price: $ " + m_price,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = f_size
                    });
            }

            
            //::Ignore::Test only::
            //MessageBox.Show("current row " + current_row.ToString());
            //MessageBox.Show("current col " + current_col.ToString());
            //string movie_count = Movie.Moviez.Count.ToString();
            //MessageBox.Show("movie " + movie_count);
        }

        private void btn_font_Click(object sender, RoutedEventArgs e)
        {
            movielist movielist = new movielist(20);
            this.NavigationService.Navigate(movielist);
        }
    }
}
