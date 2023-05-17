using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public List<GameObject> itemList;
    public List<ItemInfo> itemInfoList;
    private void Awake()
    {
        Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        itemInfoList = new List<ItemInfo>();
        for(int i = 0; i < itemList.Count; i++)
        {
            itemInfoList.Add(itemList[i].GetComponent<Item>().itemInfo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
