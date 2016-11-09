namespace BridgePattern.Figures
{
    class Triangle : FigureBase
    {
        public override void Show()
        {
            Implementor.Show(this);
        }


        public override string ToString()
        {
            return "Triangle";
        }
    }
}
