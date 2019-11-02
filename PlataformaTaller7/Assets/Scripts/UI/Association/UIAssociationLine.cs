using UnityEngine;
using System.Collections;

public class UIAssociationLine : MonoBehaviour
{
    private float targetHeight = 0f;
    private RectTransform rect = null;

    [SerializeField]
    private float timeToLerp = 2f;

    public bool IsPlaced { get; private set; } = false;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        QuestionManager.OnAssociationComplete += ResetLine;
        rect.sizeDelta = new Vector2(5f, 0f);
    }

    public void SetPosition(Vector3 _FirstPoint, Vector3 _SecondPoint)
    {
        ResetLine();
        rect.position = _FirstPoint;
        Debug.DrawLine(rect.position, _SecondPoint, Color.red, 5f);
        rect.up = _SecondPoint - rect.position;
        targetHeight = Mathf.Sqrt((_SecondPoint - _FirstPoint).sqrMagnitude) * 1.6f;

        StartCoroutine(LerpLine());
    }

    private IEnumerator LerpLine()
    {
        IsPlaced = true;
        float elapsedTime = 0f;
        Vector2 targetDelta = new Vector2();


        while (elapsedTime < timeToLerp)
        {
            targetDelta = new Vector2(rect.sizeDelta.x, Mathf.Lerp(rect.sizeDelta.y, targetHeight, elapsedTime / timeToLerp));
            rect.sizeDelta = targetDelta;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void ResetLine()
    {
        IsPlaced = false;
        rect.sizeDelta = new Vector2(5f, 0f);
        Debug.Log("Line reset");
    }
}
