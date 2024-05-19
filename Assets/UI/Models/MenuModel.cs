using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuModel: AbstractModel
{
    public ScrollRect scrollRect = null;

    private MenuViewModel _viewModel = null;

    private MenuData _data = null;

    [Inject]
    private void Construct(MenuViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public void ChangeSizeOfScrollContent()
    {
        int screenWidth = Screen.width;

        GameObject[] views = _viewModel._menuViews;
        _viewModel.scrollContentRectTransform.offsetMax = new Vector2(screenWidth * (views.Length - 1), 1);
        for (int i = 0; i < views.Length; i++)
        {
            RectTransform viewRectTransform = views[i].GetComponent<RectTransform>();
            viewRectTransform.sizeDelta = new Vector2(screenWidth, 1);
            viewRectTransform.anchoredPosition = new Vector2(screenWidth * i, 0);
        }
    }

    public void ScrollToValue(float targetValue)
    {
        DOTween.To(() => scrollRect.horizontalNormalizedPosition, x => scrollRect.horizontalNormalizedPosition = x, targetValue, 0.3f).SetEase(Ease.OutQuad);
    }
}
