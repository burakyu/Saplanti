using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(CoinManager.Instance.CoinCollectSound, transform.position);
            CoinManager.CoinCount++;
            Destroy(this.gameObject);
            EventManager.CoinCollected.Invoke();
        }
    }
}
