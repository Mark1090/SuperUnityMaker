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
	public bool IsGround = true;
	public bool ground = true;

	Vector3 initalPoint;
	SpriteRenderer sr;
	Rigidbody2D rb;


	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();

		rb.freezeRotation = true;
		initalPoint = transform.position;
	}
	/*void OnDrawGizmosSelected()
	{
		if (!groundCheckPosition)
        {
			return;
		}
		Gizmos.DrawWireCube ((Vector3) groundCheckPosition.position, (Vector3)groundCheckSize);
	}*/
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Spikes"))
		{
			transform.position = initalPoint;
		}
		ground = true;
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		ground = true;
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		ground = false;

	}


	void Update()
	{
		if (!Maker.playing)
		{
			if (!mainScreen)
			{
				return;
			}
		}

		ManageFlip();
		ManageJump();

		if ((ground) && (InputManager.JumpButtonPressed))
        {
			rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
		}
		
	}
	void FixedUpdate()
	{
		if (!Maker.playing)
		{
			if (!mainScreen)
			{
				return;
			}
		}

		rb.velocity = new Vector3(InputManager.HorizontalAxis * speed, rb.velocity.y);
	}


		/*     if (!Maker.playing)
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


		 }


		 bool jumpRequest = false;

		 }*/

		void ManageFlip()
		 {
			 if(InputManager.HorizontalAxis != 0)
				 sr.flipX = InputManager.HorizontalAxis < 0;
		 }

		 void ManageJump()
		 {		
			 if (InputManager.JumpButtonPressed) {
				 if (ground) {
					 //jumpRequest = true;
				 }			
			 }
		 }

		 /*





		 if (jumpRequest)
		{
			jumpRequest = false;
			rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
		}*/


}
