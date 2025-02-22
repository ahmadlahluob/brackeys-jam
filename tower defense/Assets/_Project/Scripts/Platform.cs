using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool hasTurret = false;
    public GameObject[] turrets;
    public float turretPrice;
    public int level;
    public GameObject currentTurret;
    public void BuyTurret()
    {
        if (hasTurret)
            return;
        if (Economy.Instance.Money >= turretPrice)
        {
            if(currentTurret)
                currentTurret.SetActive(false);
            turrets[level].SetActive(true);
            currentTurret = turrets[level];
            level++;
            hasTurret = true;
        }
        
    }

    public void clicked()
    {
        if (hasTurret)
            return;
        BuyTurret();
    }


}
