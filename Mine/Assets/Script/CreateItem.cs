using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public void OnClickCreateItem(int _itemCode)
    {
        
        for(int i = 0; i < InventoryManager.Instance.inventory.Count; i++)
        {
            if (InventoryManager.Instance.inventory[i].transform.childCount < 1)
            {
                Instantiate(ItemManager.Instance.SearchItemByCode(_itemCode), InventoryManager.Instance.inventory[i].transform);
                return;
            }
        }
    }
}
