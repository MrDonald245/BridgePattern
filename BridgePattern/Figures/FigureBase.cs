using BridgePattern.Figures.Implementations;

namespace BridgePattern.Figures
{
    abstract class FigureBase
    {
        public Implementor Implementor { get; set; }

        public virtual void Show()
        {
            Implementor.Show(this);
        }
    }
}
