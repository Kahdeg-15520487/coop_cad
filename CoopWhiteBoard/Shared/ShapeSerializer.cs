using CoopWhiteBoard.Shared.Shapes;

using System.Text;

namespace CoopWhiteBoard.Shared
{
    public static class ShapeSerializer
    {
        public static string Serialize(IEnumerable<IShape> shapes)
        {
            return Serialize(shapes.Select(s => (Shape)s));
        }

        public static string Serialize(IEnumerable<Shape> shapes)
        {
            return string.Join('|', shapes.Select(s => Serialize(s)));
        }

        public static string Serialize(Shape shape)
        {
            return shape.Serialize();
        }

        public static IEnumerable<Shape> Deserialize(string serialized)
        {
            return serialized.Split('|').Select(s => Shape.Deserialize(s));
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}