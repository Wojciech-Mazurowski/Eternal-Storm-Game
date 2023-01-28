using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class scroller : MonoBehaviour
{
    public GameObject enemy;
    public TextMeshProUGUI stageNumberUIText;
    public GameObject stageAnnouncerUI;
    public int maxStages;
    public float scrollSpeed = 0.5f;
    public float scrollTime = 10f;
    private float x;
    private float startPosition;
    private float endPosition;
    private SpriteRenderer sr;
    private float scrollTo;
    private int lastSeenStage = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        NewLevel();
   
    }

    void NewLevel()
    { 
        startPosition = transform.position.x;
        endPosition = sr.bounds.size.x - startPosition;
        maxStages = enemy.GetComponent<EnemyHealth>().stages;
        SetStage(maxStages, maxStages);
        x = 0;
    }

    void SetStage(int stage, int maxStages)
    {
        lastSeenStage = stage;
        var newStage = (maxStages - stage);
        var currentScene = SceneManager.GetActiveScene().name;
        var sceneNumber = int.Parse(currentScene);
        scrollTo = startPosition/2+(endPosition / maxStages) * newStage;

        string[] madrosci = new string[]{
            "Wiele żółwi żyło na tej ziemi",
            "Nie ma sceny zero ale jest bo tak",
            "Wielcy mędrcy są wielicy",
        };

        stageNumberUIText.text = $"Chapter {sceneNumber} - {madrosci[sceneNumber-1]}\nStage {newStage + 1}";
        StartCoroutine(showStageAnnouncerFor(2.5f));
    }


    IEnumerator showStageAnnouncerFor(float timeBeforeHidden) //time in seconds
    {
        stageAnnouncerUI.SetActive(true);
        yield return new WaitForSeconds(timeBeforeHidden);
        stageAnnouncerUI.SetActive(false);
        yield return null;
    }

    void Update()
    {
        // x = Mathf.Repeat(Time.time * scrollSpeed, endPosition - startPosition); FOR LOOPING
        var enemyHP = enemy.GetComponent<EnemyHealth>();
        if (lastSeenStage > enemyHP.stages){ SetStage(enemyHP.stages, maxStages);}

        if (x >= scrollTo) { return;}
        x += scrollSpeed * Time.deltaTime;
        transform.position = new Vector2(startPosition - x, transform.position.y);
    }

}
