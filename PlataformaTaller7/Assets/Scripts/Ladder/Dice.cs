using UnityEngine;
using System.Collections;
using Delegates;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Dice : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Image m_Image;
    private Sprite[] diceSprites;
    private GameObject text = null;
    private bool canThrow = false;

    private int currentNumber = 0;

    public event Action<int> OnDiceResult = null;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
        text = transform.GetChild(0).gameObject;
        diceSprites = Resources.LoadAll<Sprite>("Dice Sprites/");
        m_Image.sprite = diceSprites[5];
    }

    public void OnPointerDown(PointerEventData eventData) { }

    public void OnPointerUp(PointerEventData _EventData)
    {
        if (canThrow) StartCoroutine(Throw());
    }

    private IEnumerator Throw()
    {
        SetCanThrow(false);
        AudioManager.instance.PlaySFx(AudioManager.instance.audioClips.dice, 1f, false);
        int randomDiceSide = 0;

        for (int i = 0; i < 15; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            m_Image.sprite = diceSprites[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        currentNumber = randomDiceSide + 1;
        OnDiceResult?.Invoke(currentNumber);
    }

    public void SetCanThrow(bool _value)
    {
        canThrow = _value;
        text.SetActive(_value);
    }
}
