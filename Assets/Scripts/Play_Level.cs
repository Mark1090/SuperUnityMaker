using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct Tile2
{
    public float x, y, z;
    public int id;

    public Tile2(float x, float y, float z, int id)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.id = id;
    }
}

public class Play_Level : MonoBehaviour
{
    private string level_name;
    public Maker_Tile[] makerTilePrefabs;
    public string level;
    public string name;
    public Transform parentGameObject;
    public GameObject parentGameObject2;
    public GameObject Canvas;
    public bool loading = false;
    public GameObject Player;
    public GameObject Base_Level;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Path;

    Maker_Tile[] makerTiles;

    void Start()
    {
        var path = (@"C:\Levels\");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        level = (@"C:\Levels\" + name);
        
        Title.text = name.Replace(".uml", string.Empty);
        Path.text = level;
    }

    public void Load()
    {
        this.gameObject.transform.SetParent(null);
        makerTiles = GameObject.FindObjectsOfType<Maker_Tile>();
        foreach (var i in makerTiles)
        {
            Destroy(i.gameObject);
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream2 = new FileStream(level,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
        var obj = (Tile[])formatter.Deserialize(stream2);
        stream2.Close();

        for (int i = 0; i < obj.Length; i++)
        {
            Instantiate(makerTilePrefabs[obj[i].id],
                new Vector3(obj[i].x, obj[i].y, obj[i].z), Quaternion.identity, parentGameObject);
        }
        StartCoroutine(parent());
        parentGameObject2.SetActive(false);
        Debug.Log("Level Loaded");
        Canvas.SetActive(false);
        var PlayerObject = Instantiate(Player, new Vector3(-9, -5, 0), Quaternion.identity);
        PlayerObject.GetComponent<PlayerScript>().mainScreen = true;
        Instantiate(Base_Level,
        new Vector3(0, 0, 0), Quaternion.identity, parentGameObject);
    }

    IEnumerator parent()
    {
        yield return new WaitForEndOfFrame();
        parentGameObject2.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
