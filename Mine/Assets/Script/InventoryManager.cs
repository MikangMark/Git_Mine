using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<GameObject> inventory;
    [SerializeField] 
    GameObject inventoryPos;

    public List<GameObject> invenItemList;

    [SerializeField]
    List<int> onInvenItemCode;
    private void Awake()
    {
        Init();
        onInvenItemCode = new List<int>();
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
        for(int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].transform.childCount > 0)
            {
                onInvenItemCode.Add(inventory[i].transform.GetChild(0).gameObject.GetComponent<Item>().itemCord);
            }
            else
            {
                onInvenItemCode.Add(-1);
            }
        }
        for (int i = 0; i < inventory.Count; i++)
        {
            invenItemList.Add(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<int> temp = new List<int>();
        temp.Clear();
        for(int i=0;i< onInvenItemCode.Count; i++)
        {
            temp.Add(onInvenItemCode[i]);
        }
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].transform.childCount > 0)
            {
                onInvenItemCode[i] = inventory[i].transform.GetChild(0).gameObject.GetComponent<Item>().itemCord;
            }
            else
            {
                onInvenItemCode[i] = -1;
            }
        }
        if (!CheckSameOnTableItemCode(temp))
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].transform.childCount > 0)
                {
                    invenItemList[i] = inventory[i].transform.GetChild(0).gameObject;
                }
                else
                {
                    invenItemList[i] = null;
                }
            }
        }

    }

    bool CheckSameOnTableItemCode(List<int> _list)
    {
        if(onInvenItemCode.Count != _list.Count)
        {
            return false;
        }
        for(int i = 0; i < onInvenItemCode.Count; i++)
        {
            if(onInvenItemCode[i] != _list[i])
            {
                return false;
            }
        }
        return true;
    }
}
