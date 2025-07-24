using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class UIController : MonoBehaviour
{
    private int displayTimer = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("UIScreenEnding").activeSelf)
        {
            StartCoroutine(Couter());
        }

        if (displayTimer == 0)
        {
            SceneManager.LoadScene("UI");
        }
    }

    public void ChangeSceneToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void ChangeSceneToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("UI");
    }

    private IEnumerator Couter()
    {
        while (displayTimer < 0)
        {
            displayTimer -= 1;
            yield return new WaitForSeconds(1f);
        }
    }
}
