using System;
using DefaultNamespace;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag($"Border"))
        {
            Debug.Log("finished");
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(InstantiateBarriers), 0f, 1f);
    }

    private void InstantiateBarriers()
    {
        InstanceBarriers.Instance.SpawnObject(InstanceBarriers.Instance.PrefabListBarriers);
        InstanceBarriers.Instance.SpawnObject(InstanceBarriers.Instance.PrefabListLoots);
    }
}