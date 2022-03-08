using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaShell : MonoBehaviour
{
    Rigidbody2D rb;
    public float direction;
    public bool Koopa;
    public GameObject KoopaGO;
    public GameObject Minecraft;

   
    // Start is called before the first frame update
    void Start()
    {
    Minecraft.SetActive(false);
    rb = this.GetComponent<Rigidbody2D> ();
    direction = 1f;
    }

    // Update is called once per frame
    void fixedUpdate()
    {
    if (Koopa == false){
    Minecraft.SetActive(true);
        rb.velocity = new Vector3 ( direction * 3f, rb.velocity.y);	
    }
    
    void OnTriggerEnter2D(Collider2D coll)
        {
        if(coll.gameObject.tag == "Player"){
           direction = 2f;
       }
      }
      }}    

