using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ConbinationManager : Singleton<ConbinationManager>
{
    public Dictionary<List<int>, List<Recipe>> recipeList;//��� �������ڵ��, ������������ ������ִ� ��� ������
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
        Plank();
        Stick();
        FishingRod();
        CarrotFishingRod();
        WoodenPickaxe();
        WoodenShovel();
        keys = recipeList.Keys.ToList();
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
        original.Sort();
        _key.Sort();
        for(int i = 0; i < original.Count; i++)
        {
            if(original[i] != _key[i])
            {
                return false;
            }
        }
        return true;
    }
    #region ������(�Լ��̸��� �ش���������θ�����ִ� ������)
    void Plank()//��������(5)������ �ʿ��Ѿ����� ����(17)
    {
        List<Recipe> tempList = new List<Recipe>();
        List<Item> needItem = new List<Item>();
        List<int> needItemCode = new List<int>();
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(17)));
        needItemCode.Add(17);
        Item createdItem;
        createdItem = Instantiate(ItemManager.Instance.SearchItemByCode(5));
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
            temp.createdItem = createdItem;
            temp.createdItem.itemCount = 4;
            tempList.Add(temp);
        }
        recipeList.Add(needItemCode, tempList);
    }

    void Stick()
    {
        List<Recipe> tempList = new List<Recipe>();
        List<Item> needItem = new List<Item>();
        List<int> needItemCode = new List<int>();
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(5)));
        needItemCode.Add(5);
        needItemCode.Add(5);
        Item createdItem;
        createdItem = Instantiate(ItemManager.Instance.SearchItemByCode(280));
        
        for (int i = 0; i < 6; i++)
        {
            Recipe temp = new Recipe();
            temp.needItemList.Add(needItem[0]);
            if (i < 2)
            {
                temp.SetTable_4(i, needItem[0].itemCord);
                temp.SetTable_4(i + 2, needItem[0].itemCord);
            }
            temp.SetTable_9(i, needItem[0].itemCord);
            temp.SetTable_9(i + 3, needItem[0].itemCord);
            temp.createdItem = createdItem;
            temp.createdItem.itemCount = 4;
            tempList.Add(temp);
        }
        recipeList.Add(needItemCode, tempList);
    }
    void FishingRod()
    {
        List<Recipe> tempList = new List<Recipe>();
        List<Item> needItem = new List<Item>();
        List<int> needItemCode = new List<int>();
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(280)));
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(287)));
        needItemCode.Add(280);
        needItemCode.Add(280);
        needItemCode.Add(280);
        needItemCode.Add(287);
        needItemCode.Add(287);
        Item createdItem;
        createdItem = Instantiate(ItemManager.Instance.SearchItemByCode(346));
        Recipe temp = new Recipe();
        temp.needItemList.Add(needItem[0]);
        temp.needItemList.Add(needItem[1]);
        temp.SetTable_9(2, needItem[0].itemCord);
        temp.SetTable_9(4, needItem[0].itemCord);
        temp.SetTable_9(6, needItem[0].itemCord);
        temp.SetTable_9(5, needItem[1].itemCord);
        temp.SetTable_9(8, needItem[1].itemCord);
        temp.createdItem = createdItem;
        temp.createdItem.itemCount = 1;
        tempList.Add(temp);
        recipeList.Add(needItemCode, tempList);
    }
    void CarrotFishingRod()
    {
        List<Recipe> tempList = new List<Recipe>();
        List<Item> needItem = new List<Item>();
        List<int> needItemCode = new List<int>();
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(346)));
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(391)));
        needItemCode.Add(346);
        needItemCode.Add(391);
        Item createdItem;
        createdItem = Instantiate(ItemManager.Instance.SearchItemByCode(398));
        
        for(int i = 0; i < 5; i++)
        {
            if (i == 2)
            {
                continue;
            }
            Recipe temp = new Recipe();
            temp.needItemList.Add(needItem[0]);
            temp.needItemList.Add(needItem[1]);
            if (i == 0)
            {
                temp.SetTable_4(i, needItem[0].itemCord);
                temp.SetTable_4(i + 3, needItem[1].itemCord);
            }
            temp.SetTable_9(i, needItem[0].itemCord);
            temp.SetTable_9(i + 4, needItem[1].itemCord);
            temp.createdItem = createdItem;
            temp.createdItem.itemCount = 1;
            tempList.Add(temp);
            //04 15 37 48 0134 4578
        }
        recipeList.Add(needItemCode, tempList);
    }
    void WoodenPickaxe()
    {
        List<Recipe> tempList = new List<Recipe>();
        List<Item> needItem = new List<Item>();
        List<int> needItemCode = new List<int>();
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(5)));
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(280)));
        needItemCode.Add(5);
        needItemCode.Add(5);
        needItemCode.Add(5);
        needItemCode.Add(280);
        needItemCode.Add(280);
        Item createdItem;
        createdItem = Instantiate(ItemManager.Instance.SearchItemByCode(270));
        Recipe temp = new Recipe();
        temp.needItemList.Add(needItem[0]);
        temp.needItemList.Add(needItem[1]);
        temp.SetTable_9(0, needItem[0].itemCord);
        temp.SetTable_9(1, needItem[0].itemCord);
        temp.SetTable_9(2, needItem[0].itemCord);
        temp.SetTable_9(4, needItem[1].itemCord);
        temp.SetTable_9(7, needItem[1].itemCord);
        temp.createdItem = createdItem;
        temp.createdItem.itemCount = 1;
        tempList.Add(temp);
        recipeList.Add(needItemCode, tempList);
    }
    void WoodenShovel()
    {
        List<Recipe> tempList = new List<Recipe>();
        List<Item> needItem = new List<Item>();
        List<int> needItemCode = new List<int>();
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(5)));
        needItem.Add(Instantiate(ItemManager.Instance.SearchItemByCode(280)));
        needItemCode.Add(5);
        needItemCode.Add(280);
        needItemCode.Add(280);
        Item createdItem;
        createdItem = Instantiate(ItemManager.Instance.SearchItemByCode(269));
        Recipe temp = new Recipe();
        temp.needItemList.Add(needItem[0]);
        temp.needItemList.Add(needItem[1]);
        temp.SetTable_9(1, needItem[0].itemCord);
        temp.SetTable_9(4, needItem[1].itemCord);
        temp.SetTable_9(7, needItem[1].itemCord);
        temp.createdItem = createdItem;
        temp.createdItem.itemCount = 1;
        tempList.Add(temp);
        recipeList.Add(needItemCode, tempList);
    }
    
    #endregion
}
