using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public List<List<int>> table_9;
    public List<List<int>> table_4;

    // Start is called before the first frame update
    void Start()
    {
        table_9 = new List<List<int>>();
        for(int i = 0; i < 3; i++)
        {
            table_9[i] = new List<int>();
            for(int j = 0; j < 3; j++)
            {
                table_9[i].Add(-1);
            }
        }
        table_4 = new List<List<int>>();
        for (int i = 0; i < 2; i++)
        {
            table_4[i] = new List<int>();
            for (int j = 0; j < 2; j++)
            {
                table_4[i].Add(-1);
            }
        }
    }
    public void SetTable_4(int _index, int _itemCode)
    {
        int row = _index / 2;
        int col = _index % 2;
    }
    public void SetTable_9(int _index, int _itemCode)
    {
        int row = _index / 3;
        int col = _index % 3;


    }
}
