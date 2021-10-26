﻿using System.Collections;
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
    public MakerTile[] makerTilePrefabs;
    private string level;
    
    MakerTile[] makerTiles;

    public void ReadStringInput(string s)
    {
        level_name = s;
        Debug.Log(level_name);

    }

    public void Save()
    {
        level = (@"C:\Levels\" + level_name + @".bin");
        var path = (@"C:\Levels\");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        makerTiles = GameObject.FindObjectsOfType<MakerTile>();
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
        makerTiles = GameObject.FindObjectsOfType<MakerTile>();
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
                new Vector3(obj[i].x, obj[i].y, obj[i].z),
                Quaternion.identity);
        }
        Debug.Log("Level Loaded");
    }

    void Clear()
    {
        makerTiles = GameObject.FindObjectsOfType<MakerTile>();
        foreach (var i in makerTiles)
        {
            Destroy(i.gameObject);
        }
    }

}
