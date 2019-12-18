using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHider : MonoBehaviour
{
    private Bounds bounds;
    private GameObject[] hidableObjects;

    private void Awake()
    {
        //get the hideable objects
        hidableObjects = GameObject.FindGameObjectsWithTag("ChunkObject");

        //get bounds of terrain
        Terrain terrain = GetComponent<Terrain>();

        Vector3 dimensions = new Vector3(terrain.terrainData.heightmapWidth, 1000, terrain.terrainData.heightmapHeight);
        Vector3 pos = transform.position + new Vector3(dimensions.x / 2, 0, dimensions.z / 2);

        bounds = new Bounds(pos, dimensions);
    }

    private void OnEnable()
    {
        foreach(GameObject obj in hidableObjects)
        {
            if(obj != null && bounds.Contains(obj.transform.position))
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        foreach (GameObject obj in hidableObjects)
        {
            if (obj != null && bounds.Contains(obj.transform.position))
            {
                obj.SetActive(false);
            }
        }
    }
}
