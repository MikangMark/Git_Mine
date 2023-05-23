using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public List<GameObject> itemList;
    public List<Item> itemInfoList;

    public Dictionary<string, GameObject> itemDic;
    private void Awake()
    {
        Init();
        itemDic = new Dictionary<string, GameObject>();
        GameObject[] itemPfabs = Resources.LoadAll<GameObject>("Prefabs");
        itemList = new List<GameObject>();
        itemInfoList = new List<Item>();
        for (int i = 0; i < itemPfabs.Length; i++)
        {
            itemList.Add(itemPfabs[i]);
        }
        for (int i = 0; i < itemList.Count; i++)
        {
            itemInfoList.Add(itemList[i].GetComponent<Item>());
        }
        for(int i = 0; i < itemList.Count; i++)
        {
            itemDic.Add(itemList[i].name, itemList[i]);
        }
    }
    public Item SearchItemByCode(int _itemCode)
    {
        for(int i = 0; i < itemInfoList.Count; i++)
        {
            if(itemInfoList[i].itemCord == _itemCode)
            {
                return itemInfoList[i];
            }
        }
        Debug.Log("해당 코드는 없는 아이템입니다");
        return null;
    }
    public GameObject SearchObjByCode(int _itemCode)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].GetComponent<Item>().itemCord == _itemCode)
            {
                return itemList[i];
            }
        }
        Debug.Log("해당 코드는 없는 아이템입니다");
        return null;
    }
}
