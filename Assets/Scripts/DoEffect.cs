using UnityEngine;
using DG.Tweening;

public class DoEffect : MonoBehaviour
{
    [SerializeField] private float _Duration;
    private SpriteRenderer _spriteRenderer;

    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DoAnimation()
    {
        Sequence quence = DOTween.Sequence();
        quence.Append(_spriteRenderer.DOColor(Color.red, _Duration));
        quence.Append(_spriteRenderer.DOColor(Color.white, _Duration));
        quence.Append(_spriteRenderer.DOColor(Color.red, _Duration));
        quence.Append(_spriteRenderer.DOColor(Color.white, _Duration));
    }

}
