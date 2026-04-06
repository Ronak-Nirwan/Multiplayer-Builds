using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Grid System for Coverting World Coordinates to Grid Coordinates, Place and Destroy Block, Contains data for all filled position 
/// </summary>

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int cellSize = 1;

    [SerializeField] private GameObject blockPrefab;

    private Dictionary<Vector3Int, GameObject> grid = new Dictionary<Vector3Int, GameObject>();


    /// <summary>
    /// Converts the World position to grid position by rounding to nearest integer based on cell size
    /// </summary>
    /// <param name="pos">  takes vector for position</param>
    /// <returns> Vector3Int to simplify the grid </returns>
    public Vector3Int WorldToGrid(Vector3 pos)
    {
        return new Vector3Int(
            Mathf.RoundToInt(pos.x / cellSize),
            Mathf.RoundToInt((pos.y) / cellSize),
            Mathf.RoundToInt(pos.z / cellSize)
        );
    }

    /// <summary>
    /// Converts the grid position back to world position if cellsize is different
    /// </summary>
    /// <param name="pos">  takes Vector3Int for Grid position</param>
    /// <returns> Vector3 for world position </returns>

    public Vector3 GridToWorld(Vector3Int gridPos)
    {
        return new Vector3(
            gridPos.x * cellSize,
            gridPos.y * cellSize,
            gridPos.z * cellSize
        );
    }

    /// <summary>
    /// To place block at given World position, checks if the position is already filled, updates the position dictionary 
    /// </summary>

    public bool TryPlaceBlock(Vector3 WorldPos)
    {
        Vector3Int gridPos = WorldToGrid(WorldPos);

        if (grid.ContainsKey(gridPos))
            return false;

        GameObject block = Instantiate(blockPrefab,GridToWorld(gridPos),Quaternion.identity);
        grid.Add(gridPos, block);
        return true;
    }

    /// <summary>
    /// To destroy block at given World position, checks if block is there, updates the position dictionary 
    /// </summary>

    public bool TryRemoveBlock(Vector3 worldPos)
    {
        Vector3Int gridPos = WorldToGrid(worldPos);

        if (!grid.TryGetValue(gridPos, out GameObject block))
            return false;
        
        Destroy(block);
        grid.Remove(gridPos);

        return true;
    }


    /// <summary>
    /// For future reference to check if a position is filled or not
    /// </summary>
    public bool HasBlockAt(Vector3Int pos) => grid.ContainsKey(pos);


    /// <summary>
    /// To debug the dictionary positions
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        foreach (var pos in grid.Keys)
        {
            Gizmos.DrawWireCube(GridToWorld(pos),Vector3.one);
        }
    }
}
