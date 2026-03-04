using System.Collections;
using UnityEngine;

public class SelectionCircle : MonoBehaviour
{
    [SerializeField] private AnimationCurve curveShow;
    [SerializeField] private AnimationCurve curveHide;
    [SerializeField] private float speed = 30f;
    [SerializeField] private float maxScale = 3.5f;
    [SerializeField] private float minScale = 2;
    [SerializeField] private float durationShow = .2f;
    [SerializeField] private float durationHide = .1f;
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime * Vector3.forward);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(ScaleRoutine(minScale, maxScale, durationShow, curveShow));
    }

    public void Hide()
    {
        StartCoroutine(ScaleRoutine(maxScale, minScale, durationHide, curveHide));
    }

    IEnumerator ScaleRoutine(float from, float to, float duration, AnimationCurve curve)
    {
        float time = 0f;
        while(time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            float curveValue = curve.Evaluate(t);
            float scale = from + (to - from) * curveValue;

            transform.localScale = new (scale, scale, 1);
            yield return null;
        }
        if(from > to) gameObject.SetActive(false);
    }
}
