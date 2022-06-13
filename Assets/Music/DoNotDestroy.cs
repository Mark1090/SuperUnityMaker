using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
	public float length;
	private static Audio Source instance;
	private void Awake()
	{
		GameObject musicObj = GameObject.FindGameObjectWithTag("Music");
		if(instance != null)
		{	
			Destroy(this.gameObject);
		}
		else 
		{
		DontDestroyOnLoad(this.gameObject);
		}
	}
}    
			