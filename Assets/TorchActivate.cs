using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchActivate : MonoBehaviour
{
  public GameObject ObjectToActive;
  public int enemyType = 0;

    // Start is called before the first frame update
    void Start()
    {
      TorchManager.onTorchChanged += ActivateTorch;
  }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void ActivateTorch(int current)
  {
    if(current == enemyType)
    {
      ObjectToActive.SetActive(true);
    }
    else
    {
      ObjectToActive.SetActive(false);
    }
  }
}
