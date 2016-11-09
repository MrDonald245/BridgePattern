namespace BridgePattern.Figures
{
    class Rectangle : FigureBase
    {
        public override void Show()
        {
            Implementor.Show(this);
        }

        public override string ToString()
        {
            return "Rectangle";
        }
    }
}
