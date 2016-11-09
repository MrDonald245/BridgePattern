using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BridgePattern.Figures.Implementations
{
    class WpfImplementation : Implementor
    {
        private MainWindow _context;
        private MouseButtonEventArgs _mouseButtonEventArgs;

        public WpfImplementation(MainWindow context, MouseButtonEventArgs mouseButtonEventArgs)
        {
            _context = context;
            _mouseButtonEventArgs = mouseButtonEventArgs;
        }

        public override void Show(FigureBase figure)
        {
            Shape shape = null;

            switch (figure.ToString())
            {
                case "Circle":
                    shape = CreateCircle();
                    break;
                case "Rectangle":
                    shape = CreateRectangle();
                    break;
                case "Triangle":
                    throw new Exception("No implementation of triangle drawing. Please make it.");
            }

            Canvas.SetLeft(shape, _mouseButtonEventArgs.GetPosition(_context.Canvas).X);
            Canvas.SetTop(shape, _mouseButtonEventArgs.GetPosition(_context.Canvas).Y);

            _context.Canvas.Children.Add(shape);
        }

        private Shape CreateCircle()
        {
            Shape circle = new Ellipse() { Height = 40, Width = 40 };

            RadialGradientBrush brush = new RadialGradientBrush();
            brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF7689"), 0.250));
            brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF7689"), 0.100));
            brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF7689"), 8));
            circle.Fill = brush;

            return circle;
        }

        private Shape CreateRectangle()
        {
            Shape rectangle = new System.Windows.Shapes.Rectangle()
            {
                Fill = Brushes.Blue,
                Height = 45,
                Width = 45,
                RadiusX = 12,
                RadiusY = 12
            };

            return rectangle;
        }
    }
}
