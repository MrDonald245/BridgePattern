
namespace BridgePattern.Figures
{
    class Circle : FigureBase
    {
        public override void Show()
        {
            Implementor.Show(this);
        }


        public override string ToString()
        {
            return "Circle";
        }
    }
}
