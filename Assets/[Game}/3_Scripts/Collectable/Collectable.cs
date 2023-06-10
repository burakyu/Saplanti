using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("2");
            ScoreManager.Instance.Score++;
            Destroy(this.gameObject);
        }
    }
}
