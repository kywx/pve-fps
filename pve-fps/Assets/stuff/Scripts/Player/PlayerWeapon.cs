using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float _baseDamage = 3;
    public float weaponDamage;

    private BossStatTracker statTracker;
    void Start()
    {
        statTracker = GameObject.FindGameObjectWithTag("Stats").GetComponent<BossStatTracker>();
        weaponDamage = _baseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        weaponDamage = _baseDamage + statTracker._extraDamage;
    }
}
