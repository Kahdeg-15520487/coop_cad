namespace CoopWhiteBoard.Shared
{
    public interface IDrawer
    {
        void DrawPoint(int x, int y);
        void DrawLine(int x1, int y1, int x2, int y2);
        void DrawBox(int x1, int y1, int x2, int y2);
        void DrawCircle(int x, int y, int radius);
    }
}
