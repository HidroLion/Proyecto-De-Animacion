using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class Decisions : MonoBehaviour
{
    [SerializeField] public int numberA, numberB, numberC;
    // Start is called before the first frame update
    public void PlayGameA()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + numberA);
    }
    public void PlayGameB()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + numberB);
    }
    public void PlayGameC()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + numberC);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Play(string gameScene)
    {
        SceneManager.LoadScene(gameScene);
    }
  
}
