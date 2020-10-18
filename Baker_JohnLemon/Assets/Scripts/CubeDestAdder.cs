using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestAdder : MonoBehaviour
{
    Vector2 PlatformXZ;

    private void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GamePiece")
        {
            Vector2 GamePieceXZ = new Vector2(other.transform.position.x, other.transform.position.y); 
       
        }
    }
}
