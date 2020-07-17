using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject BG;
    public GameObject LCText;
    public GameObject LNLText;
    public GameObject Congrats;
    public GameObject playAgain;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }
    public void Win()
    {
        StartCoroutine(WinningScreen());
    }
    public void WinGame()
    {
        StartCoroutine(WinGameScreen());
    }
    IEnumerator WinGameScreen()
    {
        yield return new WaitForSeconds(1.5f);
        Congrats.SetActive(true);
        playAgain.SetActive(true);
        
    }
    IEnumerator WinningScreen()
    {
        BG.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LCText.SetActive(true);
        yield return new WaitForSeconds(1f);
        LNLText.SetActive(true);
       
    }
    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadFirstScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex * 0);
    }
}
