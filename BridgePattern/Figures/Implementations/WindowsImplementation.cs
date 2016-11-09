using System.Windows;

namespace BridgePattern.Figures.Implementations
{
    class WindowsImplementation : Implementor
    {
        public override void Show(FigureBase figure)
        {
            MessageBox.Show(figure.ToString(), "caption", MessageBoxButton.OK);
        }
    }
}
