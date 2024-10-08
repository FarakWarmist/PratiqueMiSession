using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindAnyObjectByType<CherriesCollected>().CollectFruit();

        Player player = collision.gameObject.GetComponent<Player>();
        player.CollectFruit();
        Destroy(gameObject);
    }
}
