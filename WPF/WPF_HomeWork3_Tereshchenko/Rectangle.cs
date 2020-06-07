using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//Свойства ширина, высота, площадь, периметр
namespace WPF_HomeWork3_Tereshchenko
{
    class Rectangle:DependencyObject
    {
        public static readonly DependencyProperty HeightProperty;
        public static readonly DependencyProperty WidhtProperty;
        static Rectangle()
        {
            HeightProperty = DependencyProperty.Register("height", typeof(double), typeof(Rectangle));
            WidhtProperty = DependencyProperty.Register("widht", typeof(double), typeof(Rectangle));
        }
        public double Height
        {
            get => (double)GetValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }
        public double Widht
        {
            get => (double)GetValue(WidhtProperty);
            set => SetValue(WidhtProperty, value);
        }
        public double Squre => Height * Widht;
        public double Perimeter => (Height + Widht) * 2;
    }
}
