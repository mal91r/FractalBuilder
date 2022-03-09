using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow: Window
    {
        /// <summary>
        /// Вызывает метод отрисовки фрактала "Треугольник Серпинского"
        /// </summary>
        /// <param name="deep">глубина рекурсии</param>
        private void StartSerpTriangle(double deep)
        {
            DrawSerpTriangle(deep, 250, 50, 100, 200, 400, 200);
        }
        /// <summary>
        /// Метод рекурскивно строит фрактал "Треугольник Серпинского"
        /// </summary>
        /// <param name="deep">глубина рекурсии</param>
        /// <param name="xTop">х-координата верхней точки треугольника</param>
        /// <param name="yTop">у-координата верхней точки треугольника</param>
        /// <param name="xLeft">х-координата левой точки треугольника</param>
        /// <param name="yLeft">у-координата левой точки треугольника</param>
        /// <param name="xRight">х-координата правой точки треугольника</param>
        /// <param name="yRight">у-координата правой точки треугольника</param>
        private void DrawSerpTriangle(double deep, double xTop, double yTop, double xLeft, double yLeft, double xRight, double yRight)
        {
            if (deep == 0)
            {
                Polygon polygon = new Polygon();
                polygon.Points.Add(new System.Windows.Point(xTop, yTop));
                polygon.Points.Add(new System.Windows.Point(xLeft, yLeft));
                polygon.Points.Add(new System.Windows.Point(xRight, yRight));
                //polygon.StrokeThickness = 1;
                polygon.Stroke = brush;
                mainCanvas.Children.Add(polygon);
            }
            else
            {
                //вычисляем среднюю точку
                //левая сторона
                var xLeftMid = (xLeft + xTop) / 2; 
                var yLeftMid = (yLeft + yTop) / 2;
                //правая сторона
                var xRightMid = (xRight + xTop) / 2; 
                var yRightMid = (yRight + yTop) / 2;
                // основание
                var xLeftRight = (xLeft + xRight) / 2;
                var yLeftRight = (yLeft + yRight) / 2;
                //рекурсивно вызываем функцию для каждого и 3 треугольников
                DrawSerpTriangle(deep - 1, xTop, yTop, xLeftMid, yLeftMid, xRightMid, yRightMid);
                DrawSerpTriangle(deep - 1, xLeftMid, yLeftMid, xLeft, yLeft, xLeftRight, yLeftRight);
                DrawSerpTriangle(deep - 1, xRightMid, yRightMid, xLeftRight, yLeftRight, xRight, yRight);
            }

        }
        /// <summary>
        /// Обрабатывает выбор фрактала "Треугольник Серпинского" в выплывающем списке.
        /// </summary>
        /// <param name="sender">выплывающий список</param>
        /// <param name="e">информация о событии</param>
        private void StartSerpTriangleHandler(object sender, RoutedEventArgs e)
        {
            Canvas.SetTop(mainCanvas, 0);
            Canvas.SetLeft(mainCanvas, 0);
            mainCanvas.Height = grid.Height;
            mainCanvas.Width = grid.Width;
            mainCanvas.Background = Brushes.AliceBlue;
            sliderDeep.Maximum = 6;
            mainCanvas.Children.Clear();
            fractal = StartSerpTriangle;
            fractal(sliderDeep.Value-1);
        }
    }
}
