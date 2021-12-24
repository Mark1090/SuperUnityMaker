using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maker : MonoBehaviour
{
    public Maker_Tile[] tiles;
    public GameObject buttonPrefab;
    public GameObject Refresher;
    public Transform layout;
    public SpriteRenderer preview;
    public GameObject[] playingObjects;
    private Maker_Tile TileId;

    public int[] Counter;
    public int[] Max;

    public Transform parentGameObject;

    public int id;

    public static bool playing;

	void Start ()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            int u = i;
            var t = Instantiate(buttonPrefab, layout);
            t.GetComponent<Image>().sprite = tiles[u].sprite;
            t.GetComponent<Button>().onClick.AddListener(()=> 
            {
                id = u;
                preview.sprite = tiles[u].sprite;
            });
        }	
	}

    public void TogglePlaying()
    {
        playing = !playing;
        preview.enabled = !playing;
        for (int i = 0; i < playingObjects.Length; i++)
        {
            playingObjects[i].SetActive(!playing);
        }
    }

    void Update()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;
        if (playing)
            return;

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        pos.z = 0;
        pos.x = Mathf.RoundToInt(pos.x);
        pos.y = Mathf.RoundToInt(pos.y);

        preview.transform.position = pos;
        if (!playing)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                var c = Physics2D.CircleCast(pos, 0.4f, Vector2.zero);
                if (c.collider == null)
                {
                    if (Counter[id] < Max[id])
                    {
                        Instantiate(tiles[id].gameObject, pos, Quaternion.identity, parentGameObject);
                        Counter[id]++;
                    }
                }
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                var c = Physics2D.CircleCast(pos, 0.4f, Vector2.zero);
                if (c.collider != null)
                {
                    if (c.collider.gameObject.GetComponent<Maker_Tile>().id == 4)
                    {
                    c.collider.gameObject.GetComponent<Block_Changer>().mode = "none";
                    }

                    if (!(c.collider.gameObject.layer == 6))
                    {
                        TileId = c.collider.gameObject.GetComponent<Maker_Tile>();
                        Counter[TileId.id] = Counter[TileId.id] - 1;
                        Destroy(c.collider.gameObject);
                    }  
                }
            }
        }
    }
}
