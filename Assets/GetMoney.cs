using UnityEngine;
using TMPro;

public class GetMoney : MonoBehaviour
{
    private int Score;
    public TextMeshProUGUI ScoreText;
    private int MaxScore = 7;
    public GameObject VictoryScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
        ScoreText.text = "Score : " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + Score;

        if (Score == MaxScore)
        {
            VictoryScreen.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Money"))
        {
            Destroy(collider.gameObject);
            Score += 1;
        }
    }
}
