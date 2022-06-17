using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// This class is a simple example of how to build a controller that interacts with PlatformerMotor2D.
/// </summary>
[RequireComponent(typeof(PlatformerMotor2D))]
public class PlayerController2D : MonoBehaviour
{
    public GameObject Menu2;
    public bool IsActive2 = false;
    public AudioSource audio1;
    public AudioSource audio2;
    public bool ForcePlaying = true;
    public bool MainScreenRoblox = false;
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
            audio1.Play();
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

        }
        if ((collision.gameObject.tag == "Portal") && (IsActive2 == false))
        {
            IsActive2 = true;
            Menu2.gameObject.SetActive(IsActive2);
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        if ((collision.gameObject.tag == "Portal") && (MainScreenRoblox == true))
        {
            transform.position = initalPoint;
        }

    }
    
    IEnumerator Action()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

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
                audio2.Play();
            }
        }
        else
        {
            transform.position = initalPoint;
        }

    }
}
