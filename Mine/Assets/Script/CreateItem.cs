using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public void OnClickCreateItem(int _itemCode)
    {
        GameObject temp;
        for(int i = 0; i < InventoryManager.Instance.inventory.Count; i++)
        {
            if (InventoryManager.Instance.inventory[i].transform.childCount < 1)
            {
                temp = Instantiate(ItemManager.Instance.SearchObjByCode(_itemCode), InventoryManager.Instance.inventory[i].transform);
                temp.GetComponent<Item>().itemCount = 1;
                break;
            }
        }
    }
}
