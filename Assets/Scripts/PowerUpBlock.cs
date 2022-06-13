using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBlock : MonoBehaviour
{
    public GameObject Item;

    public SpriteRenderer spriteRenderer;
    public Sprite OFF;
    public float angle = 0;
    public int numberOfObjects = 20;
    public float radius = 5f;
    
    void Start()
    {
       // spriteRenderer = GetComponent<SpriteRenderer>().
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.GetComponent<PlatformerMotor2D>().motorState == PlatformerMotor2D.MotorState.Jumping)
            {
                if (numberOfObjects > 0)
                {
                    Vector3 pos = transform.position + new Vector3(0, 0.5f, 0);
                    float angleDegrees = -angle * Mathf.Rad2Deg;
                    Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
                    Instantiate(Item, pos, rot);
                    numberOfObjects = numberOfObjects - 1;
                }
                if (numberOfObjects <= 1)
                {
                    spriteRenderer.sprite = OFF;
                    this.gameObject.GetComponent<PowerUpBlock>().enabled = false;
                }
                
            }

        }

    }
}
