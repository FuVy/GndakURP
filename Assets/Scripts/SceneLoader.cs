using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float timeToWait = 0.5f;

    IEnumerator LoadNextSceneWithWaiting()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }
    IEnumerator LoadSceneWithWaiting(int index)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(index);
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextSceneWithWaiting());
    }
    public void LoadLevel(int index)
    {
        StartCoroutine(LoadSceneWithWaiting(index));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadSceneWithWaiting(0));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
