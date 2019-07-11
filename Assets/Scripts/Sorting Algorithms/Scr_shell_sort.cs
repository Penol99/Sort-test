using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_shell_sort : Scr_node_manager
{
    private float m_sortTimer = 0.05f;

    public void ShellSort(List<float> list,List<Node> objList)
    {
        int j;
        int gap = 2;
        float temp;
        Node objTemp;
        Vector3 nodePosTemp;
        while (gap > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                j = i;
                temp = list[i];
                objTemp = objList[i];
                nodePosTemp = objTemp.m_nodeTransform.position;
                while ((j >= gap) && (list[j - gap] > temp))
                {
                    objList[j].m_nodeTransform.position = objList[j - gap].m_nodeTransform.position;
                    list[j] = list[j - gap];
                    objList[j] = objList[j - gap];
                    j = j - gap;
                }
                list[j] = temp;
                objList[j].m_nodeTransform.position = nodePosTemp;
                objList[j] = objTemp;
                
                //yield return new WaitForSeconds(m_sortTimer);
            }
            if (gap / 2 != 0)
                gap = gap / 2;
            else if (gap == 1)
                gap = 0;
            else
                gap = 1;
        }
    }
}
