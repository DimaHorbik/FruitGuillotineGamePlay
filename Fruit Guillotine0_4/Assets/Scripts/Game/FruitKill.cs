using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FruitKill : MonoBehaviour
{
    public static event Action<int> OnScoreApple;
    public static event Action<int> OnScoreAubergine;
    public static event Action<int> OnScoreBanana;
    public static event Action<int> OnScoreCoconut;
    public static event Action<int> OnScoreMango;
    public static event Action<int> OnScoreMelon;
    public static event Action<int> OnScoreOrange;
    public static event Action<int> OnScorePineapple;
    public static event Action<int> OnScoreTomato;
    public static event Action<int> OnScoreWatermelon;
    public static event Action<int> OnScoreWatermelonDamage;
    public static event Action<int> OnScoreDamage;
    bool scored;
    public static int hitDamge;
    public void OnTriggerEnter2D (Collider2D _collision)
    {
        if (_collision.tag == "Left_Fruit" && !(_collision.tag == "Full_Fruit"))
        {
            scored = false;
            _collision.GetComponentInParent<Apple>().Hit(Apple.HitPlace.Left);
            GetComponentInParent<Damage>().Hit(Damage.HitDamage.Left);
        }
        if (_collision.tag == "Full_Fruit")
        {
            scored = true;
            _collision.GetComponentInParent<Apple>().Hit(Apple.HitPlace.Full);
            GetComponentInParent<Damage>().Hit(Damage.HitDamage.Full);
        }
        if (_collision.tag == "Right_Fruit" && !(_collision.tag == "Full_Fruit"))
        {
            scored = false;
            _collision.GetComponentInParent<Apple>().Hit(Apple.HitPlace.Right);
            GetComponentInParent<Damage>().Hit(Damage.HitDamage.Right);
        }
        if (_collision.gameObject.tag == "Apple")
        {
            if (scored == false)
            {
                hitDamge = 15;
                OnScoreWatermelon(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScoreApple(_collision.GetHashCode());
            }

            //scoreSound.Play();
        }
        if (_collision.gameObject.tag == "Aubergine")
        {
            if (scored == false)
            {
                hitDamge = 12;
                OnScoreDamage(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScoreAubergine(_collision.GetHashCode());
            }
            //scoreSound.Play();
        }
        if (_collision.gameObject.tag == "Banana")
        {
            if (scored == false)
            {
                hitDamge = 10;
                OnScoreDamage(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScoreBanana(_collision.GetHashCode());
            }

            //scoreSound.Play();
        }
        if (_collision.gameObject.tag == "Coconut")
        {
            if (scored == false)
            {
                hitDamge = 25;
                OnScoreBanana(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScoreCoconut(_collision.GetHashCode());
            }

            //scoreSound.Play();
        }
        if (_collision.gameObject.tag == "Mango")
        {
            if (scored == false)
            {
                hitDamge = 18;
                OnScoreWatermelon(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScoreMango(_collision.GetHashCode());
            }
                        
            //scoreSound.Play();
        }
        if (_collision.gameObject.tag == "Melon")
        {
            if (scored == false)
            {
                hitDamge = 8;
                OnScoreDamage(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScoreMelon(_collision.GetHashCode());
            }

            //scoreSound.Play();
        }
        if (_collision.gameObject.tag == "Orange")
        {
            if (scored == false)
            {
                hitDamge = 10;
                OnScoreDamage(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScoreOrange(_collision.GetHashCode());
            }

            //scoreSound.Play();
        }
        if (_collision.gameObject.tag == "Pineapple")
        {
            if (scored == false)
            {
                hitDamge = 20;
                OnScoreWatermelon(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScorePineapple(_collision.GetHashCode());
            }

            //scoreSound.Play();
        }
        if (_collision.gameObject.tag == "Tomato")
        { 

            if (scored == false)
            {
                hitDamge = 8;
                OnScoreDamage(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScoreTomato(_collision.GetHashCode());
            }
            //scoreSound.Play();
        }
        if (_collision.gameObject.tag == "Watermelon")
        {
            if (scored == false)
            {
                hitDamge = 6;
                OnScoreWatermelonDamage(_collision.GetHashCode());
            }
            if (scored == true)
            {
                OnScoreWatermelon(_collision.GetHashCode());
            }
            //scoreSound.Play();
        }

    }
}
