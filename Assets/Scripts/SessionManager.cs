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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag($"Border"))
        {
           // _lootCountInt = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (col.gameObject.layer == LayerMask.NameToLayer($"BarrierLayer"))
        {
           // _lootCountInt = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        else if (col.gameObject.layer == LayerMask.NameToLayer($"LootLayer"))
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