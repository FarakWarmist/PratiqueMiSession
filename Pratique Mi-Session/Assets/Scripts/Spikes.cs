using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player playerCollide = collision.gameObject.GetComponent<Player>();
        playerCollide.TakeDomage();
    }
}
