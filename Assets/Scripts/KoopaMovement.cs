using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float direction = 1;
    public KoopaShell gge; 
    public bool Koopa = true;
    public GameObject KoopaGO;

    // Start is called before the first frame update
    void Start()
    {
    rb = this.GetComponent<Rigidbody2D> ();
    direction = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(direction * 2f, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        rb.velocity = new Vector3 ( direction * 2f, rb.velocity.y);	
        if (Koopa == false){
        KoopaGO.transform.position = this.transform.position;
            Destroy(this.gameObject);
            }
    } 
}
    if (coll.gameObject.tag=="Player")
       direction = direction * -1;
    }
}
