using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
  public GameObject ExplosionPrefab;
  public GameObject CollectPrefab;

  void OnTriggerEnter2D(Collider2D other) 
    {
        //Add the coin to the player wallet when collectd
        Wallet wallet = other.GetComponent<Wallet>();
        if(wallet != null)
        {
            wallet.IncrementCoins();
          Instantiate(ExplosionPrefab, other.transform.position, other.transform.rotation);
          Instantiate(CollectPrefab, other.transform.position, other.transform.rotation);
          Destroy(gameObject);

    }
  }
}
