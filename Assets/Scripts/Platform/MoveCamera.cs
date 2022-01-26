using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Maker makerScript;
    public LevelManager managerScript;
    public float limit = 100;
    public GameObject player;
    public float offset;
    public bool mainScreen;
    private Vector3 playerPosition;
    public float offsetSmoothing;

    void Start()
    {
        
    }

    void Update()
    {
        if (!mainScreen)
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
        }
        else
        {
            playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            if (player.transform.localScale.x > 0f)
            {
                playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
            }
            else
            {
                playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
            }
            if (player.transform.position.x > 0)
            {
                transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
            }
            else
            {

                playerPosition = new Vector3(-0.5f, playerPosition.y, playerPosition.z);
                transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
            }
        }

        if (this.transform.position.x < -0.5)
        {
            this.transform.TransformVector(new Vector3(-0.5f, 0f, 0f));
        }
        if (!mainScreen)
        {    
        if (managerScript.loading == true)
        {
            this.GetComponent<Camera>().orthographicSize = 1000.0f;
            managerScript.loading = false; 
            StartCoroutine(parent());
        }     
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

