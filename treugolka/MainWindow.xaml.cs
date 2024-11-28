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
            if (int.TryParse(SideA.Text, out int a) &&
                int.TryParse(SideB.Text, out int b) &&
                int.TryParse(SideC.Text, out int c))
            {
                if (a > 0 && b > 0 && c > 0)
                {

                    if (a + b > c && a + c > b && b + c > a)
                    {
                        string type;
                        string imagePath;
                        if (a == b && b == c)
                        {
                            type = "равносторонний";
                            imagePath = "Images/equilateral.png";
                        }
                        else if (a == b || b == c || a == c)
                        {
                            type = "равнобедренный";
                            imagePath = "Images/isosceles.png";
                        }
                        else
                        {
                            type = "разносторонний";
                            imagePath = "Images/scalene.png";
                        }

                        ResultText.Text = $"Полученный треугольник: {type}.";
                        SetTriangleImage(imagePath);
                        SwitchToResultView();
                    }
                    else
                    {
                        ResultText.Text = "Ошибка: треугольник с такими сторонами не существует.";
                        TriangleImage.Visibility = Visibility.Collapsed;
                        SwitchToResultView();
                    }
                }
                else
                {
                    ResultText.Text = "Ошибка: длины сторон должны быть больше 0.";
                    TriangleImage.Visibility = Visibility.Collapsed;
                    SwitchToResultView();
                }
            }
            else
            {
                ResultText.Text = "Ошибка: введите корректные целые значения сторон.";
                TriangleImage.Visibility = Visibility.Collapsed;
                SwitchToResultView();
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            SideA.Text = string.Empty;
            SideB.Text = string.Empty;
            SideC.Text = string.Empty;

            TriangleImage.Visibility = Visibility.Collapsed;

            SwitchToInputView();
        }

        private void SetTriangleImage(string imagePath)
        {
            try
            {
                TriangleImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                TriangleImage.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                TriangleImage.Visibility = Visibility.Collapsed;
            }
        }

        private void SwitchToResultView()
        {
            InputPanel.Visibility = Visibility.Collapsed;
            ResultPanel.Visibility = Visibility.Visible;
        }

        private void SwitchToInputView()
        {
            InputPanel.Visibility = Visibility.Visible;
            ResultPanel.Visibility = Visibility.Collapsed;
        }
    }
}

