using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2by2 : MonoBehaviour
{
    [SerializeField]
    List<GameObject> table_2by2;

    [SerializeField]
    List<GameObject> onTableItem;

    [SerializeField]
    List<int> onTableItemCode;

    [SerializeField]
    List<int> notNullItemCodeList;

    [SerializeField]
    GameObject createdItemPos;//이오브젝트하위에 아이템생성
    [SerializeField]
    GameObject createdItem;
    [SerializeField]
    Recipe activeRecipe;//현제 보여주고있는 레시피

    private void Start()
    {
        onTableItemCode = new List<int>();
        notNullItemCodeList = new List<int>();
        activeRecipe = new Recipe();
        for (int i = 0; i < 4; i++)
        {
            onTableItem.Add(null);
            onTableItemCode.Add(-1);
        }
        
    }
    void Update()
    {
        List<int> temp = new List<int>();
        for(int i = 0; i < onTableItemCode.Count; i++)
        {
            temp.Add(onTableItemCode[i]);
        }
        for (int i = 0; i < table_2by2.Count; i++)
        {
            if (table_2by2[i].transform.childCount > 0)
            {
                onTableItem[i] = table_2by2[i].transform.GetChild(0).gameObject;
                onTableItemCode[i] = table_2by2[i].transform.GetChild(0).gameObject.GetComponent<Item>().itemCord;
                
            }
            else
            {
                onTableItem[i] = null;
                onTableItemCode[i] = -1;
            }
        }
        if (!CheckSameOnTableItemCode(temp))
        {
            notNullItemCodeList.Clear();
            for (int i = 0; i < onTableItemCode.Count; i++)
            {
                if (onTableItemCode[i] != -1)
                {
                    notNullItemCodeList.Add(onTableItemCode[i]);
                }
            }
        }
        RecipeCheck();
    }
    bool CheckSameOnTableItemCode(List<int> _list)
    {
        for (int i = 0; i < onTableItemCode.Count; i++)
        {
            if (onTableItemCode[i] != _list[i])
            {
                return false;
            }
        }
        return true;
    }
    void RecipeCheck()
    {
        List<Recipe> temp = ConbinationManager.Instance.GetRecipeListValue(notNullItemCodeList);
        if (temp == null)
        {
            return;
        }
        for (int i=0;i< temp.Count; i++)
        {
            if (temp[i].table_4 == onTableItemCode)
            {
                activeRecipe = temp[i];
                break;
            }
            if (i == temp.Count - 1)
            {
                if (createdItemPos.transform.childCount > 0)
                {
                    Destroy(createdItem);
                }
                return;
            }
        }
        if (createdItemPos.transform.childCount < 1)
        {
            createdItem = Instantiate(ItemManager.Instance.SearchObjByCode(activeRecipe.createdItem.itemCord), createdItemPos.transform);
        }
        
    }
}
