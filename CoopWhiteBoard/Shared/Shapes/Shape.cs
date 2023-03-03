namespace CoopWhiteBoard.Shared.Shapes
{
    public interface IShape
    {
        IEnumerable<Node> Nodes { get; }
        Node AddNode(int x, int y);
        Node AddNode(Node node);
        Node Hit(int x, int y);

        void DrawNodes(IDrawer drawer);
        void DrawSelf(IDrawer drawer);
    }
    public abstract class Shape : IShape
    {
        protected List<Node> nodes = new List<Node>();
        public IEnumerable<Node> Nodes => nodes;
        public int NodeCount { get; private set; }

        public Shape(int nodeCount)
        {
            NodeCount = nodeCount;
        }

        public Node AddNode(int x, int y)
        {
            if (nodes.Count() < NodeCount)
            {
                nodes.Add(new Node(x, y));
                return nodes.Last();
            }
            return null;
        }

        public Node AddNode(Node node)
        {
            if (nodes.Count() < NodeCount)
            {
                nodes.Add(node);
                return node;
            }
            return null;
        }

        public void DrawNodes(IDrawer drawer)
        {
            nodes.ForEach(n =>
            {
                drawer.DrawPoint(n.X - 2, n.Y - 2, 4, "red");
                drawer.DrawPoint(n.X - 1, n.Y - 1, 2);
            });
        }

        public abstract void DrawSelf(IDrawer drawer);

        public Node Hit(int x, int y)
        {
            var detect = new Node(x, y);
            return nodes.FirstOrDefault(n => n.Equals(detect));
        }
    }
    public class Node
    {
        public Node(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int X { get; set; }
        public int Y { get; set; }

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
        public override string ToString()
        {
            return $"{X}|{Y}";
        }

        public int DistanceTo(Node node)
        {
            return (int)Math.Round(Math.Sqrt(Math.Pow(X - node.X, 2) + Math.Pow(Y - node.Y, 2)));
        }
    }
}
