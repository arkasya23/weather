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
using WpfApp2.Model;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TextBlock text;
        public string path = "";
        public MainWindow()
        {

            InitializeComponent();

            text = new TextBlock();
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Weather weather = new Weather();
            weather.CalculateFields();
            text.Text = weather.mainTemp.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Weather weather = new Weather();
            if (!string.IsNullOrEmpty(countryy.Text))
            {
                weather.country = countryy.Text;
            }

            if (!string.IsNullOrEmpty(cityy.Text))
            {
                weather.city = cityy.Text;
            }

            weather.CalculateFields();
            mainTemp.Text = weather.mainTemp.ToString();
            clouds.Text = weather.clouds.ToString();
            description.Text = weather.description.ToString();
            minTemp.Text = weather.minTemp.ToString();
            maxTemp.Text = weather.maxTemp.ToString();
            humidity.Text = weather.mainHumidity.ToString();
            pressure.Text = weather.mainPressure.ToString();

            BitmapImage b = new BitmapImage();

            if (weather.mainHumidity > 50)
            {
                path = "C:\\Users\\ioana.cirstoiu\\source\\repos\\WpfApp2\\WpfApp2\\Resources\\rainy.png";
               
            }
            else
            {
                path = "C:\\Users\\ioana.cirstoiu\\source\\repos\\WpfApp2\\WpfApp2\\Resources\\sunny.png";
            }
            b.BeginInit();
            b.UriSource = new Uri(path);
            b.EndInit();

            // ... Get Image reference from sender.
           
            // ... Assign Source.
            Image.Source = b;
            if(weather.mainHumidity > 50)
            {
                MessageBox.Show("Ia umbrela", "caption", MessageBoxButton.OK);
            }

        }
        private void TextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            if (!string.IsNullOrEmpty(path))
            {
                b.UriSource = new Uri(path);
                b.EndInit();

                // ... Get Image reference from sender.
                var image = sender as Image;
                // ... Assign Source.
                image.Source = b;
            }
        }

    }
}
 

