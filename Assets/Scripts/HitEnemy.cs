using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{

  public GameObject ExplosionPrefab;
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
    if (collision.gameObject.tag == "Enemy")
    {
      Eatworm eatworm = collision.gameObject.GetComponent<Eatworm>();
      if(eatworm  != null)
      {
        eatworm.hp--;
        if (eatworm.hp <= 0)
        {
          Destroy(collision.gameObject);
          Instantiate(ExplosionPrefab, collision.transform.position, collision.transform.rotation);

        }

      }
    }
  }
}
