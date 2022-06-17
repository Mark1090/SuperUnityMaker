using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



[System.Serializable]
public struct Tile
{
    public float x, y, z;
    public int id;

    public Tile(float x, float y, float z, int id)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.id = id;
    }
}



public class LevelManager : MonoBehaviour {

    private string level_name;
    public Maker_Tile[] makerTilePrefabs;
    private string level;
    private string levelTEMP;
    public Transform parentGameObject;
    public GameObject parentGameObject2;
    public Maker MakerScript;
    public bool loading = false;

    Maker_Tile[] makerTiles;

    public void ReadStringInput(string s)
    {
        level_name = s;
        Debug.Log(level_name);

    }
    void Start()
    {
        var path = (@"C:\Levels\");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        var pathTemp = (@"C:\Levels\Temp\");
        if (!Directory.Exists(pathTemp))
        {
            Directory.CreateDirectory(pathTemp);
        }
    }

    void Update()
    {
        level = (@"C:\Levels\" + level_name + @".uml");
        levelTEMP = (@"C:\Levels\Temp\Current.uml");
    }

    public void Save()
    {
        makerTiles = GameObject.FindObjectsOfType<Maker_Tile>();
        Tile[] t = new Tile[makerTiles.Length];
        for (int i = 0; i < t.Length; i++)
        {
            t[i] = new Tile(makerTiles[i].transform.position.x,
                            makerTiles[i].transform.position.y,
                            makerTiles[i].transform.position.z,
                            makerTiles[i].id);
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(level,
                                     FileMode.Create,
                                     FileAccess.Write,
                                     FileShare.None);
        formatter.Serialize(stream, t);
        stream.Close();
        Debug.Log("Level Saved");
    }
    public void Load()
    {
        loading = true;
        makerTiles = GameObject.FindObjectsOfType<Maker_Tile>();
        foreach (var i in makerTiles)
        {
            Destroy(i.gameObject);
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(level,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
        var obj = (Tile[])formatter.Deserialize(stream);
        stream.Close();
        
        for (int i = 0; i < obj.Length; i++)
        {
            Instantiate(makerTilePrefabs[obj[i].id],
                new Vector3(obj[i].x, obj[i].y, obj[i].z), Quaternion.identity, parentGameObject);
            MakerScript.Counter[MakerScript.id] = obj[i].id;
        }
        StartCoroutine(parent());
        parentGameObject2.SetActive(false);
        Debug.Log("Level Loaded");
    }

    public void Level()
    {
        if (Maker.playing)
        {
            SaveTemp();
        }
        else
        {
            LoadTemp();
        }
    }

    public void SaveTemp()
    {
        makerTiles = GameObject.FindObjectsOfType<Maker_Tile>();
        Tile[] t = new Tile[makerTiles.Length];
        for (int i = 0; i < t.Length; i++)
        {
            t[i] = new Tile(makerTiles[i].transform.position.x,
                            makerTiles[i].transform.position.y,
                            makerTiles[i].transform.position.z,
                            makerTiles[i].id);
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(levelTEMP,
                                     FileMode.Create,
                                     FileAccess.Write,
                                     FileShare.None);
        formatter.Serialize(stream, t);
        stream.Close();
        Debug.Log("TEMPLevel Saved");
    }

    public void LoadTemp()
    {
        loading = true;
        makerTiles = GameObject.FindObjectsOfType<Maker_Tile>();
        foreach (var i in makerTiles)
        {
            Destroy(i.gameObject);
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(levelTEMP,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
        var obj = (Tile[])formatter.Deserialize(stream);
        stream.Close();

        for (int i = 0; i < obj.Length; i++)
        {
            Instantiate(makerTilePrefabs[obj[i].id],
                new Vector3(obj[i].x, obj[i].y, obj[i].z), Quaternion.identity, parentGameObject);
            MakerScript.Counter[MakerScript.id] = obj[i].id;
        }
        StartCoroutine(parent());
        parentGameObject2.SetActive(false);
        Debug.Log("TEMPLevel Loaded");
    }
    IEnumerator parent()
    {
        yield return new WaitForEndOfFrame();
        parentGameObject2.SetActive(true);
    }

    void Clear()
    {
        makerTiles = GameObject.FindObjectsOfType<Maker_Tile>();
        foreach (var i in makerTiles)
        {
            Destroy(i.gameObject);
        }
    }

}
