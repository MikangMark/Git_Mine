using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryPnl;
    [SerializeField]
    GameObject creatTabelPnl;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPnl.SetActive(true);
        creatTabelPnl.SetActive(false);
    }
    public void OnClickChangeBtn()
    {
        if (inventoryPnl.activeSelf)
        {
            inventoryPnl.SetActive(false);
        }
        else
        {
            inventoryPnl.SetActive(true);
        }
        if (creatTabelPnl.activeSelf)
        {
            creatTabelPnl.SetActive(false);
        }
        else
        {
            creatTabelPnl.SetActive(true);
        }
    }
}
