using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TorchManager : MonoBehaviour
{

    public GameObject[] Torchs;

  private int currentTorch = 0;

  private Animator animator;

  public CharacterController2D characterController2D;

  public bool torchActive = true;

  //public delegate void OnTorchChanged(int torch);
  //public static OnTorchChanged onTorchChanged;

  // Start is called before the first frame update
  void Start()
    {
    if (Torchs.Length == 3 && torchActive)
    {
      if (Torchs[0] != null && !Torchs[0].active)
        Torchs[0].SetActive(true);
      if (Torchs[1] != null && Torchs[1].active)
        Torchs[1].SetActive(false);
      if (Torchs[2] != null && Torchs[2].active)
        Torchs[2].SetActive(false);
      //onTorchChanged.Invoke(0);
    }
    animator = GetComponentInChildren<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!torchActive)
      return;
    if (Input.GetButtonDown("Fire2"))
    {
      Torchs[currentTorch].SetActive(false);
      var pos = Torchs[currentTorch].transform.position;
      currentTorch++;
      if (currentTorch > 2)
        currentTorch = 0;
      Torchs[currentTorch].transform.position = pos;
      Torchs[currentTorch].SetActive(true);
      //onTorchChanged.Invoke(currentTorch);

      if (currentTorch == 0)
      {
        characterController2D.moveSpeed = 8f;
        characterController2D.jumpForce= 20f;
      }
      if (currentTorch == 1)
      {
        characterController2D.moveSpeed = 6f;
        characterController2D.jumpForce = 15f;
      }
      if (currentTorch == 2)
      {
        characterController2D.moveSpeed = 4f;
        characterController2D.jumpForce = 10f;
      }
    }
    if (Input.GetButtonDown("Fire1")) { 
      animator.SetTrigger("attack");
    }
  }

  public int GetCurrentTorchNumber()
  {
    return currentTorch;
  }
}
