using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
<<<<<<< Updated upstream
    void OnTriggerEnter2D(Collider2D other) 
=======
  public GameObject ExplosionPrefab;
    public AudioClip destroySound;

  void OnTriggerEnter2D(Collider2D other) 
>>>>>>> Stashed changes
    {
        //Add the coin to the player wallet when collectd
        Wallet wallet = other.GetComponent<Wallet>();
        if(wallet != null)
        {
            wallet.IncrementCoins();
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
            Destroy(gameObject);
          Instantiate(ExplosionPrefab, other.transform.position, other.transform.rotation);

    }
  }
}
