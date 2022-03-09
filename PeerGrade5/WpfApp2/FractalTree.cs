using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    { 
        /// <summary>
        /// Вызывает метод отрисовки фрактала "Фрактальное дерево"
        /// </summary>
        /// <param name="deep">глубина рекурсии</param>
        private void StartFractalTree(double deep)
        {
            DrawFractalTree(250, 250, deep, 100, angle);
        }

        /// <summary>
        /// Метод рекурсивно строит фрактал "Фрактальное дерево"
        /// </summary>
        /// <param name="x">левая граница</param>
        /// <param name="y">верхнаяя граница</param>
        /// <param name="deep">глубина рекурсии</param>
        /// <param name="size">длина</param>
        /// <param name="angle">угол</param>
        private void DrawFractalTree(double x, double y, double deep, double size, double angle)
        {

            if (deep > 0)
            { 
                //Меняем параметр size
                size *= 0.7;

                //Считаем координаты для вершины-ребенка
                double xnew = Math.Round(x + size * Math.Cos(angle)),
                       ynew = Math.Round(y - size * Math.Sin(angle));

                //рисуем линию между вершинами
                Line line = new Line();
                line.X1 = x;
                line.Y1 = y;
                line.X2 = xnew;
                line.Y2 = ynew;
                line.Stroke = brush;
                mainCanvas.Children.Add(line);

                //Переприсваеваем координаты
                x = xnew;
                y = ynew;

                //Вызываем рекурсивную функцию для левого и правого ребенка
                DrawFractalTree(x, y, deep - 1, size, angle + ang1);
                DrawFractalTree(x, y, deep - 1, size, angle - ang2);
            }
        }

        /// <summary>
        /// Обработчик выбора фрактала "Фрактальное дерево" в выплывающем списке.
        /// </summary>
        /// <param name="sender">выплывающий список</param>
        /// <param name="e">информация о событии</param>
        private void StartFractalTreeHandler(object sender, RoutedEventArgs e)
        {
            Canvas.SetTop(mainCanvas, 0);
            Canvas.SetLeft(mainCanvas, 0);
            mainCanvas.Height = grid.Height;
            mainCanvas.Width = grid.Width;
            mainCanvas.Background = Brushes.AliceBlue;
            sliderDeep.Maximum = 10;
            mainCanvas.Children.Clear();
            fractal = StartFractalTree;
            fractal(sliderDeep.Value);
        }
    }
}
