using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //both materials
    [SerializeField] private Material baseMaterial, offsetMaterial;
    //The rendere inside the object
    [SerializeField] private MeshRenderer renderer;


    void Start()
    {
        
        baseMaterial = GetComponent<Renderer>().material;
        offsetMaterial = GetComponent<Renderer>().material;
    }

    public void Init(bool isOffset)
    {
        //if isoffset is true chose the offsetmaterial other than that put the base 
        // ? and : migth seem unfamiliar aswell, look up for better understanding
        renderer.material = isOffset ? offsetMaterial : baseMaterial;
    }
}
