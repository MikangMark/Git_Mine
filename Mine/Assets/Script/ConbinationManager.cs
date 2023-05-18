using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConbinationManager : Singleton<ConbinationManager>
{
    public Dictionary<Recipe, int> recipeList;//key ���չ� value ��������� �������ڵ�
    public List<Recipe> key_Recipe;
    public List<int> value_ItemCode;
    private void Awake()
    {
        Init();
        CreateRecipe();
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < key_Recipe.Count; i++)
        {
            for(int j = 0; j < key_Recipe.Count; j++)
            {
                if (i != j && key_Recipe[i] == key_Recipe[j])
                {
                    if (i > j)
                    {
                        key_Recipe[i] = null;
                        Debug.LogError("�ߺ��� key_Recipe���� �����մϴ�");
                    }
                    else
                    {
                        key_Recipe[j] = null;
                        Debug.LogError("�ߺ��� key_Recipe���� �����մϴ�");
                    }
                }
            }
        }
        recipeList = new Dictionary<Recipe, int>();
        for (int i = 0; i < key_Recipe.Count; i++)
        {
            if (key_Recipe[i] != null)
            {
                recipeList.Add(key_Recipe[i], value_ItemCode[i]);
            }
        }
    }
    void CreateRecipe()
    {
        key_Recipe = new List<Recipe>();
        value_ItemCode = new List<int>();

        List<Recipe> plankeRecipe = new List<Recipe>();
        int createdCode = 5;
        for (int i = 0; i < 4; i++)
        {
            Recipe temp = new Recipe();
            int ingredientCode = 17;// ����ڵ�
            temp.SetTable_4(i, ingredientCode);
            plankeRecipe.Add(temp);


        }
        key_Recipe = plankeRecipe;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
