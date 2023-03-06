using Platformer.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public static readonly float ENEMY_DEFAULT_SPEED = 7;
    public static readonly int TOKEN_DEFAULT_POINT = 10;
    public static int SCENE { get; set; } = 0;

    public static int DEATH_COUNT { get; set; } = 0;

    public static float ENEMY_SPEED { get; set; } = 7;

    public int TokenEarn { get; set; } = 0;

    public int RoundPoint { get; set; }

    private static RoundManager instance;
    public static RoundManager Instance
    {
        get
        {
            return instance;
        }
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        instance = this;
        if (SCENE == 0)
        {
            RoundPoint = 790;
        }
        else RoundPoint = 900;

        ChangeGameDiff();
    }
    void Update()
    {
    }
    public void ChangeGameDiff()
    {
        if (DEATH_COUNT > 0)
        {
            if (RoundPoint != 1440)
            {
                var point = RoundPoint + (RoundPoint * DEATH_COUNT / 5);
                if (point <= 1440)
                {
                    RoundPoint = point;
                }
                else RoundPoint = 1440;
            }
            else
            {
                if (ENEMY_SPEED <= 30) ENEMY_SPEED += 2;
            }

        }
    }

    private void ResetStatus()
    {
        ENEMY_SPEED = 7;
        DEATH_COUNT = 0;
    }

    public void NextScene()
    {
        ResetStatus();
        if (SCENE == 1)
        {
            SCENE = 0;
        } else SCENE += 1;
        SceneManager.LoadScene(SCENE);
    }

    public void LoadCurrent() {
        SceneManager.LoadScene(SCENE);
    }
}
