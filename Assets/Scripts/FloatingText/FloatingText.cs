using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [Inject]
    private FloatingTextManager m_floatingTextManager;

    [SerializeField]
    private TextMeshProUGUI m_text;

    [Inject]
    public void Init(string text, Transform target)
    {
        m_text.text = "+" + text;
        transform.localScale = Vector3.zero;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(1, 0.5f))
                .AppendInterval(0.5f)
                .Append(transform.DOScale(0, 0.5f))
                .AppendCallback(()=> m_floatingTextManager.ExpireText(this));

        Vector3 position = target.position;
        transform.position = position;
    }


    public class Factory: PlaceholderFactory<string, Transform, FloatingText>
    {

    }
}
