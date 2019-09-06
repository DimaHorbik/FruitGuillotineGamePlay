using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 3f;  // скорость движения
    public GameObject[] myWaypoints;  // список точек по которым будет двигаться енеми
    [SerializeField] public GameObject fruitFull;
    private int myWaypointId = 0;                    // текущая точка в массиве куда двигаться

    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    void EnemyMovement()
    {
        // если точки есть
        if (myWaypoints.Length != 0)
        {
            // если мы уже достигли назначенной точки, то переходим к следующей
            if (Vector3.Distance(myWaypoints[myWaypointId].transform.position, transform.position) <= 0)
            {
                fruitFull.GetComponent<SpriteRenderer>().color = Color.white;
                myWaypointId++;
            }

            //если точки исчерпаны то переходим к началу массива точек
            if (myWaypointId >= myWaypoints.Length)
            {
                moveSpeed = 0;
                Destroy(gameObject);
                myWaypointId = 0;
            }
            transform.position = Vector3.MoveTowards(transform.position, myWaypoints[myWaypointId].transform.position, moveSpeed * Time.deltaTime);
            //движемся в назначенную точку
            // move towards waypoint

        }
    }
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
}
