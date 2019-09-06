using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKonveer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;  // скорость движения
    [SerializeField] private GameObject[] myWaypoints;  // список точек по которым будет двигаться енеми

    private int myWaypointId = 0;                    // текущая точка в массиве куда двигаться

    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    void EnemyMovement()
    {
        // если точки есть
        if (myWaypoints.Length != 0)
        {
            // если мы уже достигли назначенной точки, то переходим к следующей
            if (Vector3.Distance(myWaypoints[myWaypointId].transform.position, transform.position) <= 0.01)
            {
                moveSpeed = 0;
                Destroy(gameObject);
                myWaypointId = 0;
            }

            //если точки исчерпаны то переходим к началу массива точек
            if (myWaypointId >= myWaypoints.Length)
            {
                moveSpeed = 0;
                Destroy(gameObject);
                myWaypointId = 0;
            }

            //движемся в назначенную точку
            // move towards waypoint
            transform.position = Vector3.MoveTowards(transform.position, myWaypoints[myWaypointId].transform.position, moveSpeed * Time.deltaTime);
        }
    }
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
}

