using UnityEngine;
[RequireComponent(typeof(Rigidbody))] // Mesh Collider를 같이쓸때는 Convex 체크하기
public class MagicStone : MonoBehaviour ,IItem
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
        Debug.Log("Magic Stone");
    }
}
