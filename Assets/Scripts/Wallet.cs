using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    int coins = 0;

  public Slider slider;
  public Goal Goal;

    private void Start()
    {
      slider.maxValue = Goal.target;
      slider.value = 0;
    }
  
  public int GetCoins()
    {
        return coins;
    }

    public void IncrementCoins()
    {
        coins++;
        slider.value = coins;
    }

}
