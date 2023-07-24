using BaseMovement;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSession
{
    /// <summary>
    /// Управление игровой сессией
    /// </summary>
    public class SessionManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lootCountText;
        [SerializeField] private TMP_Text _textPress;
        private int _lootCountInt;

        private void Start()
        {
            Movement.OnSessionBegin += StartSession;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag($"Border"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (col.gameObject.CompareTag($"Barrier"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            else if (col.gameObject.CompareTag($"Loot"))
            {
                _lootCountInt++;
                _lootCountText.SetText(_lootCountInt.ToString());
                Destroy(col.gameObject);
            }
        }

        private void StartSession()
        {
            _textPress.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Movement.OnSessionBegin -= StartSession;
        }
    }
}