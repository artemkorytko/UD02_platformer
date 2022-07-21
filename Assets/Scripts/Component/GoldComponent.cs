using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldComponent : MonoBehaviour
{
    [SerializeField] GameObject Gold;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()) //использовать Compairtag // а вообще нельзя юззать ничего, использовать компоненты
        {
            Gold.SetActive(false);
        }
    }
}
