using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float countDown;
    public float maxDuration = 40.0f;
    public static bool isGameOver = false;

    public float hungerUpdateTime = 0f;
    float currentHungerTime;
    public int maxhunger = 100;
    public int hunger;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI hungerText;
    public Image sr;
    public Sprite s1_sprite;
    public Sprite s2_sprite;
    public Sprite s3_sprite;
    // Start is called before the first frame update
    void Start()
    {
        hunger = maxhunger;
        isGameOver = false;
        countDown = maxDuration;
        currentHungerTime = 0;
        SetTimeText();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
                SetTimeText();
                currentHungerTime += Time.deltaTime;

                if (currentHungerTime > hungerUpdateTime)
                {
                    hunger -= 5;
                    currentHungerTime = 0;
                }
                hungerText.text = hunger.ToString("0");

            } else
            {
                LevelLost();
            }
        }

        if(hunger > maxhunger * 2 / 3)
        {
            sr.sprite = s1_sprite;
        }
        else if( hunger > maxhunger / 3)
        {
            sr.sprite = s2_sprite;
        }
        else
        {
            sr.sprite = s3_sprite;
        }
    }

    void SetTimeText()
    {
        timerText.text = countDown.ToString("0.00");
    }

    void SetHungerText()
    {
        hungerText.text = hunger.ToString("0");
    }

    void LevelLost()
    {
        isGameOver = true;

    }
}
