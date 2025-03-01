using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _enemyDiamond;
    [SerializeField] private GameObject _enemySquare;
    [SerializeField] private GameObject _enemyCircle;

    [SerializeField] private int _waveSize;
    [SerializeField] private float _waveTimer; 
    private float _countDown;

    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _spawnPointRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _countDown = _waveTimer;
    }

    // Update is called once per frame
    void Update()
    {
        _countDown -= Time.deltaTime;

        if(_countDown <= 0f)
        {
            SpawnWave();
            _countDown = _waveTimer;
            _waveSize++;
        }
    }

    private void SpawnWave()
    {
        foreach (Transform spawn in _spawnPoints)
        {
            for (int i = 0; i < _waveSize; i++)
            {
                SpawnEnemy(spawn);
            }
            
        }
    }

    private void SpawnEnemy(Transform spawnCenter)
    {
        GameObject enemy;

        float randomX = UnityEngine.Random.Range(spawnCenter.position.x - _spawnPointRadius, spawnCenter.position.x + _spawnPointRadius);
        float randomZ = UnityEngine.Random.Range(spawnCenter.position.z - _spawnPointRadius, spawnCenter.position.z + _spawnPointRadius);


        Vector3 spawnPoint = new Vector3(randomX, spawnCenter.position.y, randomZ);
       
        int enemyType = UnityEngine.Random.Range(1, 4);
        
        switch (enemyType)
        {
            case 1: enemy = _enemyCircle; break;
            case 2: enemy = _enemyDiamond; break;
            case 3: enemy = _enemySquare; break;
            default: return;
        }

        Instantiate(enemy, spawnPoint, Quaternion.identity);

    }


}
