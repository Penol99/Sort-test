using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_node_manager : MonoBehaviour
{
    [Header("Node Init")]
    public int m_nodeAmount;
    public Vector2 m_nodeScale = new Vector2(0.2f,1f);
    public Mesh m_nodeMesh;
    public Material m_nodeMaterial;

    private List<Node> m_nodes = new List<Node>();
    private List<float> m_nodesYScale = new List<float>();
    private Scr_heap_sort m_heap;
    private Scr_shell_sort m_shell;

    public struct Node
    {
        public Transform m_nodeTransform;

        private float m_posX;
        private Vector2 m_scale;    
        public float PosX { get => m_nodeTransform.position.x;}
        public Vector2 Scale { get => m_nodeTransform.localScale;}

        public Node(float posX, Vector2 scale, Transform node)
        {
            m_posX = posX;
            m_scale = scale;
            m_nodeTransform = node;

            m_nodeTransform.position = new Vector2(posX,0f);
            m_nodeTransform.localScale = new Vector3(scale.x,scale.y,1f);
        }
    }

    
    void Awake()
    {
        m_shell = GetComponent<Scr_shell_sort>();
        m_heap = GetComponent<Scr_heap_sort>();
        // Create Nodes and add to list
        for (int i = 0; i < m_nodeAmount; i++)
        {
            GameObject nodeObj = new GameObject();
            nodeObj.name = "Node: " + i;
            nodeObj.AddComponent<MeshFilter>().mesh = m_nodeMesh;
            nodeObj.AddComponent<MeshRenderer>().material = m_nodeMaterial;
            Node node = new Node(i * m_nodeScale.x, m_nodeScale, nodeObj.transform);
            m_nodes.Add(node);
            m_nodesYScale.Add(node.Scale.y);
        }
        ScrambleNodes();
    }

    public void ScrambleNodes()
    {
        for (int i = 0; i < m_nodes.Count; i++)
        {
            float yScale = Random.Range(1, m_nodeScale.y);
            m_nodes[i].m_nodeTransform.localScale = new Vector3(m_nodes[i].Scale.x, yScale, 1f);
            m_nodesYScale[i] = yScale;
        }
    }

    public void HeapSort()
    {
        StartCoroutine(m_heap.HeapSortFloat(m_nodesYScale,m_nodes));
    }

    public void ShellSort()
    {
        m_shell.ShellSort(m_nodesYScale,m_nodes);
    }

}
