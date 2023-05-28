using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightTrigger : MonoBehaviour
{

  public TorchManager torchManager;
  public GameObject LightTorch;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    torchManager.torchActive = true;
    LightTorch.SetActive(true);
    Destroy(gameObject);
    
  }
}
