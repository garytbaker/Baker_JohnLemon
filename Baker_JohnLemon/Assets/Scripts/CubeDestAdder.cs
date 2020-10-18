using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestAdder : MonoBehaviour
{
    public GlobalVariables levelcontrol;

    private void OnTriggerEnter(Collider other)  //when something triggers the level pad
    {
        if (other.tag == "GamePiece")  //if it is a game piece
        {
           
           /* Vector2 GamePieceXZ = new Vector2(other.transform.position.x, other.transform.position.y);    This was a first attempt but the solution did not work. 
            float distanceBetween = Vector2.Distance(PlatformXZ, GamePieceXZ);
            if (distanceBetween<2.0f)
            {
                levelcontrol.addPlatform();
            }*/
            if (other.gameObject.GetComponent<Triggering>().trigger == false)  //if it is not triggereing another game pad
            {
                other.gameObject.GetComponent<Triggering>().trigger = true; //it now is
                levelcontrol.addPlatform();//add one to the total count to see if we should go to the next level
            }
       
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GamePiece")  //if it is a game piece
        {
            if (other.gameObject.GetComponent<Triggering>().trigger == true)  //if it is triggereing a game pad
            {
                other.gameObject.GetComponent<Triggering>().trigger = false; //it not now
                levelcontrol.deletePlatform();//delete one to the total count to see if we should go to the next level
            }

        }
}
