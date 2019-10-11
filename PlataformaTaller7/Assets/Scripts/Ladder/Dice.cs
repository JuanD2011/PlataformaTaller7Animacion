using UnityEngine;
using System.Collections;
using Delegates;

public class Dice : MonoBehaviour
{
    private new SpriteRenderer renderer;
    private Sprite[] diceSprites;
    private bool canThrow = false;

    private int currentNumber = 0;

    public event Action<int> OnDiceResult = null;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        diceSprites = Resources.LoadAll<Sprite>("Dice Sprites/");
        renderer.sprite = diceSprites[5];
        canThrow = true;
    }

    private void OnMouseDown()
    {
        if (canThrow) StartCoroutine(Throw());
    }

    private IEnumerator Throw()
    {
        SetCanThrow(false);
        int randomDiceSide = 0;

        for (int i = 0; i < 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            renderer.sprite = diceSprites[randomDiceSide];
            yield return new WaitForSeconds(0.1f);
        }

        currentNumber = randomDiceSide + 1;
        SetCanThrow(true);
        OnDiceResult?.Invoke(currentNumber);
    }

    public void SetCanThrow(bool _value) => canThrow = _value;
}
