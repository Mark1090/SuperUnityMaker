using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONOFF_Controller : MonoBehaviour
{
    public bool Change = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (!coll.gameObject.GetComponent<PlayerScript>().ground)
            {
                if (coll.gameObject.tag == "Player")
                {
                    if (Change)
                    {
                        Change = false;
                    }
                    else
                    {
                        Change = true;
                    }
                }
            }
        }
    }
}
