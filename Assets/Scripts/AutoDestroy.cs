using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public int frame;

    void Start()
    {
        StartCoroutine(coroutine());
    }

    void Update()
    {
        if (frame <= 10)
        {
            Debug.Log("Frame: " + frame);
            frame++;
        }
    }

    IEnumerator coroutine()
    {
        yield return new WaitUntil(() => frame >= 10);
        Destroy(this.gameObject);
    }
}
