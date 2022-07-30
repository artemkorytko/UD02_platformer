using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Slider healthSlider;

    private GameObject _parent = null;
    private Vector3 _currentScale;
    
    private void Start()
    {
        _currentScale = transform.localScale;
        _parent = health.gameObject;
        healthSlider.maxValue = health.MaxHealth;
        healthSlider.value = healthSlider.maxValue;
        health.OnHealthChanged += HealthView;
    }

    private void HealthView()
    {
        healthSlider.value = health.HealthValue;
        if (healthSlider.value == 0)
        {
            healthSlider.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!Mathf.Approximately(_parent.transform.localScale.x, _currentScale.x))
        {
            _currentScale.x *= -1f;
            transform.localScale = _currentScale;
        }
    }
}
