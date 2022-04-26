using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock_Manager : MonoBehaviour
{
    public GameObject Block;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (!coll.gameObject.GetComponent<PlayerScript>().ground)
            {
                Destroy(Block);
            }

        }

    }
}
