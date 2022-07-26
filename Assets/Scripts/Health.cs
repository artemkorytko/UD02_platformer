using UnityEngine;

public class Health : MonoBehaviour
{
    private Transform[] _hearts = new Transform[3];
    private LevelController _level;

    private void Awake()
    {
        _level = FindObjectOfType<LevelController>();
        for (int i = 0; i < _hearts.Length; i++)
        {
            _hearts[i] = transform.GetChild(i);
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _level.Player.Lives) _hearts[i].gameObject.SetActive(true);
            else _hearts[i].gameObject.SetActive(false);
        }
    }
}
