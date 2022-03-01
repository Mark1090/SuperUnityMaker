using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float direction = 1;
    public KoopaShell gge; 
    public bool Koopa = true;

    // Start is called before the first frame update
    
    void Start()
    {
    rb = this.GetComponent<Rigidbody2D> ();
    direction = 1f;
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D coll) 
    {
        
        if(coll.gameObject.tag=="Shell") 
        {
        
        }else{
        direction = direction * -1;
        }
        if (coll.gameObject.tag=="Player")
        {
        Koopa = false;
        }
    }
    

    void FixedUpdate()
    {
        rb.velocity = new Vector3 ( direction * 2f, rb.velocity.y);	
        if (Koopa == false){
            Destroy(this.gameObject);
            }
    } 
}