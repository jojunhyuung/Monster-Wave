using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Potion : MonoBehaviour , IItem
{
    private ItemManager itemManager;

    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
    }

    private void OnMouseDown()
    {
        itemManager.GetItem(this.gameObject);
        this.gameObject.SetActive(false);
    }
    public void Use()
    {
        Debug.Log("Potion used");
    }

}
