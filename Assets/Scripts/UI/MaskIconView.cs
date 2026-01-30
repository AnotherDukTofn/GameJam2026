using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MaskIconView : MonoBehaviour {
    [Header("Settings")]
    [SerializeField] private Vector2 selectedSize;
    [SerializeField] private Vector2 normalSize;
    [SerializeField] private float smoothSpeed;

    [Header("References")]
    [SerializeField] private List<Image> masks;
    private List<RectTransform> _maskRects;
    private int _targetIdx;

    private void Awake() {
        _maskRects = new List<RectTransform>();
        foreach (var mask in masks) {
            _maskRects.Add(mask.GetComponent<RectTransform>());
        }
        _targetIdx = 0;
    }

    public void SetMaskView(int idx) {
        _targetIdx = idx;
    }

    private void Update() {
        if (_targetIdx < 0) return;

        for (int i = 0; i < _maskRects.Count; i++) {
            RectTransform rt = _maskRects[i];

            Vector2 targetSize = (i == _targetIdx) ? selectedSize : normalSize;

            if (Vector2.SqrMagnitude(rt.sizeDelta - targetSize) > 0.01f) {
                rt.sizeDelta = Vector2.Lerp(rt.sizeDelta, targetSize, Time.deltaTime * smoothSpeed);
            }
        }
    }
}