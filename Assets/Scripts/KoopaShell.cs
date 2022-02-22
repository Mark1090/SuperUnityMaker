using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaShell : MonoBehaviour
{
    Rigidbody2D rb;
    public float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
    rb = this.GetComponent<Rigidbody2D> ();
    direction = 1f;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnTriggerEnter2D(Collider2D coll)
        {
        if(coll.gameObject.tag == "Player"){
           direction = 2f;

       }
      }

}
