

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timer;
    public GameObject Block;
    Vector2 allowedPosition;
    public Vector2 spawnMinMax;
    float c;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 ScreenWidth = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        Vector2 PlayerWidth = transform.localScale;
        allowedPosition = ScreenWidth - PlayerWidth;
        c = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            c = Mathf.Lerp(spawnMinMax.y, spawnMinMax.x, Difficulty.GetDifficulty());
            
            Vector2 RandomSpawnPosition = new Vector2(Random.Range(-allowedPosition.x, allowedPosition.x), allowedPosition.y + 0.5f);
            GameObject Nblock = Instantiate(Block, RandomSpawnPosition, Quaternion.Euler(0, 0, Random.Range(-15, 15)));
            Nblock.transform.localScale *= Random.Range(0.5f, 1.5f);
            Nblock.transform.parent = transform;
            timer = c;
            


        }
    }
}
