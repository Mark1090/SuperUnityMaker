using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victorymenu : MonoBehaviour
{
    public GameObject Menu;
    public bool IsActive2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            IsActive2 = !IsActive2;

            Menu.gameObject.SetActive(IsActive2);
        }
    }
}
