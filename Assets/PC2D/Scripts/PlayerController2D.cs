using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is a simple example of how to build a controller that interacts with PlatformerMotor2D.
/// </summary>
[RequireComponent(typeof(PlatformerMotor2D))]
public class PlayerController2D : MonoBehaviour
{
    public bool ForcePlaying = true;
    private PlatformerMotor2D _motor;
    Vector3 initalPoint;
    // Use this for initialization
    void Start()
    {
        _motor = GetComponent<PlatformerMotor2D>();
        initalPoint = transform.position;
    }
    void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Spikes"))
		{

            StartCoroutine(Action());
            GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Renderer>().enabled = false;

        }
    }
    
    IEnumerator Action()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Renderer>().enabled = true;
        transform.position = initalPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (ForcePlaying)
        {
            if (Mathf.Abs(Input.GetAxis(PC2D.Input.HORIZONTAL)) > PC2D.Globals.INPUT_THRESHOLD)
            {
                _motor.normalizedXMovement = Input.GetAxis(PC2D.Input.HORIZONTAL);
            }
            else
            {
                _motor.normalizedXMovement = 0;
            }

            // Jump?
            if (Input.GetButtonDown(PC2D.Input.JUMP))
            {
                _motor.Jump();
            }

            _motor.jumpingHeld = Input.GetButton(PC2D.Input.JUMP);

            if (Input.GetAxis(PC2D.Input.VERTICAL) < -PC2D.Globals.FAST_FALL_THRESHOLD)
            {
                _motor.fallFast = true;
            }
            else
            {
                _motor.fallFast = false;
            }

            if (Input.GetButtonDown(PC2D.Input.DASH))
            {
                _motor.Dash();
            }
        }


        else if (Maker.playing)
        {
            if (Mathf.Abs(Input.GetAxis(PC2D.Input.HORIZONTAL)) > PC2D.Globals.INPUT_THRESHOLD)
            {
                _motor.normalizedXMovement = Input.GetAxis(PC2D.Input.HORIZONTAL);
            }
            else
            {
                _motor.normalizedXMovement = 0;
            }

            // Jump?
            if (Input.GetButtonDown(PC2D.Input.JUMP))
            {
                _motor.Jump();
            }

            _motor.jumpingHeld = Input.GetButton(PC2D.Input.JUMP);

            if (Input.GetAxis(PC2D.Input.VERTICAL) < -PC2D.Globals.FAST_FALL_THRESHOLD)
            {
                _motor.fallFast = true;
            }
            else
            {
                _motor.fallFast = false;
            }

            if (Input.GetButtonDown(PC2D.Input.DASH))
            {
                _motor.Dash();
            }
        }

    }
}
