using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJump : MonoBehaviour
{
	public PlayerScript PS;

	void OnTriggerEnter2D(Collider2D collision)
	{
		PS.ground = true;
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		PS.ground = true;
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		PS.ground = false;
	}
}
