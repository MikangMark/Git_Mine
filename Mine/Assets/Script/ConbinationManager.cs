using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ConbinationManager : Singleton<ConbinationManager>
{
    public Dictionary<List<int>, List<Recipe>> recipeList;//재료 아이템코드들, 재료아이템으로 만들수있는 모든 레시피
    public List<List<int>> keys;

    private void Awake()
    {
        Init();
        keys = new List<List<int>>();
        CreateRecipe();
    }
    // Start is called before the first frame update
    void CreateRecipe()
    {
        recipeList = new Dictionary<List<int>, List<Recipe>>();
    }
    void Start()
    {
        RawWood();
        keys = recipeList.Keys.ToList();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public List<Recipe> GetRecipeListValue(List<int> _key)
    {
        for(int i = 0; i < keys.Count; i++)
        {
            if(CheckSameRecipeListKey(keys[i], _key))
            {
                return recipeList[keys[i]];
            }
        }
        return null;
    }
    public bool CheckSameRecipeListKey(List<int> original, List<int> _key)
    {
        if(original.Count != _key.Count)
        {
            return false;
        }
        for(int i = 0; i < original.Count; i++)
        {
            if(original[i] != _key[i])
            {
                return false;
            }
        }
        return true;
    }
    #region 레시피(함수이름은 해당아이템으로만들수있는 레시피)
    void RawWood()//나무판자(5)레시피 필요한아이템 원목(17)
    {
        List<Recipe> tempList = new List<Recipe>();
        List<Item> needItem = new List<Item>();
        List<int> needItemCode = new List<int>();
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(17)));
        needItemCode.Add(17);
        Item createdItem = ItemManager.Instance.SearchItemByCode(5);
        for (int i = 0; i < 9; i++)
        {
            Recipe temp = new Recipe();
            needItem[0].itemCount = 1;
            temp.needItemList.Add(needItem[0]);
            if (i < 4)
            {
                temp.SetTable_4(i, needItem[0].itemCord);
            }
            temp.SetTable_9(i, needItem[0].itemCord);
            temp.createdItem = ItemManager.Instance.SearchItemByCode(createdItem.itemCord);
            temp.createdItem.itemCount = 4;
            tempList.Add(temp);
        }
        recipeList.Add(needItemCode, tempList);
    }
    #endregion
}
