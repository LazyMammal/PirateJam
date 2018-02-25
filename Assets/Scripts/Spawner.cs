using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Collider[] spawnRegions;
    public Transform objParent = null;
    public bool randomHeight = true, respawn = false;

    public int maxPopulation = 10;
    void Start()
    {
        SpawnSome(maxPopulation);
        if (objParent == null)
            objParent = transform;
    }
    void Update()
    {
        if (respawn)
        {
            int popDiff = maxPopulation - objParent.childCount;
            if (popDiff > 0)
                SpawnSome(popDiff);
        }
    }
    void SpawnSome(int popSize)
    {
        for (int i = 0; i < popSize; i++)
        {
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
            Collider spawnRegion = spawnRegions[Random.Range(0, spawnRegions.Length)].GetComponent<Collider>();

            Vector3 pos = new Vector3(
                Random.Range(spawnRegion.bounds.min.x, spawnRegion.bounds.max.x),
                0f,
                Random.Range(spawnRegion.bounds.min.z, spawnRegion.bounds.max.z)
            );
            pos.y = Terrain.activeTerrain.transform.TransformPoint(0f, Terrain.activeTerrain.SampleHeight(pos), 0f).y;

            if (pos.y < spawnRegion.bounds.max.y)
            {
                if (randomHeight)
                    pos.y = Random.Range(pos.y, spawnRegion.bounds.max.y);
                GameObject go = Instantiate(prefab, pos, Quaternion.identity);
                go.transform.parent = objParent;
            }
        }

    }
}
