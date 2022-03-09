using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Класс обеспечивает работу wpf-приложения.
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Canvas mainCanvas = new Canvas();
        public const double angle = Math.PI / 2; //Угол поворота на 90 градусов
        public const double ang1 = Math.PI / 4;  //Угол поворота на 45 градусов
        public const double ang2 = Math.PI / 6;  //Угол поворота на 30 градусов
        private readonly Random rand = new Random();
        Brush brush = Brushes.Black;
        delegate void StartFractal(double deep);
        StartFractal? fractal; 

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        public MainWindow()
        {            
            InitializeComponent();
            sliderDeep.ValueChanged += sliderDeep_ValueChanged;
            changeColorButton.Click += ComboBoxItem_Selected;
            mainCanvas.Children.Clear();
            mainCanvas.Background = Brushes.AliceBlue;
            grid.Children.Add(mainCanvas);
        }

        /// <summary>
        /// Метод обрабатывает нажатие на кнопку смены цвета.
        /// </summary>
        /// <param name="sender">кнопка</param>
        /// <param name="e">информация о событии</param>
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            mainCanvas.Children.Clear();
            byte startRed = (byte)rand.Next(256);
            byte startGreen = (byte)rand.Next(256);
            byte startBlue = (byte)rand.Next(256);
            brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(startRed, startGreen, startBlue));
            if(fractal == null)
            {
                MessageBox.Show("Не выбран фрактал");
            }
            else
            {
                fractal(sliderDeep.Value);
            }

        }

        /// <summary>
        /// Метод обрабатывает изменение глубины рекурсии при помощи ползунка.
        /// </summary>
        /// <param name="sender">ползунок</param>
        /// <param name="e">информация о событии</param>
        private void sliderDeep_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mainCanvas.Children.Clear();
            if (fractal == null)
            {
                MessageBox.Show("Не выбран фрактал");
            }
            else
            {
                fractal(sliderDeep.Value);
            }
        }
      
    }

}

