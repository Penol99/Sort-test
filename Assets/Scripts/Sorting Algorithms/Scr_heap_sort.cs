using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_heap_sort : Scr_node_manager
{

    [HideInInspector]
    private float m_sortTimer = .05f;

    private int m_heapSize;


    public IEnumerator HeapSortFloat(List<float> list)
    {
        BuildFloatHeap(list);
        for(int i = list.Count-1;i >= 0; i--)
        {
            SwapFloat(list, 0, i);
            m_heapSize--;
            HeapifyFloat(list, 0);
            yield return new WaitForSeconds(m_sortTimer);
        }

    }
    public IEnumerator HeapSortFloat(List<float> list, List<Node> objList)
    {
        BuildFloatHeap(list,objList);

        for (int i = list.Count - 1; i >= 0; i--)
        {

            SwapFloat(list,objList, 0, i);
            m_heapSize--;
            HeapifyFloat(list,objList, 0);
            yield return new WaitForSeconds(m_sortTimer);

        }

    }

    private void BuildFloatHeap(List<float> list)
    {
        m_heapSize = list.Count;
        for (int i = m_heapSize / 2; i >= 0;i--)
        {
            HeapifyFloat(list, i);
        }
    }
    private void BuildFloatHeap(List<float> list,  List<Node> objList)
    {
        m_heapSize = list.Count;
        for (int i = m_heapSize / 2; i >= 0; i--)
        {
            HeapifyFloat(list, objList, i);
        }
    }

    private void HeapifyFloat(List<float> list, int index)
    {
        int left = 2 * index;
        int right = 2 * index + 1;
        int largest = index;

        if (left < m_heapSize && list[left] > list[largest])
            largest = left;
        if (right < m_heapSize && list[right] > list[largest])
            largest = right;

        if (index != largest)
        {
            
            SwapFloat(list, largest, index);
            HeapifyFloat(list, largest);
        }
    }
    private void HeapifyFloat(List<float> list, List<Node> objList, int index)
    {

        int left = 2 * index;
        int right = 2 * index + 1;
        int largest = index;

        if (left < m_heapSize && list[left] > list[largest])
            largest = left;
        if (right < m_heapSize && list[right] > list[largest])
            largest = right;

        if (index != largest)
        {
            SwapFloat(list, objList, largest, index);
            HeapifyFloat(list, objList, largest);
        }
    }


    private void SwapFloat(List<float> list, int x, int y)
    {

        float temp = list[x];
        list[x] = list[y];
        list[y] = temp;
    }
    private void SwapFloat(List<float> list, List<Node> objList, int x, int y)
    {

        Transform nodeX = objList[x].m_nodeTransform;
        Transform nodeY = objList[y].m_nodeTransform;
        Vector3 tempPos = nodeX.position;
        nodeX.position = nodeY.position;
        nodeY.position = tempPos;
        

        float temp = list[x];
        list[x] = list[y];
        list[y] = temp;
        Node tempObj = objList[x];
        objList[x] = objList[y];
        objList[y] = tempObj;

    }
}
