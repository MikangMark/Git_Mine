using System;
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

        table_4[row][col] = _itemCode;
    }
    public void SetTable_9(int _index, int _itemCode)
    {
        int row = _index / 3;
        int col = _index % 3;
        table_9[row][col] = _itemCode;
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

    private bool CompareMatrix(List<List<int>> matrixA, List<List<int>> matrixB)
    {
        if (matrixA.Count != matrixB.Count)
            return false;

        for (int i = 0; i < matrixA.Count; i++)
        {
            if (matrixA[i].Count != matrixB[i].Count)
                return false;

            for (int j = 0; j < matrixA[i].Count; j++)
            {
                if (matrixA[i][j] != matrixB[i][j])
                    return false;
            }
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

    private int HashMatrix(List<List<int>> matrix, int hash)
    {
        foreach (var row in matrix)
        {
            foreach (var element in row)
            {
                hash = hash * 23 + element.GetHashCode();
            }
        }

        return hash;
    }
}
