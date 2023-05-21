using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<GameObject> inventory;
    [SerializeField] 
    GameObject inventoryPos;

    public List<GameObject> invenItemList;
    private void Awake()
    {
        Init();
        invenItemList = new List<GameObject>();
        inventory = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < inventoryPos.transform.childCount; i++)
        {
            inventory.Add(inventoryPos.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].transform.childCount > 0)
            {
                invenItemList.Add(inventory[i].transform.GetChild(0).gameObject);
            }
        }
    }

    bool CheckSameOnTableItemCode(List<int> _list)
    {
        a
    }
}
