using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace treugolka
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckTriangle_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(SideA.Text, out double a) &&
                double.TryParse(SideB.Text, out double b) &&
                double.TryParse(SideC.Text, out double c))
            {
                TriangleImage.Visibility = Visibility.Collapsed;

                if (a + b > c && a + c > b && b + c > a)
                {
                    string type;
                    if (a == b && b == c)
                    {
                        type = "Равносторонний";
                        TriangleImage.Source = new BitmapImage(new Uri("Images/equilateral.png", UriKind.Relative));
                    }
                    else if (a == b || b == c || a == c)
                    {
                        type = "Равнобедренный";
                        TriangleImage.Source = new BitmapImage(new Uri("Images/isosceles.png", UriKind.Relative));
                    }
                    else
                    {
                        type = "Разносторонний";
                        TriangleImage.Source = new BitmapImage(new Uri("Images/scalene.png", UriKind.Relative));
                    }

                    ResultText.Text = $"Полученный треугольник: {type}.";
                    TriangleImage.Visibility = Visibility.Visible;
                }
                else
                {
                    ResultText.Text = "Ошибка: треугольник с такими сторонами не существует.";
                }
            }
            else
            {
                ResultText.Text = "Ошибка: введите корректные числовые значения для всех сторон.";
            }
        }
    }
}
