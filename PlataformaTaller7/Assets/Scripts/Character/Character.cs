using System.Collections;
using UnityEngine;
using Delegates;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0f;
    public Sprite CharacterSprite { get; set; }
    public int CurrentBox { get; set; } = 0;

    public event Action OnReachDestination;

    public IEnumerator MoveForward(int _diceResult)
    {
        for (int i = 0; i < _diceResult; i++)
        {
            CurrentBox++;

            while(transform.position != LadderManager.Manager.Board.Boxes[CurrentBox].transform.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, LadderManager.Manager.Board.Boxes[CurrentBox].transform.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        yield return new WaitForSeconds(0.5f);
        Debug.Log("Aló");
        OnReachDestination?.Invoke();
    }

    private IEnumerator MoveBackwards()
    {


        yield return null;
    }
}
