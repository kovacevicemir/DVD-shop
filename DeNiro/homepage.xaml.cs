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
using System.IO;
using Microsoft.Win32;


namespace DeNiro
{
    /// <summary>
    /// Interaction logic for homepage.xaml
    /// </summary>
    public partial class homepage : Page
    {
        public homepage()
        {
            InitializeComponent();
        }

        private void btn_add_movie_Click(object sender, RoutedEventArgs e)
        {
            //Create addmovie page and navigate
            addmovie addmovie = new addmovie();
            this.NavigationService.Navigate(addmovie);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create movielist page and navigate
            movielist movielist = new movielist();
            this.NavigationService.Navigate(movielist);
        }


        //::::READ FROM FILE:::::
        

        string pathToFile = "";
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Open dialog and get file
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == true)
            {
                MessageBox.Show("Importing from: \n" + theDialog.FileName.ToString());
                pathToFile = theDialog.FileName;
            }

            if (File.Exists(pathToFile))// only executes if the file at pathtofile exists
            {
                //count how many lines
                var lineCount = File.ReadLines(pathToFile).Count();

                int input_each_movie = 4; //each movie reads 4 lines
                int x = lineCount / input_each_movie; // Total lines / 4

                //Read data
                for (int i = 0; i < x; i++)
                {
                    if (i == 0)
                    {
                        try //If .txt file got less than 4 lines
                        {
                            string firstLine = File.ReadAllLines(pathToFile).Skip(0).Take(1).First();//selects first line of the file
                            string secondLine = File.ReadAllLines(pathToFile).Skip(1).Take(1).First();
                            string thirdLine = File.ReadAllLines(pathToFile).Skip(2).Take(1).First();
                            string forthLine = File.ReadAllLines(pathToFile).Skip(3).Take(1).First();

                            //Add movie to Movie.Moviez List :: Load 1,2,3,4 lines first
                            Movie NewMovie = new Movie { Name = firstLine, year = secondLine, genre = thirdLine, price = forthLine };
                            Movie.Moviez.Add(NewMovie);
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("format of .txt that you are trying to import is invalid");
                            return;
                        }

                    }
                    else
                    {

                        try //If .txt got less than (Movies * 4) Lines
                        {
                            int skip = i * input_each_movie; //Every iteration skip 4 rows for each first,second,third,4th Line

                            string firstLine = File.ReadAllLines(pathToFile).Skip(0 + skip).Take(1).First();//selects first line of the file
                            string secondLine = File.ReadAllLines(pathToFile).Skip(1 + skip).Take(1).First();
                            string thirdLine = File.ReadAllLines(pathToFile).Skip(2 + skip).Take(1).First();
                            string forthLine = File.ReadAllLines(pathToFile).Skip(3 + skip).Take(1).First();

                            //Add movie to Movie.Moviez List :: Load 1,2,3,4 lines first
                            Movie NewMovie = new Movie { Name = firstLine, year = secondLine, genre = thirdLine, price = forthLine };
                            Movie.Moviez.Add(NewMovie);
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("format of .txt that you are trying to import is invalid");
                            return;
                        }
                    }
                }
            }
        }


        //:::::WRITE TO FILE::::

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Create new save dialog
            var sfd = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*",
            };

            if (sfd.ShowDialog() == true)
            {
                //filename is path+filename
                string filename = sfd.FileName;
                
                int cv = 4; //number of lines each iteration
                int mc = Movie.Moviez.Count; //total movies

                //Write to .txt
                using (var sw = new StreamWriter(filename))
                {
                    for (int i = 0; i < mc; i++)
                    {
                        int skip = i * cv - 1; //After every iteration skip lines formula
                        if (i == 0)
                        {
                            string line_one = Movie.Moviez[i].Name;
                            sw.WriteLine(line_one, 1);
                            string line_two = Movie.Moviez[i].year;
                            sw.WriteLine(line_two, 2);
                            string line_three = Movie.Moviez[i].genre;
                            sw.WriteLine(line_three, 3);
                            string line_four = Movie.Moviez[i].price;
                            sw.WriteLine(line_four, 4);
                        }
                        else
                        {

                            string line_one = Movie.Moviez[i].Name;
                            sw.WriteLine(line_one, 0+skip);
                            string line_two = Movie.Moviez[i].year;
                            sw.WriteLine(line_two, 0+skip);
                            string line_three = Movie.Moviez[i].genre;
                            sw.WriteLine(line_three, 0+skip);
                            string line_four = Movie.Moviez[i].price;
                            sw.WriteLine(line_four, 0+skip);

                        }
                    }
                    MessageBox.Show("Exported to: \n" + filename);
                }
            }
        }
    }
}
