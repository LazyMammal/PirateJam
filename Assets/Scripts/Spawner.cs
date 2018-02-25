using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Collider[] spawnRegions;
    public Transform objParent = null;
    bool randomHeight = true;

    public int maxPopulation = 10;
    void Start()
    {
        for (int i = 0; i < maxPopulation; i++)
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
                go.transform.parent = objParent ? objParent : transform;
            }
        }
    }
}
