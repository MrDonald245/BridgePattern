using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BridgePattern.Figures;
using BridgePattern.Figures.Implementations;

namespace BridgePattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RadioButton _currentlyCheckedShape;
        private RadioButton _currentlyCheckedImplementation;

        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Occures when any of shape radio buttons are clicked.
        /// Saves current state in a private variable "string _currentlyCheckedShape".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
                _currentlyCheckedShape = (RadioButton)sender;
        }

        /// <summary>
        /// Occures when any of implementation radio buttons are clicked.
        /// Saves current state in a private variable "string _currentlyCheckedImplementation".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonWindowsImpl_OnChecked(object sender, RoutedEventArgs e)
        {
                _currentlyCheckedImplementation = (RadioButton)sender;
        }

        /// <summary>
        /// Occures when mouse button is pushed.
        /// On the basis of implement mode we draw figure.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            FigureBase figure = null;

            switch (_currentlyCheckedShape.Content.ToString())
            {
                case "Circle":
                    figure = new Circle();
                    break;
                case "Rectangle":
                    figure = new Rectangle();
                    break;
                case "Triangle":
                    figure = new Triangle();
                    break;
            }

            // No figueres may be selected or chose right.
            // Cach that exception:
            try
            {
                switch (_currentlyCheckedImplementation.Content.ToString())
                {
                    case "Windows implementetion":
                        figure.Implementor = new WindowsImplementation();
                        break;
                    case "WPF implementetion":
                        figure.Implementor = new WpfImplementation(this, e);
                        break;
                }

                figure.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There are either no such figures or implementetions were found." +
                                " Make sure your check boxes are handled in UIElement_OnMouseDown()", "Exception",
                    MessageBoxButton.OK);
            }
        }
    }
}
