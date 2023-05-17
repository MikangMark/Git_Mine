using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2by2 : MonoBehaviour
{
    [SerializeField]
    List<GameObject> table_2by2;

    [SerializeField]
    List<GameObject> onTableItem;
    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            onTableItem.Add(null);
        }
    }
    void Update()
    {
        for(int i = 0; i < table_2by2.Count; i++)
        {
            if (table_2by2[i].transform.childCount > 0)
            {
                onTableItem[i] = table_2by2[i].transform.GetChild(0).gameObject;
            }
            else
            {
                onTableItem[i] = null;
            }
        }
    }
}
