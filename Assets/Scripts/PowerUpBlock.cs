using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBlock : MonoBehaviour
{
    public GameObject Item;

    public float angle = 0;
    public int numberOfObjects = 20;
    public float radius = 5f;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.GetComponent<Movement>().IsGround)
            {
                Vector3 pos = transform.position + new Vector3(0, 0.5f, 0);
                float angleDegrees = -angle * Mathf.Rad2Deg;
                Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
                Instantiate(Item, pos, rot);
            }

        }

    }
}
