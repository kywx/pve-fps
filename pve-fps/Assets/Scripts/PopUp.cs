using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
   
    
   

    [SerializeField] TextMeshProUGUI _DamagePopUp;
    [SerializeField] TextMeshProUGUI _popTime;
    float _timerTime = 4;

    float _timerDamage = 4;
    bool isOn = false;
    bool isOnTime = false;
    void Start()
    {
        PlayerInteract.ActivateAnim += PopUpDamage;
        PillCollection.addTime += PopUpTime;

    }

    // Update is called once per frame
    void Update()
    {

        if (isOn)
        {
            _timerDamage -= Time.deltaTime;
            if (_timerDamage <= 0)
            {
                _DamagePopUp.enabled = false;
                isOn = false;
                _timerDamage = 4;
            }

        }
        if (isOnTime)
        {
            _timerTime -= Time.deltaTime;
            if (_timerTime <= 0)
            {
                _popTime.enabled = false;
                isOnTime = false;
                _timerTime = 4;
            }

        }
    }
    void PopUpDamage()
    {
        _DamagePopUp.enabled = true;
        isOn = true;
        Debug.Log("che");
    }
    void PopUpTime()
    {
        _popTime.enabled = true;
        isOnTime = true;
        Instantiate(_popTime, _popTime.transform.position, Quaternion.identity);
    }


}
