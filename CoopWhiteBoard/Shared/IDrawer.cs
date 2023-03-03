namespace CoopWhiteBoard.Shared
{
    public interface IDrawer
    {
        void DrawPoint(int x, int y, int size = 2, string color = "black");
        void DrawLine(int x1, int y1, int x2, int y2, bool dashed = false);
        void DrawBox(int x1, int y1, int x2, int y2);
        void DrawCircle(int x, int y, int radius);
    }
}
