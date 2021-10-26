using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Changer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite Block1_1_1_1;
    public Sprite Block1_1_1_0;
    public Sprite Block1_1_0_1;
    public Sprite Block1_0_1_1;
    public Sprite Block0_1_1_1;
    public Sprite Block0_1_1_0;
    public Sprite Block1_1_0_0;
    public Sprite Block1_0_0_1;
    public Sprite Block0_0_1_1;
    public Sprite Block1_0_0_0;
    public Sprite Block0_1_0_0;
    public Sprite Block0_0_1_0;
    public Sprite Block0_0_0_1;
    public Sprite Block1_0_1_0;
    public Sprite Block0_1_0_1;
    public Sprite Block0_0_0_0;

    public Block_Check Up_Block_Check;
    public Block_Check Down_Block_Check;
    public Block_Check Left_Block_Check;
    public Block_Check Right_Block_Check;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Up_Block_Check.Touching_Up) && (Right_Block_Check.Touching_Right) && (Down_Block_Check.Touching_Down) && (Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock1_1_1_1();
        }

        if ((Up_Block_Check.Touching_Up) && (Right_Block_Check.Touching_Right) && (Down_Block_Check.Touching_Down) && !(Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock1_1_1_0();
        }

        if ((Up_Block_Check.Touching_Up) && (Right_Block_Check.Touching_Right) && !(Down_Block_Check.Touching_Down) && (Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock1_1_0_1();
        }

        if ((Up_Block_Check.Touching_Up) && !(Right_Block_Check.Touching_Right) && (Down_Block_Check.Touching_Down) && (Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock1_0_1_1();
        }

        if (!(Up_Block_Check.Touching_Up) && (Right_Block_Check.Touching_Right) && (Down_Block_Check.Touching_Down) && (Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock0_1_1_1();
        }

        if (!(Up_Block_Check.Touching_Up) && (Right_Block_Check.Touching_Right) && (Down_Block_Check.Touching_Down) && !(Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock0_1_1_0();
        }

        if ((Up_Block_Check.Touching_Up) && (Right_Block_Check.Touching_Right) && !(Down_Block_Check.Touching_Down) && !(Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock1_1_0_0();
        }

        if ((Up_Block_Check.Touching_Up) && !(Right_Block_Check.Touching_Right) && !(Down_Block_Check.Touching_Down) && (Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock1_0_0_1();
        }

        if (!(Up_Block_Check.Touching_Up) && !(Right_Block_Check.Touching_Right) && (Down_Block_Check.Touching_Down) && (Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock0_0_1_1();
        }

        if ((Up_Block_Check.Touching_Up) && !(Right_Block_Check.Touching_Right) && !(Down_Block_Check.Touching_Down) && !(Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock1_0_0_0();
        }

        if (!(Up_Block_Check.Touching_Up) && (Right_Block_Check.Touching_Right) && !(Down_Block_Check.Touching_Down) && !(Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock0_1_0_0();
        }

        if (!(Up_Block_Check.Touching_Up) && !(Right_Block_Check.Touching_Right) && (Down_Block_Check.Touching_Down) && !(Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock0_0_1_0();
        }

        if (!(Up_Block_Check.Touching_Up) && !(Right_Block_Check.Touching_Right) && !(Down_Block_Check.Touching_Down) && (Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock0_0_0_1();
        }

        if ((Up_Block_Check.Touching_Up) && !(Right_Block_Check.Touching_Right) && (Down_Block_Check.Touching_Down) && !(Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock1_0_1_0();
        }

        if (!(Up_Block_Check.Touching_Up) && (Right_Block_Check.Touching_Right) && !(Down_Block_Check.Touching_Down) && (Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock0_1_0_1();
        }

        if (!(Up_Block_Check.Touching_Up) && !(Right_Block_Check.Touching_Right) && !(Down_Block_Check.Touching_Down) && !(Left_Block_Check.Touching_Left))
        {
            ChangeSpriteBlock0_0_0_0();
        }
    }

    void ChangeSpriteBlock1_1_1_1()
    {
        spriteRenderer.sprite = Block1_1_1_1;
    }

    void ChangeSpriteBlock1_1_1_0()
    {
        spriteRenderer.sprite = Block1_1_1_0;
    }

    void ChangeSpriteBlock1_1_0_1()
    {
        spriteRenderer.sprite = Block1_1_0_1;
    }

    void ChangeSpriteBlock1_0_1_1()
    {
        spriteRenderer.sprite = Block1_0_1_1;
    }

    void ChangeSpriteBlock0_1_1_1()
    {
        spriteRenderer.sprite = Block0_1_1_1;
    }

    void ChangeSpriteBlock0_1_1_0()
    {
        spriteRenderer.sprite = Block0_1_1_0;
    }

    void ChangeSpriteBlock1_1_0_0()
    {
        spriteRenderer.sprite = Block1_1_0_0;
    }

    void ChangeSpriteBlock1_0_0_1()
    {
        spriteRenderer.sprite = Block1_0_0_1;
    }

    void ChangeSpriteBlock0_0_1_1()
    {
        spriteRenderer.sprite = Block0_0_1_1;
    }

    void ChangeSpriteBlock1_0_0_0()
    {
        spriteRenderer.sprite = Block1_0_0_0;
    }

    void ChangeSpriteBlock0_1_0_0()
    {
        spriteRenderer.sprite = Block0_1_0_0;
    }

    void ChangeSpriteBlock0_0_1_0()
    {
        spriteRenderer.sprite = Block0_0_1_0;
    }

    void ChangeSpriteBlock0_0_0_1()
    {
        spriteRenderer.sprite = Block0_0_0_1;
    }

    void ChangeSpriteBlock1_0_1_0()
    {
        spriteRenderer.sprite = Block1_0_1_0;
    }

    void ChangeSpriteBlock0_1_0_1()
    {
        spriteRenderer.sprite = Block0_1_0_1;
    }

    void ChangeSpriteBlock0_0_0_0()
    {
        spriteRenderer.sprite = Block0_0_0_0;
    }

}
