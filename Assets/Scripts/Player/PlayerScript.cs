using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	[Header("Control")]
	public float speed = 5;
	public float jumpSpeed = 5;
	public bool once = false;
	public bool mainScreen;
	public bool IsGround = true;
	public bool ground = true;
	public int PowerUp = 0;
	public Sprite image;
	private SpriteRenderer spriteRenderer;

	Vector3 initalPoint;
	SpriteRenderer sr;
	Rigidbody2D rb;


	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();

		rb.freezeRotation = true;
		initalPoint = transform.position;
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Spikes"))
		{
			transform.position = initalPoint;
		}
	}


	void Update()
	{
		if (PowerUp == 1)
			spriteRenderer.sprite = image;

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


	void ManageFlip()
	{
		if (InputManager.HorizontalAxis == 0)
			sr.flipX = InputManager.HorizontalAxis < 0;

		if (InputManager.HorizontalAxis != 0)
			sr.flipX = InputManager.HorizontalAxis > 0;

	}

	void ManageJump()
	{
		if (InputManager.JumpButtonPressed)
		{
			if (ground)
			{
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
