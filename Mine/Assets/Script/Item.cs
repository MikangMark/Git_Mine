using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Item : MonoBehaviour
{
    public int itemCord;
    public string itemName;
    public int itemCount;

    public Item()
    {
        itemCord = 0;
        itemCount = 0;
        itemName = "";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemCord == 5 || itemCord == 17 || itemCord == 280 || itemCord == 287 || itemCord == 391)
        {
            if (itemCount > 1)
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = itemCount.ToString();
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        
    }
}
