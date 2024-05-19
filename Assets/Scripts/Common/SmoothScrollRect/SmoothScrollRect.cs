using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SmoothScrollRect : ScrollRect
{

    public bool SmoothScrolling { get; set; } = true;
    public float SmoothScrollTime { get; set; } = 0.08f;

    /// <summary>
    /// Version of <see cref="ScrollRect"/> that supports smooth scrolling.
    /// </summary>
    public override void OnScroll(PointerEventData data)
    {
        if (!IsActive()) return;

        if (SmoothScrolling)
        {
            Vector2 positionBefore = normalizedPosition;
            this.DOKill(complete: true);
            base.OnScroll(data);
            Vector2 positionAfter = normalizedPosition;
            normalizedPosition = positionBefore;

            this.DONormalizedPos(positionAfter, SmoothScrollTime).SetUpdate(true);
        }
        else
        {
            base.OnScroll(data);
        }
    }
}
