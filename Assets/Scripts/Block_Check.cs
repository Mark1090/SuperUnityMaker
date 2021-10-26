using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Check : MonoBehaviour
{
    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;

    public string BlockTag;

    public bool Touching_Up;
    public bool Touching_Down;
    public bool Touching_Left;
    public bool Touching_Right;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == BlockTag )
        {
            Debug.Log("Hit" + coll.gameObject.name);
            if (Up)
            {
                Touching_Up = true;
            }
            if (Down)
            {
                Touching_Down = true;
            }
            if (Left)
            {
                Touching_Left = true;
            }
            if (Right)
            {
                Touching_Right = true;
            }
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (Up)
        {
            Touching_Up = false;
        }
        if (Down)
        {
            Touching_Down = false;
        }
        if (Left)
        {
            Touching_Left = false;
        }
        if (Right)
        {
            Touching_Right = false;
        }
    }
}

