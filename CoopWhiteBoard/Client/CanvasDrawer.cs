using CoopWhiteBoard.Shared;

using Excubo.Blazor.Canvas.Contexts;

namespace CoopWhiteBoard.Client
{
    public class CanvasDrawer : IDrawer
    {
        private readonly Batch2D batch;

        public CanvasDrawer(Batch2D batch)
        {
            this.batch = batch;
        }

        public async void DrawBox(int x1, int y1, int x2, int y2)
        {
            await batch.BeginPathAsync();
            await batch.RectAsync(x1, y1, x2, y2);
            await batch.StrokeAsync();
        }

        public async void DrawCircle(int x, int y, int radius)
        {
            await batch.BeginPathAsync();
            await batch.ArcAsync(x, y, radius, 0, 2 * Math.PI, false);
            await batch.StrokeAsync();
        }

        public async void DrawLine(int x1, int y1, int x2, int y2, bool dashed = false)
        {
            await batch.BeginPathAsync();
            if (dashed)
            {
                await batch.SetLineDashAsync(new double[] { 5, 3 });
            }
            await batch.MoveToAsync(x1, y1);
            await batch.LineToAsync(x2, y2);
            await batch.StrokeAsync();
            await batch.SetLineDashAsync(new double[] { });
        }

        public async void DrawPoint(int x, int y, int size = 2, string color = "black")
        {
            await batch.FillStyleAsync(color);
            await batch.FillRectAsync(x, y, size, size);
            await batch.FillStyleAsync("black");
        }
    }
}
