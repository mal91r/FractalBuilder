using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp2
{
    public partial class MainWindow: Window
    {
        /// <summary>
        /// Метод вызывает метод отрисовки фрактала "Ковер Серпинского", а так же создает синий квадрат - базу для фрактала
        /// </summary>
        /// <param name="deep">глубина рекурсии</param>
        private void StartSerpCarpet(double deep)
        {
            Canvas.SetTop(mainCanvas, 100);
            Canvas.SetLeft(mainCanvas, 100);
            mainCanvas.Height = 200;
            mainCanvas.Width = 200;
            mainCanvas.Background = Brushes.Blue;
            DrawSerpCarpet(100, 100, 200, deep);
        }

        /// <summary>
        /// Метод рекурсивно строит фраткал "Ковер Серпинского"
        /// </summary>
        /// <param name="x0">левая граница</param>
        /// <param name="y0">верхняя граница</param>
        /// <param name="length">длина стороны квадрата</param>
        /// <param name="deep">глубина рекурсии</param>
        private void DrawSerpCarpet(float x0, float y0, float length, double deep)
        {
            if (deep > 0)
            {
                System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
                Canvas.SetLeft(rect, x0 - length / 6);
                Canvas.SetTop(rect, y0 - length / 6);
                rect.Width = length / 3;
                rect.Height = length / 3;
                rect.Fill = brush;

                mainCanvas.Children.Add(rect);

                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {

                        if (deep > 1)
                        {
                            DrawSerpCarpet(x0 + j * length / 3, y0 + i * length / 3, length / 3, deep - 1);
                        }
                    }
                }
            }

        }
        /// <summary>
        /// Метод обрабатывает выбор фрактала "Ковер Серпинского" в выплывающем списке.
        /// </summary>
        /// <param name="sender">выплывающий список</param>
        /// <param name="e">информация о событии</param>
        private void StartSerpCarpetHandler(object sender, RoutedEventArgs e)
        {
            Canvas.SetTop(mainCanvas, 0);
            Canvas.SetLeft(mainCanvas, 0);
            mainCanvas.Height = grid.Height;
            mainCanvas.Width = grid.Width;
            mainCanvas.Background = Brushes.AliceBlue;
            sliderDeep.Maximum = 4;
            mainCanvas.Children.Clear();
            fractal = StartSerpCarpet;
            fractal(sliderDeep.Value-1);
        }
    }
}
