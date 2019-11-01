using System.Collections;
using UnityEngine;
using Delegates;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0f;
    public Sprite CharacterSprite { get; set; }
    public int CurrentBox { get; set; } = 0;

    private Vector3 currentScale = new Vector3();

    public event Action<BoxType> OnReachDestination;

    public IEnumerator MoveForward(int _diceResult)
    {
        currentScale = transform.localScale;

        int numberOfBoxes = 0;

        if (CurrentBox + _diceResult <= LadderManager.Manager.Board.Boxes.Length - 1) numberOfBoxes = _diceResult;
        else numberOfBoxes = LadderManager.Manager.Board.Boxes.Length - 1 - CurrentBox;

        for (int i = 0; i < numberOfBoxes; i++)
        {
            CurrentBox++;

            if (transform.position.x <= LadderManager.Manager.Board.Boxes[CurrentBox].transform.position.x)
            {
                if (transform.localScale.x < 0) currentScale.x *= -1f;
                transform.localScale = currentScale;
            }
            else
            {
                if (transform.localScale.x > 0) currentScale.x *= -1f;
                transform.localScale = currentScale;
            }

            while(transform.position != LadderManager.Manager.Board.Boxes[CurrentBox].transform.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, LadderManager.Manager.Board.Boxes[CurrentBox].transform.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        yield return new WaitForSeconds(0.5f);
        if (LadderManager.Manager.Board.Boxes[CurrentBox].BoxType != BoxType.Mold) OnReachDestination?.Invoke(LadderManager.Manager.Board.Boxes[CurrentBox].BoxType);
        else StartCoroutine(MoveBackwards());
    }

    private IEnumerator MoveBackwards()
    {
        for (int i = 0; i < 3; i++)
        {
            CurrentBox--;

            if (transform.position.x <= LadderManager.Manager.Board.Boxes[CurrentBox].transform.position.x)
            {
                if (transform.localScale.x < 0) currentScale.x *= -1f;
                transform.localScale = currentScale;
            }
            else
            {
                if (transform.localScale.x > 0) currentScale.x *= -1f;
                transform.localScale = currentScale;
            }

            while (transform.position != LadderManager.Manager.Board.Boxes[CurrentBox].transform.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, LadderManager.Manager.Board.Boxes[CurrentBox].transform.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        yield return new WaitForSeconds(0.5f);
        if (LadderManager.Manager.Board.Boxes[CurrentBox].BoxType != BoxType.Mold) OnReachDestination?.Invoke(LadderManager.Manager.Board.Boxes[CurrentBox].BoxType);
        else StartCoroutine(MoveBackwards());

        yield return null;
    }
}
