using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;
    public static int hp = 100;
    [SerializeField] GameObject blade1, blade2, blade3, blade4, blade5;
    public void Update()
    {
        if (hp >= 100)
        {
            blade1.SetActive(true);
            blade2.SetActive(true);
            blade3.SetActive(true);
            blade4.SetActive(true);
            blade5.SetActive(true);
        }
        if (hp <= 99 && hp >= 50)
        {
            blade1.SetActive(false);
            blade2.SetActive(true);
            blade3.SetActive(false);
            blade4.SetActive(false);
            blade5.SetActive(false);
        }
        if (hp < 50 && hp >= 20)
        {
            blade1.SetActive(false);
            blade2.SetActive(false);
            blade3.SetActive(true);
            blade4.SetActive(false);
            blade5.SetActive(false);
        }
        if (hp < 20 && hp >= 1)
        {
            blade1.SetActive(false);
            blade2.SetActive(false);
            blade3.SetActive(false);
            blade4.SetActive(true);
            blade5.SetActive(false);
        }

    }
    public void Hit(HitDamage place)
    {
        if (place == HitDamage.Left && !(place == HitDamage.Right && place == HitDamage.Full))
        {
            hp = hp - FruitKill.hitDamge;
            if (hp >= 100)
            {
                blade1.SetActive(true);
                blade2.SetActive(true);
                blade3.SetActive(true);
                blade4.SetActive(true);
                blade5.SetActive(true);
            }
           
            if (hp <= 99 && hp >= 50)
            {
                blade1.SetActive(false);
                blade2.SetActive(true);
                blade3.SetActive(false);
                blade4.SetActive(false);
                blade5.SetActive(false);
            }
            if (hp < 50&& hp>=20)
            {
                blade1.SetActive(false);
                blade2.SetActive(false);
                blade3.SetActive(true);
                blade4.SetActive(false);
                blade5.SetActive(false);
            }
            if (hp < 20 && hp>=1)
            {
                blade1.SetActive(false);
                blade2.SetActive(false);
                blade3.SetActive(false);
                blade4.SetActive(true);
                blade5.SetActive(false);
            }
            if (hp <= 0)
            {
                blade1.SetActive(false);
                blade2.SetActive(false);
                blade3.SetActive(false);
                blade4.SetActive(false);
                blade5.SetActive(true);
                
                OnPlayerDied();
                hp = 100;

            }
        }

        if (place == HitDamage.Right && !(place == HitDamage.Left && place == HitDamage.Full))
        {
            hp = hp - 10;
            if (hp == 100)
            {
                blade1.SetActive(true);
                blade2.SetActive(true);
                blade3.SetActive(true);
                blade4.SetActive(true);
                blade5.SetActive(true);
            }
            
            if (hp == 90 )
            {
                blade1.SetActive(false);
                blade2.SetActive(true);
                blade3.SetActive(false);
                blade4.SetActive(false);
                blade5.SetActive(false);
            }
            if (hp ==60)
            {
                blade1.SetActive(false);
                blade2.SetActive(false);
                blade3.SetActive(true);
                blade4.SetActive(false);
                blade5.SetActive(false);
            }
            if (hp == 30 )
            {
                blade1.SetActive(false);
                blade2.SetActive(false);
                blade3.SetActive(false);
                blade4.SetActive(true);
                blade5.SetActive(false);
            }
            if (hp <= 0)
            {
                blade1.SetActive(false);
                blade2.SetActive(false);
                blade3.SetActive(false);
                blade4.SetActive(false);
                blade5.SetActive(true);
                
                OnPlayerDied();
                hp = 100;

            }

        }
    }

    public enum HitDamage
    {
        Left, Right, Full
        //guillotineBlade1, guillotineBlade2, guillotineBlade3, guillotineBlade4, guillotineBlade5
    }
}
