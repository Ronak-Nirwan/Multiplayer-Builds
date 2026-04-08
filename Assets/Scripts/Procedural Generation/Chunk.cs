using UnityEngine;

/// <summary>
/// Divided the world in 10x10 block chunks, need to be optimized (giving ~60 FPS in editor) 
/// </summary>

public class Chunk : MonoBehaviour
{
    int chunkSize;
    GameObject blockPrefab;
    float scale;
    float heightMultiplier;
    Vector2 offset;

    public void Initialize(int size, GameObject prefab, float scale, float heightMultiplier, Vector2 offset)
    {
        this.chunkSize = size;
        this.blockPrefab = prefab;
        this.scale = scale;
        this.heightMultiplier = heightMultiplier;
        this.offset = offset;

        GenerateChunk();
    }

    void GenerateChunk()
    {
        for (int x = 0; x < chunkSize; x++)
        {
            for (int z = 0; z < chunkSize; z++)
            {
                float sampleX = (x + transform.position.x + offset.x) / scale;
                float sampleZ = (z + transform.position.z + offset.y) / scale;

                float noise = Mathf.PerlinNoise(sampleX, sampleZ);
                int height = Mathf.FloorToInt(noise * heightMultiplier) + 2;

                for (int y = 0; y <= height; y++)
                {
                    Vector3 pos = new Vector3(x, y, z) + transform.position;
                    GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity, transform);

                    if (y != height)
                    {
                        Destroy(block.GetComponent<Collider>());
                        //Destroy(block);
                    }
                }
            }
        }

    }
}