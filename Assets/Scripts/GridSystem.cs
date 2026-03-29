using Unity.VisualScripting;
using UnityEngine;
public class GridSystem : MonoBehaviour
{

    Vector3Int worldPos;
    Vector3Int gridPos;
    int cellSize = 1;

    public GameObject BlockPrefab;
    //public Vector3 LocationOnGrid = Vector3.zero;

    void Update()
    {

    }

    public void PlaceBlockAt(Vector3 pos)
    {
        gridPos = new Vector3Int(
                    Mathf.RoundToInt(pos.x / cellSize), 
                    Mathf.RoundToInt((pos.y)/ cellSize), 
                    Mathf.RoundToInt(pos.z / cellSize)
            );

        Debug.Log("WorldPos : " + pos);
        Debug.Log("GridPos : " + gridPos);

        Instantiate(BlockPrefab,gridPos,Quaternion.identity);
    }
}
