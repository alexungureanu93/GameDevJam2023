using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] public int target;
    [SerializeField] bool isLast = false;
    [SerializeField] FunkyCode.Light2D Light2D;
    [SerializeField] Color defaultColor = Color.red;
    [SerializeField] Color unlockColor = Color.blue;
    
    Wallet playerWallet;

    bool isUnlocked;

    void Awake() 
    {
        Light2D.color = defaultColor;
        playerWallet = FindObjectOfType<Wallet>();
    }

    void Update()
    {
        //Check if player has enough coins to unlock the goal
        if(playerWallet.GetCoins() >= target)
        {
            isUnlocked = true;
            Light2D.color = unlockColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Complete the level if the player has enough coins
        if (other.GetComponent<Wallet>() == playerWallet)
        {
            if(isUnlocked) {
                if(isLast)
                  LevelManager.Instance.LoadCongrats();
                else
                  LevelManager.Instance.NextLevel();
            }
        }
    }
}
