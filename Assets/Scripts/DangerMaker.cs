using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerMaker : MonoBehaviour
{
    DangerousNode[] nodes;
    public float frequency = 10f;

    void Start()
    {
        nodes = FindObjectsOfType<DangerousNode>();
        
    }

    float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > frequency)
        {
            makeRandomNodeDangerous();
            timer = 0f;
        }

    }

    void makeRandomNodeDangerous()
    {
        nodes[Random.Range(0, nodes.Length - 1)].setDangerState();
    }
}
