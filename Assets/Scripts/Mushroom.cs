using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    Rigidbody2D rb;
    public float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        direction = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(direction * 3f, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        direction = direction * -1;

        if (coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Coin_Manager.Coins ++;
            Coin_Manager.Coins ++;
            Coin_Manager.Coins++;
            Coin_Manager.Coins++;
            Coin_Manager.Coins++;
        }
    }
}
