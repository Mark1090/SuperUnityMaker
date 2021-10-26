using UnityEngine;

public class Raycast : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            Debug.Log("Hit");
        }
    }
}
