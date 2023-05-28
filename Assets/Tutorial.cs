using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

  public TorchManager torchManager;
  public GameObject tutorialBlock;
  public GameObject message;

  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (torchManager.torchActive)
    {
      tutorialBlock.SetActive(false);
    }
    else
    {
      message.SetActive(true);
      Invoke("DisableMessage",3f);
    }
  }
  public void DisableMessage()
  {
    message.SetActive(false);
  }
}
