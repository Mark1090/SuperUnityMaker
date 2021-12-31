using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Changer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

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

    private Sprite ChangeTo;

    public GameObject UpLeft;
    public GameObject UpRight;
    public GameObject DownLeft;
    public GameObject DownRight;

    private Block_Check UpBlockCheck;
    private Block_Check DownBlockCheck;
    private Block_Check LeftBlockCheck;
    private Block_Check RightBlockCheck; 

    public GameObject Up;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;

    public Maker makerScript;

    private bool OutOfRender = false;

    public string mode;


    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        UpLeft.SetActive(true);
        UpRight.SetActive(true);
        DownLeft.SetActive(true);
        DownRight.SetActive(true);

        UpBlockCheck = Up.GetComponent<Block_Check>();
        DownBlockCheck = Down.GetComponent<Block_Check>();
        LeftBlockCheck = Left.GetComponent<Block_Check>();
        RightBlockCheck = Right.GetComponent<Block_Check>();

        Detect();
    }

    void OnBecameInvisible()
    {
        Up.GetComponent<Collider2D>().enabled = false;
        Down.GetComponent<Collider2D>().enabled = false;
        Left.GetComponent<Collider2D>().enabled = false;
        Right.GetComponent<Collider2D>().enabled = false;

        Up.GetComponent<Block_Check>().enabled = false;
        Down.GetComponent<Block_Check>().enabled = false;
        Left.GetComponent<Block_Check>().enabled = false;
        Right.GetComponent<Block_Check>().enabled = false;

        OutOfRender = true;
    }

    void OnBecameVisible()
    {
        Up.GetComponent<Collider2D>().enabled = true;
        Down.GetComponent<Collider2D>().enabled = true;
        Left.GetComponent<Collider2D>().enabled = true;
        Right.GetComponent<Collider2D>().enabled = true;

        Up.GetComponent<Block_Check>().enabled = true;
        Down.GetComponent<Block_Check>().enabled = true;
        Left.GetComponent<Block_Check>().enabled = true;
        Right.GetComponent<Block_Check>().enabled = true;

        StartCoroutine(Render());
    }

    IEnumerator Render()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        OutOfRender = false;
    }

    void Update()
    {
        if((OutOfRender == false) && (Maker.playing == false))
        { 

            if ((UpBlockCheck.Changes == true) || (DownBlockCheck.Changes == true) || (LeftBlockCheck.Changes == true) || (RightBlockCheck.Changes == true))
            {
                Detect();
            }

            if (UpBlockCheck.ObjectScript.mode == "none")
            {
                UpLeft.SetActive(false);
                UpRight.SetActive(false);
            }

            if (DownBlockCheck.ObjectScript.mode == "none")
            {
                DownLeft.SetActive(false);
                DownRight.SetActive(false);
            }

            if (LeftBlockCheck.ObjectScript.mode == "none")
            {
                DownLeft.SetActive(false);
                UpLeft.SetActive(false);
            }

            if (RightBlockCheck.ObjectScript.mode == "none")
            {
                UpRight.SetActive(false);
                DownRight.SetActive(false);
            }

            if (UpBlockCheck.ObjectScript.mode == "Block1_1_1_1")
            {
                UpLeft.SetActive(false);
                UpRight.SetActive(false);
            }

            if (LeftBlockCheck.ObjectScript.mode == "Block1_1_1_1")
            {
                DownLeft.SetActive(false);
                UpLeft.SetActive(false);
            }

            if (RightBlockCheck.ObjectScript.mode == "Block1_1_1_1")
            {
                UpRight.SetActive(false);
                DownRight.SetActive(false);
            }

            if (DownBlockCheck.ObjectScript.mode == "Block1_1_1_1")
            {
                DownLeft.SetActive(false);
                DownRight.SetActive(false);
            }

            if (((UpBlockCheck.ObjectScript.mode == "Block0_0_1_0") || (UpBlockCheck.ObjectScript.mode == "Block1_0_1_1") || (UpBlockCheck.ObjectScript.mode == "Block0_0_1_1") || (UpBlockCheck.ObjectScript.mode == "Block1_0_1_0")) && ((RightBlockCheck.ObjectScript.mode == "Block0_1_1_1") || (RightBlockCheck.ObjectScript.mode == "Block0_0_1_1") || (RightBlockCheck.ObjectScript.mode == "Block0_0_0_1") || (RightBlockCheck.ObjectScript.mode == "Block0_1_0_1")))
            {
                UpRight.SetActive(true);
            }
            else
            {
                UpRight.SetActive(false);
            }

            if (((UpBlockCheck.ObjectScript.mode == "Block0_0_1_0") || (UpBlockCheck.ObjectScript.mode == "Block1_1_1_0") || (UpBlockCheck.ObjectScript.mode == "Block0_1_1_0") || (UpBlockCheck.ObjectScript.mode == "Block1_0_1_0")) && ((LeftBlockCheck.ObjectScript.mode == "Block0_1_0_0") || (LeftBlockCheck.ObjectScript.mode == "Block0_1_1_1") || (LeftBlockCheck.ObjectScript.mode == "Block0_1_0_1") || (LeftBlockCheck.ObjectScript.mode == "Block0_1_1_0")))
            {
                UpLeft.SetActive(true);
            }
            else
            {
                UpLeft.SetActive(false);
            }

            if (((DownBlockCheck.ObjectScript.mode == "Block1_0_0_0") || (DownBlockCheck.ObjectScript.mode == "Block1_1_0_0") || (DownBlockCheck.ObjectScript.mode == "Block1_1_1_0") || (DownBlockCheck.ObjectScript.mode == "Block1_0_1_0")) && ((LeftBlockCheck.ObjectScript.mode == "Block0_1_0_0") || (LeftBlockCheck.ObjectScript.mode == "Block0_1_0_1") || (LeftBlockCheck.ObjectScript.mode == "Block1_1_0_1") || (LeftBlockCheck.ObjectScript.mode == "Block1_1_0_0")))
            {
                DownLeft.SetActive(true);
            }
            else
            {
                DownLeft.SetActive(false);
            }

            if (((DownBlockCheck.ObjectScript.mode == "Block1_0_0_0") || (DownBlockCheck.ObjectScript.mode == "Block1_0_0_1") || (DownBlockCheck.ObjectScript.mode == "Block1_0_1_1") || (DownBlockCheck.ObjectScript.mode == "Block1_0_1_0")) && ((RightBlockCheck.ObjectScript.mode == "Block1_1_0_1") || (RightBlockCheck.ObjectScript.mode == "Block1_0_0_1") || (RightBlockCheck.ObjectScript.mode == "Block0_0_0_1") || (RightBlockCheck.ObjectScript.mode == "Block0_1_0_1")))
            {
                DownRight.SetActive(true);
            }
            else
            {
                DownRight.SetActive(false);
            }
        }
    }

    void Detect()
    {
         UpLeft.SetActive(false);
         UpRight.SetActive(false);
         DownLeft.SetActive(false);
         DownRight.SetActive(false);

         if (!(UpBlockCheck.Touching) && !(RightBlockCheck.Touching) && !(DownBlockCheck.Touching) && !(LeftBlockCheck.Touching))
         {
             mode = "Block0_0_0_0";
             ChangeTo = Block0_0_0_0;
             ChangeSprite();
         }
         else
         {
             if ((UpBlockCheck.Touching) && (RightBlockCheck.Touching) && (DownBlockCheck.Touching) && (LeftBlockCheck.Touching))
             {
                 mode = "Block1_1_1_1";
                 ChangeTo = Block1_1_1_1;
                 ChangeSprite();
             }
             else
             {
                 if ((UpBlockCheck.Touching) && (RightBlockCheck.Touching) && (DownBlockCheck.Touching) && !(LeftBlockCheck.Touching))
                 {
                     mode = "Block1_1_1_0";
                     ChangeTo = Block1_1_1_0;
                     ChangeSprite();
                 }
                 else
                 {
                     if ((UpBlockCheck.Touching) && (RightBlockCheck.Touching) && !(DownBlockCheck.Touching) && (LeftBlockCheck.Touching))
                     {
                         mode = "Block1_1_0_1";
                         ChangeTo = Block1_1_0_1;
                         ChangeSprite();
                     }
                     else
                     {
                         if ((UpBlockCheck.Touching) && !(RightBlockCheck.Touching) && (DownBlockCheck.Touching) && (LeftBlockCheck.Touching))
                         {
                             mode = "Block1_0_1_1";
                             ChangeTo = Block1_0_1_1; 
                             ChangeSprite();
                         }
                         else
                         {
                             if (!(UpBlockCheck.Touching) && (RightBlockCheck.Touching) && (DownBlockCheck.Touching) && (LeftBlockCheck.Touching))
                             {
                                 mode = "Block0_1_1_1";
                                 ChangeTo = Block0_1_1_1;
                                 ChangeSprite();
                             }
                             else
                             {
                                 if (!(UpBlockCheck.Touching) && (RightBlockCheck.Touching) && (DownBlockCheck.Touching) && !(LeftBlockCheck.Touching))
                                 {
                                     mode = "Block0_1_1_0";
                                     ChangeTo = Block0_1_1_0;
                                     ChangeSprite();
                                 }
                                 else
                                 {
                                     if ((UpBlockCheck.Touching) && (RightBlockCheck.Touching) && !(DownBlockCheck.Touching) && !(LeftBlockCheck.Touching))
                                     {
                                         mode = "Block1_1_0_0";
                                         ChangeTo = Block1_1_0_0;
                                         ChangeSprite();
                                     }
                                     else
                                     {
                                         if ((UpBlockCheck.Touching) && !(RightBlockCheck.Touching) && !(DownBlockCheck.Touching) && (LeftBlockCheck.Touching))
                                         {
                                             mode = "Block1_0_0_1";
                                             ChangeTo = Block1_0_0_1;
                                             ChangeSprite();
                                         }
                                         else
                                         {
                                             if (!(UpBlockCheck.Touching) && !(RightBlockCheck.Touching) && (DownBlockCheck.Touching) && (LeftBlockCheck.Touching))
                                             {
                                                 mode = "Block0_0_1_1";
                                                 ChangeTo = Block0_0_1_1;
                                                 ChangeSprite();
                                             }
                                             else
                                             {
                                                 if ((UpBlockCheck.Touching) && !(RightBlockCheck.Touching) && !(DownBlockCheck.Touching) && !(LeftBlockCheck.Touching))
                                                 {
                                                     mode = "Block1_0_0_0";
                                                     ChangeTo = Block1_0_0_0;
                                                     ChangeSprite();
                                                 }
                                                 else
                                                 {
                                                     if (!(UpBlockCheck.Touching) && (RightBlockCheck.Touching) && !(DownBlockCheck.Touching) && !(LeftBlockCheck.Touching))
                                                     {
                                                         mode = "Block0_1_0_0";
                                                         ChangeTo = Block0_1_0_0;
                                                         ChangeSprite();
                                                     }
                                                     else
                                                     {
                                                         if (!(UpBlockCheck.Touching) && !(RightBlockCheck.Touching) && (DownBlockCheck.Touching) && !(LeftBlockCheck.Touching))
                                                         {
                                                             mode = "Block0_0_1_0";
                                                             ChangeTo = Block0_0_1_0;
                                                             ChangeSprite();
                                                         }
                                                         else
                                                         {
                                                             if (!(UpBlockCheck.Touching) && !(RightBlockCheck.Touching) && !(DownBlockCheck.Touching) && (LeftBlockCheck.Touching))
                                                             {
                                                                 mode = "Block0_0_0_1";
                                                                 ChangeTo = Block0_0_0_1;
                                                                 ChangeSprite();
                                                             }
                                                             else
                                                             {
                                                                 if ((UpBlockCheck.Touching) && !(RightBlockCheck.Touching) && (DownBlockCheck.Touching) && !(LeftBlockCheck.Touching))
                                                                 {
                                                                     mode = "Block1_0_1_0";
                                                                     ChangeTo = Block1_0_1_0;
                                                                     ChangeSprite();
                                                                 }
                                                                 else
                                                                 {
                                                                     if (!(UpBlockCheck.Touching) && (RightBlockCheck.Touching) && !(DownBlockCheck.Touching) && (LeftBlockCheck.Touching))
                                                                     {
                                                                         mode = "Block0_1_0_1";
                                                                         ChangeTo = Block0_1_0_1;
                                                                         ChangeSprite();
                                                                     }

                                                                 }

                                                             }

                                                         }

                                                     }

                                                 }

                                             }

                                         }

                                     }

                                 }

                             }

                         }

                     }

                 }

             }

         }



    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = ChangeTo;
    }
}