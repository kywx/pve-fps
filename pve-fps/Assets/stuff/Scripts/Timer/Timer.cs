using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Timer: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    float remainingTtime = 301;
    float addedBossHealth = 0;
    void Update()
    {
        if (remainingTtime <= 0)
        {
            // Add portal to the boss level
            //Delete all enemies
            //Delete all pills
        }
        else{
        remainingTtime -= Time.deltaTime;
        }
        int minutes = Mathf.FloorToInt(remainingTtime / 60F);
        int seconds = Mathf.FloorToInt(remainingTtime % 60F);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void pill()
    {
        remainingTtime += 5;
        addedBossHealth += 10;//Adds to a boss health counter to be used in boss creation
    }
    
}
