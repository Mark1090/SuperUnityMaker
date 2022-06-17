using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
	private static AudioSource instance;
	private void Awake()
	{
		GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
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
			