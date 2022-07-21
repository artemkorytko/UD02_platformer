using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldComponent : MonoBehaviour
{
    [SerializeField] GameObject Gold;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()) //������������ Compairtag // � ������ ������ ������ ������, ������������ ����������
        {
            Gold.SetActive(false);
        }
    }
}
