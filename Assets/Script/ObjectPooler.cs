using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {
        public string type;

        public GameObject prefabe;

        public int size;
    }


    public static ObjectPooler instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    GameObject ObjectToSpawn;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectspools = new Queue<GameObject>();

            for (int i = 0; i< pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefabe);
                obj.SetActive(false);
                objectspools.Enqueue(obj);
            }

            poolDictionary.Add(pool.type, objectspools);
        }
    }

    public GameObject Spawnfrompool(string type, Vector3 position, Quaternion rotation)
    {
       if (!poolDictionary.ContainsKey(type))
        {
            Debug.Log("data not found");
            return  null;
        }
        ObjectToSpawn = poolDictionary[type].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = position;
        ObjectToSpawn.transform.rotation = rotation;

        poolDictionary[type].Enqueue(ObjectToSpawn);
        return ObjectToSpawn;
    }
}
