using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow: Window
    {
        /// <summary>
        /// Метод вызывает метод отрисовки фрактала "Множество Кантора".
        /// </summary>
        /// <param name="deep">глубина рекурсии</param>
        private void StartCantorSet(double deep)
        {
            DrawCantorSet(100, 50, 400, deep);
        }
        
        /// <summary>
        /// Метод рекурсивно строит фрактал "Множество Кантора"
        /// </summary>
        /// <param name="x">левая граница</param>
        /// <param name="y">верхняя граница</param>
        /// <param name="width">длина</param>
        /// <param name="deep">глубина</param>
        private void DrawCantorSet(int x, int y, int width, double deep)
        {
            if (width >= 3 && deep>0)
            {
                Rectangle rect = new Rectangle();
                Canvas.SetTop(rect, y);
                Canvas.SetLeft(rect, x);
                rect.Width = width;
                rect.Height = 12;
                //Отрезки изображаем прямоугольниками для наглядности
                rect.Fill = brush;
                mainCanvas.Children.Add(rect);

                //Сдвигаемся вниз
                y = y + 40;

                //Вызываем функцию для двух полученных отрезков
                DrawCantorSet(x + width * 2 / 3, y, width / 3, deep-1);
                DrawCantorSet(x, y, width / 3, deep-1);
            }
        }
        /// <summary>
        /// Обработчик выбора фрактала "Множество Кантора" в выпадающем списке.
        /// </summary>
        /// <param name="sender">элемент выпадающего списка</param>
        /// <param name="e">информация о событии</param>
        private void StartCantorSetHandler(object sender, RoutedEventArgs e)
        {
            Canvas.SetTop(mainCanvas, 0);
            Canvas.SetLeft(mainCanvas, 0);
            mainCanvas.Height = grid.Height;
            mainCanvas.Width = grid.Width;
            mainCanvas.Background = Brushes.AliceBlue;
            sliderDeep.Maximum = 5;
            mainCanvas.Children.Clear();
            fractal = StartCantorSet;
            fractal(sliderDeep.Value);
        }
    }
}
