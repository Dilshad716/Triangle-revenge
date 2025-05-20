using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameStatus : MonoBehaviour
{
     [SerializeField] Text HealtCount;
     [SerializeField] TextMeshProUGUI Score;
     [SerializeField] TextMeshProUGUI Coin;
     public float CurrentScore = 0;
     public int CurrentCoin = 0;
     [SerializeField] PlayerMovement myPlayerMovement; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealtCount.text = myPlayerMovement.PlayerHealth.ToString();
        Score.text = CurrentScore.ToString();
        Coin.text = CurrentCoin.ToString();
    }
}
