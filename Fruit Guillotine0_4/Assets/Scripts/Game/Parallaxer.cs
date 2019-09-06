using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Parallaxer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;  // скорость движения
    [SerializeField] private GameObject[] myWaypoints;  // список точек по которым будет двигаться енеми

    private int myWaypointId = 0;

    class PoolObject
    {
        public Transform transform;
        public bool inUse;
        public PoolObject(Transform t) { transform = t; }
        public void Use() { inUse = true; }
        public void Dispose() { inUse = false; }
    }

    [System.Serializable]
    public struct YSpawnRange
    {
        public float minY;
        public float maxY;
    }

    
    public GameObject[] Distubs;
    public GameObject[] Fruits;
    public int poolSize;
    public float shiftSpeed;
    public float spawnRate;
    

    public YSpawnRange ySpawnRange;
    public Vector3 defaultSpawnPos;
    public bool spawnImmediate;
    public Vector3 immediateSpawnPos;
    public Vector2 targetAspectRatio;

    Rigidbody2D rigidBody;
    float spawnTimer = 15;
    PoolObject[] poolObjects;
    float targetAspect;
    GameManager game;

    void Awake()
    {
        Configure();
    }

    void Start()
    {
        game = GameManager.Instance;
        
    }

    void OnEnable()
    {
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }

    void OnDisable()
    {
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
    }
    void OnGameOverConfirmed()
    {
       // for (int i = 0; i < poolObjects.Length; i++)
      //  {
        //    poolObjects[i].Dispose();
           // poolObjects[i].transform.position = Vector3.one * 1000;
       // }
        Configure();
    }

    void Update()
    {
       
        if (game.GameOver) return;
        
        Shift();
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate)
        {
            Spawn();
            spawnTimer = 0;
        }
        
    }

    void Configure()
    {

        if (spawnImmediate)
        {
            SpawnImmediate();
        }
    }

    void Spawn()
    {
        //moving pool objects into place
        
        
        int randPrfabIndex = Random.Range(0, 10);
        if (randPrfabIndex <= 8)
        {
            int randFruitsIndex = Random.Range(0, Fruits.Length);
            GameObject prefab = Fruits[randFruitsIndex];
            Instantiate(prefab, transform.position, transform.rotation);
        }
        if (randPrfabIndex > 8)
        {
            int randDistubsIndex = Random.Range(0, Distubs.Length);
            GameObject prefab = Distubs[randDistubsIndex];
            Instantiate(prefab, transform.position, transform.rotation);
        }
        if (spawnTimer > 2.2f)
        {
            spawnTimer -= 2.2f;
            Invoke("Spawn", spawnTimer);
        }
    }

    void SpawnImmediate()
    {

    }

    void Shift()
    {

    }

    void CheckDisposeObject(PoolObject poolObject)
    {

    }
}