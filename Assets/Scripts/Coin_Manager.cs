using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin_Manager : MonoBehaviour
{
    public AudioSource audio;
    public static int Coins;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Coins++;
            StartCoroutine(Action());
            audio.Play();
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    IEnumerator Action()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
