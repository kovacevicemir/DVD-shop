using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

namespace DeNiro
{
    /// <summary>
    /// Interaction logic for addmovie.xaml
    /// </summary>
    public partial class addmovie : Page
    {
        public addmovie()

        {

            InitializeComponent();

        }

            string image_path;
    //Add Movie Button onClick
    private void btn_add_movie_Click(object sender, RoutedEventArgs e)
        {
            //Load data ::For testing only::
            //for(int i = 0; i < 10; i++)
            //{

            //Check if image is uploaded
            if(image_path == null)
            {
                MessageBox.Show("You need to upload image first");
                return;
            }

                string sebastian = input_movie_name.Text;
                string atol = input_genre.Text;
                string money = input_price.Text.ToString();
                string yearz = input_year.Text.ToString();

                //Check for empty fields
                if (sebastian == "" || atol == "" || money == "" || yearz == "")
                {
                    MessageBox.Show("Enter movie: name, year , genre and price first");
                    return;
                }

                //Check if year is integer
                int temp;
                bool successfullyParsed = int.TryParse(yearz, out temp);
                if (!successfullyParsed)
                {
                    MessageBox.Show("Please use digits only for year field.");
                    return;
                }

                //Check if price is double type
                double temp2;
                bool successfullyParsedPrice = double.TryParse(money, out temp2);
                if (!successfullyParsedPrice)
                {
                    MessageBox.Show("Please use digits only for price field.");
                    return;
                }

                //Check for special signs in name and genre fields
                string reg = @"^\w+( \w+)*$";
                Regex regex = new Regex(reg);
                if (!regex.IsMatch(sebastian) || !regex.IsMatch(atol))
                {
                    MessageBox.Show("Please dont use any !@$#/ special characters in Name/Genre field");
                    return;
                }


                Movie NewMovie = new Movie { Name = sebastian, genre = atol, price = money, year = yearz , image = image_path};
                Movie.Moviez.Add(NewMovie);

            //} Un-comment for testing, import 10 movies at once

            movielist movielist = new movielist();
            this.NavigationService.Navigate(movielist);
        }

        //Upload Button onClick
        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file_dialog = new OpenFileDialog();
            file_dialog.Title = "Select a picture";
            file_dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                 "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                 "Portable Network Graphic (*.png)|*.png";
            if(file_dialog.ShowDialog() == true)
            {
                tmp_new_movie_picture.Source = new BitmapImage(new Uri(file_dialog.FileName));
                image_path = file_dialog.FileName;
                //MessageBox.Show(image_path);
            }
        }

        private void btn_font_Click(object sender, RoutedEventArgs e)
        {
            if (btn_font.Content.ToString() == "_Font+")
            {
                addmovie addmovie = new addmovie();
                this.NavigationService.Navigate(addmovie);
                addmovie.btn_font.Content = "_Font-";
                addmovie.input_genre.FontSize = 15;
                addmovie.input_price.FontSize = 15;
                addmovie.input_year.FontSize = 15;
                addmovie.input_movie_name.FontSize = 15;
                addmovie.tx_instructions.FontSize = 15;
            }
            else
            {
                addmovie addmovie1 = new addmovie();
                this.NavigationService.Navigate(addmovie1);
                addmovie1.btn_font.Content = "_Font+";
                
            }
        }

    }

}
