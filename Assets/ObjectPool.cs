using UnityEngine;
using System.Collections.Generic;

public class CannonballPool : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public int poolSize = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(cannonballPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetCannonball()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return Instantiate(cannonballPrefab);
    }

    public void ReturnCannonball(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}