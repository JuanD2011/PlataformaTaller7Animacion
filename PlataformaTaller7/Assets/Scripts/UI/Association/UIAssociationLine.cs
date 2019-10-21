using UnityEngine;
using UnityEngine.UI.Extensions;

public class UIAssociationLine : MonoBehaviour
{
    private UILineRenderer uILineRenderer = null;

    [SerializeField]
    private float timeToLerp = 2f;

    public bool IsPlaced { get; private set; } = false;

    private void Awake()
    {
        uILineRenderer = GetComponent<UILineRenderer>();
    }

    private void Start()
    {
        QuestionManager.OnAssociationComplete += () => IsPlaced = false;
    }

    public void SetPosition(Vector3 _FirstPoint, Vector3 _SecondPoint)
    {
        IsPlaced = true;

        StopAllCoroutines();

        uILineRenderer.Points[0] = _FirstPoint;

        StartCoroutine(LerpSecondPoint(_SecondPoint));
    }

    System.Collections.IEnumerator LerpSecondPoint(Vector3 _SecondPoint)
    {
        float elapsedTime = 0;

        while (elapsedTime < timeToLerp)
        {
            uILineRenderer.Points[1] = Vector3.Lerp(uILineRenderer.Points[0], _SecondPoint, elapsedTime / timeToLerp);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        uILineRenderer.Points[1] = _SecondPoint;
    }
}
