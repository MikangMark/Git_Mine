using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewYourScript", menuName = "Custom/YourScript")]
public class YourScript : ScriptableObject
{
    public struct DoubleList
    {
        public List<List<int>> doubleList1;
        public List<List<int>> doubleList2;
    }
    public DoubleList list;
    public Dictionary<DoubleList, Item> create;
    YourScript()
    {
        list.doubleList1 = new List<List<int>>();
        for(int i = 0; i < 2; i++)
        {
            list.doubleList1.Add(new List<int>());
            for(int j = 0; j < 2; j++)
            {
                list.doubleList1[i].Add(-1);
            }
        }
        list.doubleList2 = new List<List<int>>();
        for (int i = 0; i < 3; i++)
        {
            list.doubleList2.Add(new List<int>());
            for (int j = 0; j < 3; j++)
            {
                list.doubleList2[i].Add(-1);
            }
        }
    }
}

[CustomEditor(typeof(YourScript))]
public class ScriptTable : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        YourScript script = (YourScript)target;

        EditorGUILayout.LabelField("4 By 4");
        DisplayDoubleList(script.list.doubleList1);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("9 By 9");
        DisplayDoubleList(script.list.doubleList2);

        serializedObject.ApplyModifiedProperties();
    }

    private void DisplayDoubleList(List<List<int>> doubleList)
    {

        for (int i = 0; i < doubleList.Count; i++)
        {
            EditorGUILayout.LabelField("row: " + i);
            EditorGUI.indentLevel++;

            List<int> innerList = doubleList[i];
            for (int j = 0; j < innerList.Count; j++)
            {
                innerList[j] = EditorGUILayout.IntField("col: " + j, innerList[j]);
            }

            EditorGUI.indentLevel--;
        }
    }
}