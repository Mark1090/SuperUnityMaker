using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2;
	Rigidbody2D rb;
	public Movement mv;
	public bool IsJumping = false;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	public void ApplyBetterJump()
	{
		IsJumping = true;

		if (rb.velocity.y < 0.1f) 
		{
			rb.gravityScale = fallMultiplier;
		} 
		else if (rb.velocity.y > 0.1f && !InputManager.JumpButton) 
		{
			rb.gravityScale = lowJumpMultiplier;
		} 
		else if (mv.IsGround)
		{
			rb.gravityScale = 1;
			IsJumping = false;
		}	
	}
}