using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBlock_Controller : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite Touchable;
    public Sprite Untouchable;
    public Sprite ChangeTo;
    public bool Solid = true;
    public ONOFF_Controller OnOff;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Solid == true)
        {
            if(OnOff.Change == true)
            {
                ChangeTo = Untouchable;
                ChangeSprite();
                this.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                ChangeTo = Touchable;
                ChangeSprite();
                this.GetComponent<Collider2D>().enabled = true;
            }
        }
        else if (Solid == false)
        {
            if (OnOff.Change == false)
            {
                ChangeTo = Untouchable;
                ChangeSprite();
                this.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                ChangeTo = Touchable;
                ChangeSprite();
                this.GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = ChangeTo;
    }
}
