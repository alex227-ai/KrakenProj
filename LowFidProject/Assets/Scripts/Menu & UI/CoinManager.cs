using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] bool pickObject;

    private void OnTriggerEnter(Collider other)
    {
        print("Player has collected coin");
        Destroy(this.gameObject);
    }

    public void SelectObject(bool collectBool)
    {
        pickObject = collectBool;
    }
}