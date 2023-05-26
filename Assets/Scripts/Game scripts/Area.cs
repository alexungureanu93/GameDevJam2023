using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Eatworm eatworm = collision.GetComponent<Eatworm>();
        if (eatworm != null)
        {
            eatworm.StartPatrol();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Eatworm eatworm = collision.GetComponent<Eatworm>();
        if (eatworm != null)
        {
            eatworm.StopPatrol();
        }
    }
}
