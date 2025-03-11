using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float _baseDamage = 3;
    public float weaponDamage;

    private BossStatTracker statTracker;
    void Start()
    {
<<<<<<< HEAD
        PlayerInteract.ActivateAnim += AddDamage;
=======
        statTracker = GameObject.FindGameObjectWithTag("Stats").GetComponent<BossStatTracker>();
        weaponDamage = _baseDamage;
>>>>>>> 56c782e9193de2febf9ca3b99197b2218dd11fc6
    }

    // Update is called once per frame
    void Update()
    {
        weaponDamage = _baseDamage + statTracker._extraDamage;
    }
    void AddDamage()
    {
        weaponDamage += 10;
    }
}
