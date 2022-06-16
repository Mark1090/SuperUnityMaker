using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Manager : MonoBehaviour
{
    public static int Coins;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Coins++;
            StartCoroutine(Action());
            Destroy(this.gameObject);
        }
    }

    IEnumerator Action()
    {
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }
}
