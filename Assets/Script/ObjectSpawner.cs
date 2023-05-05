using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private bool spawingobject = false;

    public static ObjectSpawner inst;

    public float groundspawndistance = 50f;

    private void Awake()
    {
        inst = this;
    }

    public void spawnGround()
    {
        ObjectPooler.instance.Spawnfrompool("Ground", new Vector3(0, 0, 60f),groundspawndistance )  ;
    }

}
