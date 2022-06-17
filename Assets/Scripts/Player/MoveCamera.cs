using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Maker makerScript;
    public LevelManager managerScript;
    public float xLimit = 100;
    public float yLimit = 100;
    public GameObject player;
    public float offset;
    public bool mainScreen;
    private Vector3 playerPosition;
    public float offsetSmoothing;
    public bool CanY;
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
                    if (this.transform.position.x <= xLimit)
                    {
                        this.transform.Translate(new Vector2(15f, 0f) * Time.deltaTime);
                    }
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (this.transform.position.y > -0.74)
                    {
                        this.transform.Translate(new Vector2(0f, -15f) * Time.deltaTime);
                    }
                    if (this.transform.position.y < -0.75)
                    {
                        this.transform.TransformVector(new Vector3(0f, -0.75f, 0f));
                    }


                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (this.transform.position.y <= yLimit)
                    {
                        this.transform.Translate(new Vector2(0f, 15f) * Time.deltaTime);
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
                if ((player.transform.position.x > 0) && (player.transform.position.x < xLimit))
                {
                    transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
                }
                else if (player.transform.position.x < 0)
                {
                    playerPosition = new Vector3(-0.5f, playerPosition.y, playerPosition.z);
                    transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
                }
                if (CanY)
                {
                    playerPosition = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
                    transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
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
            if ((player.transform.position.x > 0) && (player.transform.position.x < xLimit))
            {
                transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
            }
            else if (player.transform.position.x < 0)
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

