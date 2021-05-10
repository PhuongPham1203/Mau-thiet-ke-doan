using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {

            CharacterController2D controller = CharacterController2D.getInstance();

            // * Luu tam
            
            controller.careTaker.LevelMarker = controller.CreateMarker(controller.currenthp, controller.money, controller.score, controller.transform.position);


        }
    }
}
