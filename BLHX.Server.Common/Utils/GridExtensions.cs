using BLHX.Server.Common.Data;

namespace BLHX.Server.Common.Utils;

public static class GridExtensions
{
    public static GridItem? Find(this List<GridItem> nodes, uint x, uint y)
        => nodes.FirstOrDefault(n => n.Row == x && n.Column == y);

    public static GridItem? Find(this List<GridItem> nodes, int x, int y)
        => Find(nodes, (uint)x, (uint)y);

    public static (uint, uint, uint, uint) GetDimensions(this List<GridItem> grid)
    {
        uint startX = uint.MaxValue;
        uint startY = uint.MaxValue;
        uint width = 0;
        uint height = 0;

        foreach (var node in grid)
        {
            if (node.Column < startX)
                startX = node.Column;
            if (node.Row < startY)
                startY = node.Row;
            if (node.Column > width)
                width = node.Column;
            if (node.Row > height)
                height = node.Row;
        }

        return (startX, startY, width, height);
    }
}