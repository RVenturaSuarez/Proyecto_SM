using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl2Controller : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text puntuation;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [SerializeField] private int maxPoints;
    [SerializeField] private float time;
    private int userPoints = 0;

    private void Start()
    {
        puntuation.text = "Points: " + userPoints.ToString() + " / " + maxPoints.ToString();
    }

    private void Update()
    {
        if (time <= 0.0f)
        {
          if(userPoints < maxPoints)
          {
                YouLose();
          }
        }
        else
        {
            time -= Time.deltaTime;
            timerText.text = "" + ((int)time);
            Debug.Log((int)time);
        }

        if(userPoints >= maxPoints)
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
    }
    public void GetPoints()
    {
        userPoints++;
        puntuation.text = "Points: " + userPoints.ToString() + " / " + maxPoints.ToString();
    }

    public void YouLose()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

   
}
