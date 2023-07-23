using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstanceBarriers : MonoBehaviour
{
    public List<GameObject> PrefabListBarriers = new();
    public List<GameObject> PrefabListLoots = new();

    [SerializeField] private Transform _target;
    private float _screenWidth;
    private float _screenHeight;

    public static InstanceBarriers Instance { get; private set; }

    private void Start()
    {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        Instance = this;
    }

    public void SpawnObject(IReadOnlyList<GameObject> prefabsToSpawn)
    {
        var randomIndex = Random.Range(0, prefabsToSpawn.Count);
        var obj = Instantiate(prefabsToSpawn[randomIndex]);

        var targetPosition = _target.position;
        var newX = targetPosition.x + _screenWidth;
        var position = obj.transform.position;
        var randomChangeHeight = Random.Range(position.y - _screenHeight / 2, position.y + _screenHeight / 2);
        var newY = position.y + randomChangeHeight;

        var newPosition = new Vector3(newX, newY, position.z);
        transform.position = newPosition;
    }
}