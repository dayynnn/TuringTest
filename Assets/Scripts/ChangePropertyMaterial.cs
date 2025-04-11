using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePropertyMaterial : MonoBehaviour
{
    [SerializeField] private Renderer customRenderer;
    [SerializeField] private bool myOwnBool;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (myOwnBool == true) 
        {
            customRenderer.material.SetFloat("_UseSecondColor", 1f);
        }
        else
        {
            customRenderer.material.SetFloat("_UseSecondColor", 0);
        }
    }
}
