using System.Collections;
using System.Collections.Generic;
using BaseMovement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BarriersAndLoot
{
    /// <summary>
    /// Создание препятствий и добычи
    /// </summary>
    public class InstantiateBarriersAndLootsManager : MonoBehaviour
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
                    barrier.SetActive(true);
                    SetObjectPosition(barrier);
                    yield return new WaitForSeconds(Random.Range(_minSpawnInterval, _maxSpawnInterval));
                }

                for (var i = 0; i < lootCount; i++)
                {
                    var loot = Instantiate(_listOfLoots[Random.Range(0, _listOfLoots.Count)]);
                    loot.SetActive(true);
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
        }

        private void OnDestroy()
        {
            Movement.OnSessionBegin -= StartCoroutineSpawnObjects;
        }
    }
}