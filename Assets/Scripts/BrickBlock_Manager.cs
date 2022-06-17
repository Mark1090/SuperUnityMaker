using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock_Manager : MonoBehaviour
{
    public GameObject Block;
    public Renderer rend;

    ParticleSystem system
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }
    private ParticleSystem _CachedSystem;

    public Rect windowRect = new Rect(0, 0, 300, 120);

    public bool includeChildren = true;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
 
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.GetComponent<PlatformerMotor2D>().motorState == PlatformerMotor2D.MotorState.Jumping)
            {
                Block.GetComponent<SpriteRenderer>().enabled = false;
                system.Play(includeChildren);
                StartCoroutine(coroutine());
            }

        }

    }

    IEnumerator coroutine()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Block.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(Block);
    }
}
