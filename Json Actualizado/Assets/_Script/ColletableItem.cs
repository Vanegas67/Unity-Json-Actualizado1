using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableItem : MonoBehaviour
{
    [Header("Item Kiwi")]
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Soy el player y estoy en el trigger del Kiwi");
            GameManager.instance.CollectableItem(value);
            Destroy(gameObject);

            Debug.Log("El kiwi fue destruido");
        }
    }
}
