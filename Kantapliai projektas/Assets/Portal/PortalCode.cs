using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalCode : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Portal 1")
        {
            SceneManager.LoadScene("ParkourGameStart");
        }
        else if (collision.gameObject.name == "Portal 2")
        {
            SceneManager.LoadScene("WaveSurvivalGame");
        }
        else if (collision.gameObject.name == "Portal 3")
        {
            SceneManager.LoadScene("DodgeGame");
        }
    }
}
