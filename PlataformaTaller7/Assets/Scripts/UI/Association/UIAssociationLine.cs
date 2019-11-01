using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIAssociationLine : MonoBehaviour
{
    private Image line = null;
    private RectTransform lineTransform = null;
    private float targetHeight = 0f;

    [SerializeField]
    private float timeToLerp = 2f;

    public bool IsPlaced { get; private set; } = false;

    private void Awake()
    {
        line = GetComponentInChildren<Image>();
        lineTransform = line.GetComponent<RectTransform>();
    }

    private void Start()
    {
        QuestionManager.OnAssociationComplete += () => IsPlaced = false;

        lineTransform.sizeDelta = new Vector2(20f, 0f);
    }

    public void SetPosition(Vector3 _FirstPoint, Vector3 _SecondPoint)
    {
        line.enabled = true;
        transform.localPosition = _FirstPoint;
        lineTransform.rotation = Quaternion.LookRotation(_SecondPoint - _FirstPoint, line.transform.forward);
        targetHeight = Mathf.Sqrt((_SecondPoint - _FirstPoint).sqrMagnitude);

        StartCoroutine(LerpLine());

        //Debug.Log("SetPosition");
    }

    private IEnumerator LerpLine()
    {
        IsPlaced = true;
        float elapsedTime = 0f;
        Vector2 targetDelta = new Vector2();
        Vector2 targetPosition = new Vector2();

        //Debug.Log("Lerpin'");

        while (elapsedTime < timeToLerp)
        {
            targetDelta = new Vector2(lineTransform.sizeDelta.x, Mathf.Lerp(lineTransform.sizeDelta.y, targetHeight, elapsedTime / timeToLerp));
            lineTransform.sizeDelta = targetDelta;
            targetPosition = new Vector2(lineTransform.position.x, Mathf.Lerp(lineTransform.position.y, targetHeight / 2, elapsedTime / timeToLerp));
            lineTransform.position = targetPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
