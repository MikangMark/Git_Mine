using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public List<List<int>> table;

    // Start is called before the first frame update
    void Start()
    {
        table = new List<List<int>>();
        for(int i = 0; i < 3; i++)
        {
            table[i] = new List<int>();
            for(int j = 0; j < 3; j++)
            {
                table[i].Add(-1);
            }
        }
    }
    public void SetTable(int _index, int _itemCode)
    {

    }
}
