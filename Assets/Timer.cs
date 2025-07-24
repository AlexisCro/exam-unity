using UnityEngine;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    private int Seconds;
    public TextMeshProUGUI Time;
    public GameObject GameOverScreen;
    public GameObject VictoryScreen;
    public GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Seconds = 45;
        StartCoroutine(RemainsTime());
    }

    // Update is called once per frame
    void Update()
    {
        Time.text = "Times : " + Seconds + " seconds";
        if (Seconds == 0)
        {
            GameOverScreen.SetActive(true);
            Player.SetActive(false);
        }
    }

    private IEnumerator RemainsTime()
    {
        while(Seconds > 0 && !VictoryScreen.activeSelf)
        {
            Seconds -= 1;
            yield return new WaitForSeconds(1f);
        }
    }
}
