using System;
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
}
