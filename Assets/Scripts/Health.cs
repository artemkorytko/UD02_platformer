using UnityEngine;

public class Health : MonoBehaviour
{
    private Transform[] Hearts = new Transform[3];
    private LevelController Level;

    private void Awake()
    {
        Level = FindObjectOfType<LevelController>();
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i] = transform.GetChild(i);
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < Level.Player.lives) Hearts[i].gameObject.SetActive(true);
            else Hearts[i].gameObject.SetActive(false);
        }
    }
}
