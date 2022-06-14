using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Maker mk;
    public Coin_Manager CM;
    public GameObject Settings;
    public GameObject BlockSelec;
    public GameObject CoinUI;
    public Text CoinTXT;
    public bool ForcePlaying;
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
        else if (ForcePlaying)
        {
            CoinUI.SetActive(true);

        } else{
            Settings.SetActive(true);
            BlockSelec.SetActive(true);
            CoinUI.SetActive(false);
            Coin_Manager.Coins = 0;
        } 

        CoinTXT.text = Coin_Manager.Coins.ToString();
    }
}
