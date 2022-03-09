using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow: Window
    {
        /// <summary>
        /// Вызывает метод отрисовки фрактала "Кривая Коха"
        /// </summary>
        /// <param name="deep">глубина рекурсии</param>
        private void StartKochLine(double deep)
        {
            DrawKochLine(deep, 50, 200, 450, 200);
        }
        /// <summary>
        /// Метод рекурсивно строит фрактал "Кривая Коха"
        /// </summary>
        /// <param name="deep">глубина рекурсии</param>
        /// <param name="x1">х-координата начала отрезка</param>
        /// <param name="y1">у-координата начала отрезка</param>
        /// <param name="x2">х-координата конца отрезка</param>
        /// <param name="y2">у-координата конца отрезка</param>
        private void DrawKochLine(double deep, int x1, int y1, int x2, int y2)
        {
            if (deep == 1)
            {
                Line line = new Line();
                line.X1 = x1;
                line.Y1 = y1;
                line.X2 = x2;
                line.Y2 = y2;
                line.Stroke = brush;
                mainCanvas.Children.Add(line);
                return;
            }

            else
            {

                double alpha = Math.Atan2(y2 - y1, x2 - x1);
                double r = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                double xa = x1 + r * Math.Cos(alpha) / 3;
                double ya = y1 + r * Math.Sin(alpha) / 3;

                double xc = xa + r * Math.Cos(alpha - Math.PI / 3) / 3;
                double yc = ya + r * Math.Sin(alpha - Math.PI / 3) / 3;

                double xb = x1 + 2 * r * Math.Cos(alpha) / 3;
                double yb = y1 + 2 * r * Math.Sin(alpha) / 3;

                DrawKochLine(deep - 1, x1, y1, (int)xa, (int)ya);
                DrawKochLine(deep - 1, (int)xa, (int)ya, (int)xc, (int)yc);
                DrawKochLine(deep - 1, (int)xc, (int)yc, (int)xb, (int)yb);
                DrawKochLine(deep - 1, (int)xb, (int)yb, x2, y2);

            }
        }
        /// <summary>
        /// Метод отбрабатывает выбор фрактала "Кривая Коха" в выплывающем списке
        /// </summary>
        /// <param name="sender">выплывающий список</param>
        /// <param name="e">информация о событии</param>
        private void StartKochLineHandler(object sender, RoutedEventArgs e)
        {
            Canvas.SetTop(mainCanvas, 0);
            Canvas.SetLeft(mainCanvas, 0);
            mainCanvas.Height = grid.Height;
            mainCanvas.Width = grid.Width;
            mainCanvas.Background = Brushes.AliceBlue;
            sliderDeep.Maximum = 6;
            mainCanvas.Children.Clear();
            fractal = StartKochLine;
            fractal(sliderDeep.Value);
        }
    }
}
