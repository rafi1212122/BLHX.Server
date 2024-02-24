using BLHX.Server.Common.Data;

namespace BLHX.Server.Common.Utils;

public class PathNode
{
    public int X { get; set; }
    public int Y { get; set; }
    public PathNode Previous { get; set; }
    public int GCost { get; set; } // Represents the cost from the start node to the current node
    public int HCost { get; set; } // Represents the heuristic cost estimate, which is the estimated cost from the current node to the goal node
    public int FCost => GCost + HCost;
    public bool Blocking { get; set; }

    public override string ToString()
        => $"Node: {{ X: {X}, Y: {Y}, GCost: {GCost}, HCost: {HCost}, FCost: {FCost}, Blocking: {Blocking} }}";
}

public static class Pathfinding
{
    public static List<PathNode>? AStar(List<GridItem> grid, uint startX, uint startY, uint goalX, uint goalY)
    {
        (uint _, uint _, uint width, uint height) = grid.GetDimensions();

        var nodes = new PathNode[width, height];
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                nodes[x, y] = new PathNode
                {
                    X = x,
                    Y = y,
                    Blocking = grid.Find(x, y)?.Blocking ?? false
                };
            }
        
        return AStar(nodes, nodes[startX, startY], nodes[goalX, goalY]);
    }

    public static List<PathNode>? AStar(PathNode[,] grid, PathNode start, PathNode goal)
    {
        var openSet = new List<PathNode> { start };
        var closedSet = new HashSet<PathNode>();
        
        start.GCost = 0;
        start.HCost = HeuristicCostEstimate(start, goal);

        while (openSet.Count > 0)
        {
            var current = openSet.OrderBy(node => node.FCost).First();

            if (current == goal)
                return ReconstructPath(current);

            openSet.Remove(current);
            closedSet.Add(current);

            foreach (var neighbor in GetNeighbors(grid, current))
            {
                if (closedSet.Contains(neighbor) || neighbor.Blocking)
                    continue;

                var tentativeGCost = current.GCost + 1;

                if (tentativeGCost < neighbor.GCost || !openSet.Contains(neighbor))
                {
                    neighbor.Previous = current;
                    neighbor.GCost = tentativeGCost;
                    neighbor.HCost = HeuristicCostEstimate(neighbor, goal);

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return null;
    }

    static List<PathNode> ReconstructPath(PathNode current)
    {
        var path = new List<PathNode>();
        while (current != null)
        {
            path.Insert(0, current);
            current = current.Previous;
        }

        return path;
    }

    static PathNode[] GetNeighbors(PathNode[,] grid, PathNode node)
    {
        int x = node.X;
        int y = node.Y;
        int maxX = grid.GetLength(0) - 1;
        int maxY = grid.GetLength(1) - 1;
        var neighbors = new List<PathNode>();

        if (x > 0) neighbors.Add(grid[x - 1, y]);
        if (x < maxX) neighbors.Add(grid[x + 1, y]);
        if (y > 0) neighbors.Add(grid[x, y - 1]);
        if (y < maxY) neighbors.Add(grid[x, y + 1]);

        return neighbors.ToArray();
    }

    static int HeuristicCostEstimate(PathNode start, PathNode goal)
        => Math.Abs(start.X - goal.X) + Math.Abs(start.Y - goal.Y);
}
