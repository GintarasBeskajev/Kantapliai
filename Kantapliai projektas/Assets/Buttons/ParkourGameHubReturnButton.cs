using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParkourGameHubReturnButton : MonoBehaviour
{
    public void ButtonNewScene()
    {
        SceneManager.LoadScene("Hub");
    }
}
