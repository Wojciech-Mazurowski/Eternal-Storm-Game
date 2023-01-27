using UnityEngine;
using TMPro;

public static class scoreManager
{
    public static TextMeshProUGUI scoreText;
    private static int score=0;
    private static float startTime;
    private static bool timerStarted = false;
    

    static scoreManager()
    {
        var scoreObject = GameObject.FindGameObjectsWithTag("scoreText")[0];
        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        timerStarted = true;
    }
        
    public static void StartTimer()
    {
        if (!timerStarted)
        {
            startTime = Time.time;
            timerStarted = true;
        }
    }
    public static void Update()
    {
        if (timerStarted)
        {
            var score_display = score / (Time.time - startTime);
            scoreText.text = score_display.ToString();
        }
    }



    public static void Increment(float amount)
    {
        score += (int) amount;
    }

    public static float GetScorePerSecond(int score)
    {
        if (timerStarted)
        {
            return (int)(score / (Time.time - startTime));
        }
        return 0;
    }
}