using System;
using UnityEngine;

public class DetectMiss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.ClearComboAndAddScore();
        }
    }
}
