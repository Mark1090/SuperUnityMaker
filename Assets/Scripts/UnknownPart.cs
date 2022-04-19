using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownPart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var col = gameObject.GetComponent<Renderer> ().material.color;
        col.a = 0.2f;

    }

    // Update is called once per frame
    void Update()
    {
    }

   // void OnTriggerEnter2D(Collider2D coll)
   // {
    //    if (coll.gameObject.tag == "Player")
    //    {
            // Destroy(this.gameObject);
           // for (int i = 255; i = 0; i--)
           // gameObject.GetComponent<Renderer>().material.color.a = i;
     //   }
   // }
}