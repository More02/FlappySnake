using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Debug.Log("trigger");
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