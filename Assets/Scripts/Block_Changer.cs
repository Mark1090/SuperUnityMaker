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

    public GameObject UpLeft;
    public GameObject UpRight;
    public GameObject DownLeft;
    public GameObject DownRight;

    public Block_Check Up_Block_Check;
    public Block_Check Down_Block_Check;
    public Block_Check Left_Block_Check;
    public Block_Check Right_Block_Check;

    public GameObject Up;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;

    public Block_Check Up_Left;
    public Block_Check Up_Right;
    public Block_Check Down_Left;
    public Block_Check Down_Right;

    private bool OutOfRender = false;

    public string mode;

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

    void Start()
    {
        UpLeft.SetActive(true);
        UpRight.SetActive(true);
        DownLeft.SetActive(true);
        DownRight.SetActive(true);

        Detect();
    }

    void Update()
    {
        if(OutOfRender == false)
        {
            UpLeft.SetActive(false);
            UpRight.SetActive(false);
            DownLeft.SetActive(false);
            DownRight.SetActive(false);

            if ((Up_Block_Check.Changes == true) || (Down_Block_Check.Changes == true) || (Left_Block_Check.Changes == true) || (Right_Block_Check.Changes == true))
            {
                Detect();
            }


            if (Up_Block_Check.ObjectScript.mode == "none")
            {
                UpLeft.SetActive(false);
                UpRight.SetActive(false);
            }

            if (Down_Block_Check.ObjectScript.mode == "none")
            {
                DownLeft.SetActive(false);
                DownRight.SetActive(false);
            }

            if (Left_Block_Check.ObjectScript.mode == "none")
            {
                DownLeft.SetActive(false);
                UpLeft.SetActive(false);
            }

            if (Right_Block_Check.ObjectScript.mode == "none")
            {
                UpRight.SetActive(false);
                DownRight.SetActive(false);
            }

            if (Up_Block_Check.ObjectScript.mode == "Block1_1_1_1")
            {
                UpLeft.SetActive(false);
                UpRight.SetActive(false);
            }

            if (Left_Block_Check.ObjectScript.mode == "Block1_1_1_1")
            {
                DownLeft.SetActive(false);
                UpLeft.SetActive(false);
            }

            if (Right_Block_Check.ObjectScript.mode == "Block1_1_1_1")
            {
                UpRight.SetActive(false);
                DownRight.SetActive(false);
            }

            if (Down_Block_Check.ObjectScript.mode == "Block1_1_1_1")
            {
                DownLeft.SetActive(false);
                DownRight.SetActive(false);
            }

            if (((Up_Block_Check.ObjectScript.mode == "Block0_0_1_0") || (Up_Block_Check.ObjectScript.mode == "Block1_0_1_1") || (Up_Block_Check.ObjectScript.mode == "Block0_0_1_1") || (Up_Block_Check.ObjectScript.mode == "Block1_0_1_0")) && ((Right_Block_Check.ObjectScript.mode == "Block0_1_1_1") || (Right_Block_Check.ObjectScript.mode == "Block0_0_1_1") || (Right_Block_Check.ObjectScript.mode == "Block0_0_0_1") || (Right_Block_Check.ObjectScript.mode == "Block0_1_0_1")))
            {
                UpRight.SetActive(true);
            }
            else
            {
                UpRight.SetActive(false);
            }

            if (((Up_Block_Check.ObjectScript.mode == "Block0_0_1_0") || (Up_Block_Check.ObjectScript.mode == "Block1_1_1_0") || (Up_Block_Check.ObjectScript.mode == "Block0_1_1_0") || (Up_Block_Check.ObjectScript.mode == "Block1_0_1_0")) && ((Left_Block_Check.ObjectScript.mode == "Block0_1_0_0") || (Left_Block_Check.ObjectScript.mode == "Block0_1_1_1") || (Left_Block_Check.ObjectScript.mode == "Block0_1_0_1") || (Left_Block_Check.ObjectScript.mode == "Block0_1_1_0")))
            {
                UpLeft.SetActive(true);
            }
            else
            {
                UpLeft.SetActive(false);
            }

            if (((Down_Block_Check.ObjectScript.mode == "Block1_0_0_0") || (Down_Block_Check.ObjectScript.mode == "Block1_1_0_0") || (Down_Block_Check.ObjectScript.mode == "Block1_1_1_0") || (Down_Block_Check.ObjectScript.mode == "Block1_0_1_0")) && ((Left_Block_Check.ObjectScript.mode == "Block0_1_0_0") || (Left_Block_Check.ObjectScript.mode == "Block0_1_0_1") || (Left_Block_Check.ObjectScript.mode == "Block1_1_0_1") || (Left_Block_Check.ObjectScript.mode == "Block1_1_0_0")))
            {
                DownLeft.SetActive(true);
            }
            else
            {
                DownLeft.SetActive(false);
            }

            if (((Down_Block_Check.ObjectScript.mode == "Block1_0_0_0") || (Down_Block_Check.ObjectScript.mode == "Block1_0_0_1") || (Down_Block_Check.ObjectScript.mode == "Block1_0_1_1") || (Down_Block_Check.ObjectScript.mode == "Block1_0_1_0")) && ((Right_Block_Check.ObjectScript.mode == "Block1_1_0_1") || (Right_Block_Check.ObjectScript.mode == "Block1_0_0_1") || (Right_Block_Check.ObjectScript.mode == "Block0_0_0_1") || (Right_Block_Check.ObjectScript.mode == "Block0_1_0_1")))
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
        if (!(Up_Block_Check.Touching) && !(Right_Block_Check.Touching) && !(Down_Block_Check.Touching) && !(Left_Block_Check.Touching))
        {
            ChangeSpriteBlock0_0_0_0();

            mode = "Block0_0_0_0";
        }
        else
        {
            if ((Up_Block_Check.Touching) && (Right_Block_Check.Touching) && (Down_Block_Check.Touching) && (Left_Block_Check.Touching))
            {
                ChangeSpriteBlock1_1_1_1();

                mode = "Block1_1_1_1";
            }
            else
            {
                if ((Up_Block_Check.Touching) && (Right_Block_Check.Touching) && (Down_Block_Check.Touching) && !(Left_Block_Check.Touching))
                {
                    ChangeSpriteBlock1_1_1_0();

                    mode = "Block1_1_1_0";
                }
                else
                {
                    if ((Up_Block_Check.Touching) && (Right_Block_Check.Touching) && !(Down_Block_Check.Touching) && (Left_Block_Check.Touching))
                    {
                        ChangeSpriteBlock1_1_0_1();

                        mode = "Block1_1_0_1";
                    }
                    else
                    {
                        if ((Up_Block_Check.Touching) && !(Right_Block_Check.Touching) && (Down_Block_Check.Touching) && (Left_Block_Check.Touching))
                        {
                            ChangeSpriteBlock1_0_1_1();

                            mode = "Block1_0_1_1";
                        }
                        else
                        {
                            if (!(Up_Block_Check.Touching) && (Right_Block_Check.Touching) && (Down_Block_Check.Touching) && (Left_Block_Check.Touching))
                            {
                                ChangeSpriteBlock0_1_1_1();

                                mode = "Block0_1_1_1";
                            }
                            else
                            {
                                if (!(Up_Block_Check.Touching) && (Right_Block_Check.Touching) && (Down_Block_Check.Touching) && !(Left_Block_Check.Touching))
                                {
                                    ChangeSpriteBlock0_1_1_0();

                                    mode = "Block0_1_1_0";
                                }
                                else
                                {
                                    if ((Up_Block_Check.Touching) && (Right_Block_Check.Touching) && !(Down_Block_Check.Touching) && !(Left_Block_Check.Touching))
                                    {
                                        ChangeSpriteBlock1_1_0_0();

                                        mode = "Block1_1_0_0";
                                    }
                                    else
                                    {
                                        if ((Up_Block_Check.Touching) && !(Right_Block_Check.Touching) && !(Down_Block_Check.Touching) && (Left_Block_Check.Touching))
                                        {
                                            ChangeSpriteBlock1_0_0_1();

                                            mode = "Block1_0_0_1";
                                        }
                                        else
                                        {
                                            if (!(Up_Block_Check.Touching) && !(Right_Block_Check.Touching) && (Down_Block_Check.Touching) && (Left_Block_Check.Touching))
                                            {
                                                ChangeSpriteBlock0_0_1_1();

                                                mode = "Block0_0_1_1";
                                            }
                                            else
                                            {
                                                if ((Up_Block_Check.Touching) && !(Right_Block_Check.Touching) && !(Down_Block_Check.Touching) && !(Left_Block_Check.Touching))
                                                {
                                                    ChangeSpriteBlock1_0_0_0();

                                                    mode = "Block1_0_0_0";
                                                }
                                                else
                                                {
                                                    if (!(Up_Block_Check.Touching) && (Right_Block_Check.Touching) && !(Down_Block_Check.Touching) && !(Left_Block_Check.Touching))
                                                    {
                                                        ChangeSpriteBlock0_1_0_0();

                                                        mode = "Block0_1_0_0";
                                                    }
                                                    else
                                                    {
                                                        if (!(Up_Block_Check.Touching) && !(Right_Block_Check.Touching) && (Down_Block_Check.Touching) && !(Left_Block_Check.Touching))
                                                        {
                                                            ChangeSpriteBlock0_0_1_0();

                                                            mode = "Block0_0_1_0";
                                                        }
                                                        else
                                                        {
                                                            if (!(Up_Block_Check.Touching) && !(Right_Block_Check.Touching) && !(Down_Block_Check.Touching) && (Left_Block_Check.Touching))
                                                            {
                                                                ChangeSpriteBlock0_0_0_1();

                                                                mode = "Block0_0_0_1";
                                                            }
                                                            else
                                                            {
                                                                if ((Up_Block_Check.Touching) && !(Right_Block_Check.Touching) && (Down_Block_Check.Touching) && !(Left_Block_Check.Touching))
                                                                {
                                                                    ChangeSpriteBlock1_0_1_0();

                                                                    mode = "Block1_0_1_0";
                                                                }
                                                                else
                                                                {
                                                                    if (!(Up_Block_Check.Touching) && (Right_Block_Check.Touching) && !(Down_Block_Check.Touching) && (Left_Block_Check.Touching))
                                                                    {
                                                                        ChangeSpriteBlock0_1_0_1();

                                                                        mode = "Block0_1_0_1";
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