using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minTime = 2.0f;
    public float maxTime = 5.0f;
    public float interval;
    public float intervalTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        intervalTime += Time.deltaTime;

        if(intervalTime > interval) {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = this.transform.position;
            intervalTime = 0f;
            interval = GetRandomTime();
        }
    }

    private float GetRandomTime() {
        return Random.Range(minTime, maxTime);
    }
}
