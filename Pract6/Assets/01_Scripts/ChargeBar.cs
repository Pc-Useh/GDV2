using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChargeBar : MonoBehaviour
{
    public Image lifBar;
    float maxHP = 300;
    float hp = 0;
    
    
    void Start()
    {
        lifBar.fillAmount = hp / maxHP;
    }
    
    void Update()
    {
        //hp = hp + 0.01f;
        //lifBar.fillAmount = hp;
    }
}
