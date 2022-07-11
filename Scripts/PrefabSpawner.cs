using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    // Serializing fields to expose them in the inspector in Unity for manual setup, while avoiding making them public
    [SerializeField] private List<GameObject> astroids = new List<GameObject>();
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject Laser;
    [SerializeField] private Transform PlayerSpawnPoint;

    // Limits of where to spawn astroids
    private const int upperBoundXZ = 1000;
    private const int lowerBoundXZ = -1000;
    private const int upperBoundY = 500;
    private const int lowerBoundY = -500;

    // Don't spawn stuff too close to where the player starts
    private const float noSpawnMaxX = 100;
    private const float noSpawnMaxY = 100;
    private const float noSpawnMaxZ = 100;
    private const float noSpawnMinX = -100;
    private const float noSpawnMinY = -100;
    private const float noSpawnMinZ = -100;

    public int AstroidsSpawned { get; private set; }
    private int AstroidsToSpawn = 500;
    private Vector3 randomizedVector = new Vector3();
    private System.Random random = new System.Random();

    private void Awake()
    {
        SpawnRandomizedAstroids();
        Instantiate(this.PlayerPrefab, this.PlayerSpawnPoint.position, Quaternion.identity);        
    }

    private void SpawnRandomizedAstroids()
    {
        while (this.AstroidsSpawned < this.AstroidsToSpawn)
        {
            RandomizeVector();
            var astroid = Instantiate(this.astroids[this.random.Next(0, 2)], this.randomizedVector, Random.rotation);
            astroid.transform.localScale *= this.random.Next(5, 100);

            if (astroid.transform.position.y < noSpawnMaxY && astroid.transform.position.y > noSpawnMinY &&
                astroid.transform.position.x < noSpawnMaxX && astroid.transform.position.x > noSpawnMinX &&
                astroid.transform.position.z < noSpawnMaxZ && astroid.transform.position.z > noSpawnMinZ)
            {
                Destroy(astroid);
            }
            else
            {
                ++this.AstroidsSpawned;
            }
        }
    }

    private void RandomizeVector()
    {
        randomizedVector.Set(random.Next(lowerBoundXZ, upperBoundXZ), random.Next(lowerBoundY, upperBoundY), random.Next(lowerBoundXZ, upperBoundXZ));
    }   
}
