using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

                //Add upload picture button for each movie in the list
                System.Windows.Controls.Button newBtn = new Button();

                newBtn.Content = "Change picture";
                newBtn.Name = "btn" + i.ToString();

                //btn style
                newBtn.HorizontalAlignment = HorizontalAlignment.Center;
                newBtn.FontSize = 12;
                newBtn.Background = new SolidColorBrush(Colors.White) { Opacity = 0.5 };
                newBtn.Opacity = 0.92;
                newBtn.Margin = new Thickness(5, 5, 5, 5);
                newBtn.FontSize = f_size;
                newBtn.Click += new RoutedEventHandler(btn_replace_Click);
                sp.Children.Add(newBtn);

                //Upload button ends here

            }


            //::Ignore::Test only::
            //MessageBox.Show("current row " + current_row.ToString());
            //MessageBox.Show("current col " + current_col.ToString());
            //string movie_count = Movie.Moviez.Count.ToString();
            //MessageBox.Show("movie " + movie_count);
        }

        string img_path;
        private void btn_replace_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file_dialog = new OpenFileDialog();
            file_dialog.Title = "Select a picture";
            file_dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                 "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                 "Portable Network Graphic (*.png)|*.png";
            if (file_dialog.ShowDialog() == true)
            {
                img_path = file_dialog.FileName;

                //get button Name (in order to find that specific movie -> and replace image source
                string content = (sender as Button).Name;
                //remove 'btn' from btn name
                content =Regex.Replace(content, "[^0-9]", "");

                Movie.Moviez[Int32.Parse(content)].image = img_path;
                movielist movielist = new movielist(12);
                this.NavigationService.Navigate(movielist);

            }
        }

        private void btn_font_Click(object sender, RoutedEventArgs e)
        {
            //Check if user wants to enlarge font, if its already 20px than (else) reduce it to 12
            //and change btn content +-
            if(btn_font.Content.ToString() == "_Font+")
            {
                movielist movielist = new movielist(20);
                this.NavigationService.Navigate(movielist);
                movielist.btn_font.Content = "_Font-";
            }else
            {
                movielist movielist1 = new movielist(12);
                this.NavigationService.Navigate(movielist1);
                movielist1.btn_font.Content = "_Font+";
            }
            
        }
    }
}
