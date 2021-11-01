using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Maker makerScript;
    public LevelManager managerScript;
    public float limit = 100;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!Maker.playing)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.transform.position.x >= -0.5)
                {
                this.transform.Translate(new Vector2(-15f, 0f) * Time.deltaTime);
                }
                    
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (this.transform.position.x <= limit)
                {
                    this.transform.Translate(new Vector2(15f, 0f) * Time.deltaTime);
                }
            }
        }
        if (this.transform.position.x < -0.5)
        {
            this.transform.TransformVector(new Vector3(-0.5f, 0f, 0f));
        }

        if (managerScript.loading == true)
        {
            this.GetComponent<Camera>().orthographicSize = 1000.0f;
            managerScript.loading = false; 
            StartCoroutine(parent());
        }        
    }

    IEnumerator parent()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        this.GetComponent<Camera>().orthographicSize = 6.75f;
    }
}

