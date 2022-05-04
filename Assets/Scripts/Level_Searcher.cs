using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Level_Searcher : MonoBehaviour
{
    public string path = @"C:\Levels\";
    public string[] Levels;
    public Sprite Sprite1;
    public Transform Layout;
    public GameObject Button_Prefab;
    public int Level_Num;
    public SpriteRenderer preview;

    void Start()
    {
        Locate();
    }

    void Locate()
    {
        string[] filePaths = Directory.GetFiles(path, "*.uml", SearchOption.AllDirectories);
        Array.Resize(ref Levels, filePaths.Length);
        for (int i = 0; i < filePaths.Length; ++i)
        {
            string path = filePaths[i];
            //Debug.Log(System.IO.Path.GetFileName(path));
            Levels[i] = System.IO.Path.GetFileName(path);

            int u = i;
            var t = Instantiate(Button_Prefab, Layout);

            t.GetComponent<Image>().sprite = Sprite1;
            t.gameObject.name = Levels[i];
            t.GetComponent<Play_Level>().name = Levels[i];
            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                Level_Num = u;

            });
        }
    }
}