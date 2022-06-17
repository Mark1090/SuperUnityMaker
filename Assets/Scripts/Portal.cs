using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject Menu;
    public bool IsActive = false;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.GetComponent<PlatformerMotor2D>().motorState == PlatformerMotor2D.MotorState.Jumping)
            {
                {
                    IsActive = !IsActive;

                    Menu.gameObject.SetActive(IsActive);
                }

            }

        }

    }
}
