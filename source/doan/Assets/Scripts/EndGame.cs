using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {

            //CharacterController2D controller = CharacterController2D.getInstance();

            // * Luu tam
            
            //controller.careTaker.LevelMarker = controller.CreateMarker(controller.currenthp, controller.money, controller.score, controller.transform.position);

            Debug.Log("Done game Level 1. Go to level 2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
