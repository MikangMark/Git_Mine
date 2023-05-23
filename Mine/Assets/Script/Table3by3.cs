using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table3by3 : MonoBehaviour
{
    [SerializeField]
    List<GameObject> table_3by3;

    public List<GameObject> onTableItem;

    [SerializeField]
    List<int> onTableItemCode;

    [SerializeField]
    List<int> notNullItemCodeList;

    [SerializeField]
    GameObject createdItemPos;//이오브젝트하위에 아이템생성
    [SerializeField]
    GameObject createdItem;
    Recipe activeRecipe;//현제 보여주고있는 레시피

    bool changeRecipe;

    private void Start()
    {
        changeRecipe = false;
        onTableItemCode = new List<int>();
        notNullItemCodeList = new List<int>();
        activeRecipe = new Recipe();
        for (int i = 0; i < 9; i++)
        {
            onTableItem.Add(null);
            onTableItemCode.Add(-1);
        }

    }
    void Update()
    {
        List<int> temp = new List<int>();
        for (int i = 0; i < onTableItemCode.Count; i++)
        {
            temp.Add(onTableItemCode[i]);
        }
        for (int i = 0; i < table_3by3.Count; i++)
        {
            if (table_3by3[i].transform.childCount > 0)
            {
                onTableItem[i] = table_3by3[i].transform.GetChild(0).gameObject;
                onTableItemCode[i] = table_3by3[i].transform.GetChild(0).gameObject.GetComponent<Item>().itemCord;

            }
            else
            {
                onTableItem[i] = null;
                onTableItemCode[i] = -1;
            }
        }
        if (!CheckSameOnTableItemCode(temp))//제작테이블이 변경되었을때실행
        {
            notNullItemCodeList.Clear();
            for (int i = 0; i < onTableItemCode.Count; i++)
            {
                if (onTableItemCode[i] != -1)
                {
                    notNullItemCodeList.Add(onTableItemCode[i]);
                }
            }
            Debug.Log("1");
            RecipeCheck();
        }
    }
    void RecipeCheck()
    {
        List<Recipe> temp = new List<Recipe>();
        temp = ConbinationManager.Instance.GetRecipeListValue(notNullItemCodeList);
        if (temp == null)
        {
            if (createdItemPos.transform.childCount > 0)
            {
                Destroy(createdItem);
            }
            return;
        }

        for (int i = 0; i < temp.Count; i++)//한아이템의 레시피 리스트
        {
            if (CheckSameListInt(temp[i].table_9, onTableItemCode))
            {
                activeRecipe = temp[i];

                if (createdItemPos.transform.childCount < 1)
                {
                    createdItem = Instantiate(ItemManager.Instance.SearchObjByCode(activeRecipe.createdItem.itemCord), createdItemPos.transform);
                }
                break;
            }
        }

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


    bool CheckSameListInt(List<int> a, List<int> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }
}
