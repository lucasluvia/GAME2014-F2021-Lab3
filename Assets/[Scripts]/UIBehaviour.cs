using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    private int NextSceneIndex;
    private int PreviousSceneIndex;

    void Start()
    {
        NextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    // NextButton Pressed event handler
    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(NextSceneIndex);
    }

    // BackButton Pressed event handler
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(PreviousSceneIndex);
    }
}
