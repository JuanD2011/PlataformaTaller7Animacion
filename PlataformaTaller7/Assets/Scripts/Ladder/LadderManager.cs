using UnityEngine;

public class LadderManager : MonoBehaviour
{
    public static LadderManager Manager = null;

    [SerializeField]
    private Dice dice;

    [SerializeField]
    private Board board;

    [SerializeField]
    private Character character;

    public Dice Dice { get => dice; private set => dice = value; }
    public Board Board { get => board; private set => board = value; }
    public Character Character { get => character; private set => character = value; }

    private void Awake()
    {
        if (Manager == null) Manager = this;
        else Destroy(this);
    }

    private void Start()
    {
        StartGame();
        dice.OnDiceResult += MoveCharacter;
        Character.OnReachDestination += OnPlayerInBox;
    }

    private void OnPlayerInBox(BoxType _boxType)
    {
        if (Character.CurrentBox == board.Boxes.Length - 1)
        {
            Debug.Log("Game Over");
        }
        else dice.SetCanThrow(true);
    }

    private void StartGame()
    {
        dice.SetCanThrow(true);
        Character.transform.position = board.Boxes[0].transform.position;
        Character.CurrentBox = 0;
    }

    private void MoveCharacter(int _diceResult)
    {
        StartCoroutine(Character.MoveForward(_diceResult));
    }
}
