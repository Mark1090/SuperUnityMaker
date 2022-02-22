using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour 
{
	[Header("Control")]
	public float speed = 5;
	public float jumpSpeed = 5;
	public bool once = false;
	public bool mainScreen;

    Vector3 initalPoint;
	SpriteRenderer sr;
	Rigidbody2D rb;
	//isJump bt;

		
	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		//bt = GetComponent<BetterJump> ();

		rb.freezeRotation = true;
        initalPoint = transform.position;
	}
	void OnDrawGizmosSelected()
	{
		if (!groundCheckPosition)
        {
			return;
		}
		Gizmos.DrawWireCube ((Vector3) groundCheckPosition.position, (Vector3)groundCheckSize);
	}

	bool ground;
	void Update () 
	{
        if (!Maker.playing)
        {
			if (!mainScreen)
            {
				rb.simulated = false;
				once = false;

				return;
			}
		}
        else
        {
			rb.simulated = true;

			if (once == false)
			{
				Vector3 newpos = new Vector3(-9.0f, -5.0f, 0.0f);
				this.transform.position = newpos;
				once = true;
			}
		}
        ground = IsGround;

		ManageFlip ();
		ManageJump ();
    }


	bool jumpRequest = false;
	void FixedUpdate()
	{
        if (!Maker.playing)
        {
			if (!mainScreen)
			{
				return;
			}
		}

        if (jumpRequest) 
		{
			jumpRequest = false;
			rb.AddForce (Vector2.up * jumpSpeed, ForceMode2D.Impulse);		
		}
	
		rb.velocity = new Vector3 (InputManager.HorizontalAxis * speed, rb.velocity.y);	

		//bt.ApplyBetterJump ();			
	}

	void ManageFlip()
	{
		if(InputManager.HorizontalAxis != 0)
			sr.flipX = InputManager.HorizontalAxis < 0;
	}

	void ManageJump()
	{		
		if (InputManager.JumpButtonPressed) {
			if (ground) {
                jumpRequest = true;
			}			
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            transform.position = initalPoint;
        }
    }
}
