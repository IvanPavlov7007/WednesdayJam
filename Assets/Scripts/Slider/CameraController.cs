using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform contrainer;
    private void Awake()
    {
        contrainer = transform.parent;
    }
    void Start()
    {
        contrainer.parent = PlayerContinuousInput.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
