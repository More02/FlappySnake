using System.Collections.Generic;
using UnityEngine;

public class InstanceBarriers : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> _prefabList = new();
        
    private void SpawnObject()
    {
        var randomIndex = Random.Range(0, _prefabList.Count);
        var obj = Instantiate(_prefabList[randomIndex]);
    }
}