using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Check : MonoBehaviour
{
    public string ObjectTag;
    public string ObjectName = "none";

    public Block_Changer ObjectScript;
    public Block_Changer Shh;

    public bool Touching = false;
    public bool Changes = true;

    void Update()
    {
        if (Changes == true)
        {
            Changes = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == ObjectTag)
        {
            Touching = true;

            Changes = true;
        }

    }

    void OnTriggerStay2D(Collider2D coll)
    {
        ObjectScript = coll.gameObject.GetComponent<Block_Changer>();
        if (ObjectScript == null)
        {           
            ObjectScript = Shh;
        }
 
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == ObjectTag)
        {
            Touching = false;

            Changes = true;
        }

    }
}

