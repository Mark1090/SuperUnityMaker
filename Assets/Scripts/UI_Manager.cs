using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static Maker mk;
    public GameObject Settings;
    public GameObject BlockSelec;
    public GameObject CoinUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Maker.playing)
        {
            Settings.SetActive(false);
            BlockSelec.SetActive(false);
            CoinUI.SetActive(true);
        }
        else
        {
            Settings.SetActive(true);
            BlockSelec.SetActive(true);
            CoinUI.SetActive(false);
        }
    }
}
