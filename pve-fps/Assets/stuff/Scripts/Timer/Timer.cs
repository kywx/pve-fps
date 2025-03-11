using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Timer: MonoBehaviour
{
    private BossStatTracker _bossStats;
    [SerializeField] private TextMeshProUGUI timerText;
    public float remainingTtime = 301;
    //float addedBossHealth = 0; pill method will access the BossStatTracker's bonus health count

    void Start()
    {
        PillCollection.addTime += pill;
        _bossStats = GameObject.FindWithTag("Stats").GetComponent<BossStatTracker>();
        _bossStats._extraHealth = 0;
    }
    void Update()
    {
        if (remainingTtime <= 0)
        {
            // Add portal to the boss level
            //Delete all enemies   // can use GameObject.FindGameObjectsWithTag("Enemy") then use a foreach to delete them all
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
        _bossStats.AddHealth(10f); //Adds to a boss health counter to be used in boss creation
    }
    
}
