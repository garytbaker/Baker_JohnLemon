using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestAdder : MonoBehaviour
{
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GamePiece")
        {
            
        }
    }
}
