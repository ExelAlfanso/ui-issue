using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RefreshUI : MonoBehaviour
{
    [SerializeField] private RectTransform root;

    private void OnEnable()
    {
        if (root == null)
        {
            root = transform as RectTransform;
        }

        StartCoroutine(RefreshNextFrame());
    }

    private IEnumerator RefreshNextFrame()
    {
        yield return null;

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(root);
        Canvas.ForceUpdateCanvases();
    }
}
