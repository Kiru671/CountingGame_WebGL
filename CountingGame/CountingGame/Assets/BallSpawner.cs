using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float spawnInterval = 1f;
    
    
    private void Start()
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            Instantiate(ballPrefab, transform.position + new Vector3(
                (Random.Range(0, 2) == 0 ? -1 : 1) * Random.Range(0, 5f), 12f, 0f), Quaternion.identity);
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
