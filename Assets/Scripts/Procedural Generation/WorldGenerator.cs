using UnityEngine;

/// <summary>
/// A simple Random World generation script using perlin noise
/// </summary>

public class WorldGenerator : MonoBehaviour
{
    [Header("World Settings")]
    public int WorldSizeInChunks = 10;
    public int ChunkSize = 10;

    [Header("Noise Settings")]
    public float Scale = 20f;
    public float HeightMultiplier = 6f;

    [Header("References")]
    public GameObject BlockPrefab;
    public GameObject ChunkPrefab;

    [Header("Seed")]
    public int Seed;

    private void Start()
    {
        GenerateWorld();
    }

    public void GenerateWorld()
    {
        Random.InitState(Seed);

        for (int x = 0; x < WorldSizeInChunks; x++)
        {
            for (int z = 0; z < WorldSizeInChunks; z++)
            {
                Vector2 offset = new Vector2(
                    Random.Range(-10000, 10000),
                    Random.Range(-10000, 10000)
                );

                GameObject chunkObj = Instantiate(ChunkPrefab, new Vector3(x * ChunkSize, 0, z * ChunkSize), Quaternion.identity, transform);

                Chunk chunk = chunkObj.GetComponent<Chunk>();
                chunk.Initialize(ChunkSize, BlockPrefab, Scale, HeightMultiplier, offset);
            }
        }
    }

    public void ResetWorld()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Seed = Random.Range(0, 100000);

        GenerateWorld();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetWorld();
        }
    }
}