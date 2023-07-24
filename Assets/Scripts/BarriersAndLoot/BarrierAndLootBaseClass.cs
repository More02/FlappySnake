using System.Collections;
using UnityEngine;

namespace BarriersAndLoot
{
    /// <summary>
    /// Базовый класс для барьеров и добычи
    /// </summary>
    public abstract class BarrierAndLootBaseClass : MonoBehaviour
    {
        protected IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(10);
            Destroy(gameObject);
        }
    }
}