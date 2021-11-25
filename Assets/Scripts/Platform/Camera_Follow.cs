using UnityEngine;
using System.Collections;
public class Camera_Follow : MonoBehaviour
{
    public GameObject player;
    public float offset;
    private Vector3 playerPosition;
    public float offsetSmoothing;
    public Maker makerScript;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (Maker.playing)
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
            if (player.transform.position.x > -0.2)
            {
                transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
            }
            else
            {

                playerPosition = new Vector3(0 - offset, playerPosition.y, playerPosition.z);
                transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
            }
        }
    }
}
