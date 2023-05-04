using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveLoadGame : MonoBehaviour
{
    public Gamesave gamesave;

    public static SaveLoadGame inst;

    private void Awake()
    {
        inst = this;
        LoadData();
        
    }

    public void Saveplayerdata(Vector3 playerpos)
    {
        gamesave.position = playerpos;
    }

    public void loadplayerdat()
    {
        PlayerControler.inst.transform.position = gamesave.position;   
    }
   


    public void SaveData()
    {
        File.WriteAllText(Application.dataPath + "/Playerdata.json", JsonUtility.ToJson(gamesave));
    }

    public void LoadData()
    {
       gamesave = JsonUtility.FromJson<Gamesave>(File.ReadAllText(Application.dataPath + "/Playerdata.Json"));
    }
}

[System.Serializable]
public class Gamesave
{
    public Vector3 position;

}