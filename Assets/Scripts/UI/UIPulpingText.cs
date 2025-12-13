using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIPulpingText : MonoBehaviour
{

    public float scaleUp = 1.2f;
    public float duration = 0.5f;

    private RectTransform rect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rect = GetComponent<RectTransform>();

        rect.localScale = Vector3.one;

        rect.DOScale(scaleUp, duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
