using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstantiateBarriersManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private List<GameObject> _listOfBarriers;
    [SerializeField] private List<GameObject> _listOfLoots;
    [SerializeField] private float _spawnDistanceMin = 10f;
    [SerializeField] private float _spawnDistanceMax = 20f;
    [SerializeField] private float _spawnHeightMin = 1f;
    [SerializeField] private float _spawnHeightMax = 5f;
    [SerializeField] private int _minSpawnCount = 1;
    [SerializeField] private int _maxSpawnCount = 3;
    [SerializeField] private float _minSpawnInterval;
    [SerializeField] private float _maxSpawnInterval = 2f;
    
    private void Start()
    {
        Movement.OnSessionBegin += StartCoroutineSpawnObjects;
        // StartCoroutine(SpawnObjects());
    }
    
    private void StartCoroutineSpawnObjects()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            var barrierCount = Random.Range(_minSpawnCount, _maxSpawnCount + 1);
            var lootCount = Random.Range(0, barrierCount);

            for (var i = 0; i < barrierCount; i++)
            {
                var barrier = Instantiate(_listOfBarriers[Random.Range(0, _listOfBarriers.Count)]);
                SetObjectPosition(barrier);
                yield return new WaitForSeconds(Random.Range(_minSpawnInterval, _maxSpawnInterval));
            }

            for (var i = 0; i < lootCount; i++)
            {
                var loot = Instantiate(_listOfLoots[Random.Range(0, _listOfLoots.Count)]);
                SetObjectPosition(loot);
                yield return new WaitForSeconds(Random.Range(_minSpawnInterval, _maxSpawnInterval));
            }
        }
    }

    private void SetObjectPosition(GameObject obj)
    {
        var spawnDistance = Random.Range(_spawnDistanceMin, _spawnDistanceMax);
        var spawnPosition = _player.transform.position +
                            new Vector3(spawnDistance, Random.Range(_spawnHeightMin, _spawnHeightMax), 0);
        obj.transform.position = spawnPosition;
        var rb = obj.GetComponent<Rigidbody2D>();
        if (rb is null) return;
        var direction = (_player.transform.position - obj.transform.position).normalized;
        var randomYDirection = Random.Range(-1f, 1f);
        var randomDirection = new Vector3(direction.x, randomYDirection, 0f).normalized;
        rb.velocity = randomDirection * Random.Range(1f, 5f);
    }

    private void OnDestroy()
    {
        Movement.OnSessionBegin -= StartCoroutineSpawnObjects;
    }
}