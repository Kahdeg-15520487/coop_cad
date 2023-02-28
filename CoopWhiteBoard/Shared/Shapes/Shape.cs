namespace CoopWhiteBoard.Shared.Shapes
{
    public interface IShape
    {
        IEnumerable<Node> Nodes { get; }
        bool AddNode(int x, int y);
        bool AddNode(Node node);
        bool Hit(int x, int y);

        void DrawNodes(IDrawer drawer);
        void DrawSelf(IDrawer drawer);
    }
    public abstract class Shape : IShape
    {
        protected List<Node> nodes = new List<Node>();
        public IEnumerable<Node> Nodes => nodes;
        public int NodeCount { get; private set; }

        public bool AddNode(int x, int y)
        {
            if (nodes.Count() < NodeCount)
            {
                nodes.Add(new Node(x, y));
                return true;
            }
            return false;
        }

        public bool AddNode(Node node)
        {
            if (nodes.Count() < NodeCount)
            {
                nodes.Add(node);
                return true;
            }
            return false;
        }

        public void DrawNodes(IDrawer drawer)
        {
            nodes.ForEach(n => drawer.DrawPoint(n.X, n.Y));
        }

        public abstract void DrawSelf(IDrawer drawer);

        public bool Hit(int x, int y)
        {
            var detect = new Node(x, y);
            return nodes.Any(n => n.Equals(detect));
        }
    }
    public record Node(int X, int Y)
    {
        public virtual bool Equals(Node? other)
        {
            return other != null
                   && X == other.X
                   && Y == other.Y;
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }
    }
}
