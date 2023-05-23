using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Recipe : MonoBehaviour
{
    public List<Item> needItemList;
    public List<int> table_9;
    public List<int> table_4;
    public Item createdItem;

    // Start is called before the first frame update
    public Recipe()
    {
        needItemList = new List<Item>();
        table_9 = new List<int>();
        
        table_4 = new List<int>();
        for(int i = 0; i < 9; i++)
        {
            if (i < 4)
            {
                table_4.Add(-1);
            }
            table_9.Add(-1);
        }
        createdItem = null;
    }
    public void SetTable_4(int _index, int _itemCode)
    {
        table_4[_index] = _itemCode;
    }
    public void SetTable_9(int _index, int _itemCode)
    {
        table_9[_index] = _itemCode;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Recipe))
            return false;

        var other = (Recipe)obj;

        // matrix1 ºñ±³
        if (!CompareMatrix(table_9, other.table_9))
            return false;

        // matrix2 ºñ±³
        if (!CompareMatrix(table_4, other.table_4))
            return false;

        return true;
    }
    private bool CompareMatrix(List<int> matrixA, List<int> matrixB)
    {
        if (matrixA.Count != matrixB.Count)
            return false;

        for (int i = 0; i < matrixA.Count; i++)
        {
            if (matrixA[i] != matrixB[i])
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        int hash = 17;

        // matrix1 ÇØ½Ì
        hash = HashMatrix(table_9, hash);

        // matrix2 ÇØ½Ì
        hash = HashMatrix(table_4, hash);

        return hash;
    }

    private int HashMatrix(List<int> matrix, int hash)
    {
        foreach (var row in matrix)
        {
            hash = hash * 23 + matrix.GetHashCode();
        }

        return hash;
    }
}
