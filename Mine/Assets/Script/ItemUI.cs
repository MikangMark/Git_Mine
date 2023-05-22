using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public Table2by2 table2By2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for(int i=0;i< InventoryManager.Instance.invenItemList.Count; i++)
        //{
        //    if (InventoryManager.Instance.invenItemList[i] != null)
        //    {
        //        if (InventoryManager.Instance.invenItemList[i].GetComponent<Item>().itemCount > 1)
        //        {
        //            InventoryManager.Instance.invenItemList[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = InventoryManager.Instance.invenItemList[i].GetComponent<Item>().itemCount.ToString();

        //            Debug.Log(InventoryManager.Instance.invenItemList[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
        //        }
        //    }
        //}
        
        //for(int i = 0; i < table2By2.onTableItem.Count; i++)
        //{
        //    if(table2By2.onTableItem[i] != null)
        //    {
        //        if (table2By2.onTableItem[i].GetComponent<Item>().itemCount > 1)
        //        {
        //            table2By2.onTableItem[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = table2By2.onTableItem[i].GetComponent<Item>().itemCount.ToString();
        //        }
        //    }
        //}
    }
}
