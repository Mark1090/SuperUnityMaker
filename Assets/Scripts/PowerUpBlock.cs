using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBlock : MonoBehaviour
{
    public GameObject Item;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Instantiate(Item);
        }

    }
}
