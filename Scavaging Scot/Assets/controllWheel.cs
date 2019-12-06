using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllWheel : MonoBehaviour
{

    public GameObject[] chains = new GameObject[2];
    void Start()
    {
        
    }

    
    void Update()
    {
        foreach (GameObject chain in chains)
        {
            chain.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -(Time.time * 0.5f));
        }
    }

}
