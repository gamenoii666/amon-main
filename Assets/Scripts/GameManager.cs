using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public GameStartMenu gameStartMenu;
    public GameObject UIGameObject;
    private Snap[] SnapsScripts;
    public LeaderboardManager Leaderboard;
    int numberSnapTotal;
    int numberSnapCurrent;
    float currentTime;
    public bool timerStarted = false;
    public AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        SnapsScripts = GameObject.FindObjectsOfType<Snap>();
        numberSnapTotal = SnapsScripts.Length;
        UIGameObject.SetActive(false);
        timerStarted = true;





    }
    // Update is called once per frame
    void Update()
    {

        snapCheck();
        if (numberSnapCurrent == numberSnapTotal)
        {
            timerStarted = true;
            timer.StopTimer();
            endGame();

        }
        if (timerStarted)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                timerStarted = false;
                currentTime = 0;
            }
        }






    }

    public void snapCheck()
    {
        numberSnapCurrent = 0;
        foreach (Snap snap in SnapsScripts)
        {
            if (snap.isSnap)
            {
                numberSnapCurrent++;

            }

        }
        Leaderboard.UpdateScore(numberSnapCurrent);
    }
    void endGame()
    {
        if (audioSource != false)
        {
            Debug.Log("Playing sound");
            audioSource.PlayOneShot(clip);


        }
        UIGameObject.SetActive(true);
        timerStarted = false;
    }
}
