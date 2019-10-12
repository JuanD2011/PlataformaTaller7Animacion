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

    private void Awake()
    {
        if (Manager == null) Manager = this;
        else Destroy(this);
    }

    private void Start()
    {
        StartGame();
        dice.OnDiceResult += MoveCharacter;
        character.OnReachDestination += OnPlayerInBox;
    }

    private void OnPlayerInBox()
    {
        dice.SetCanThrow(true);
    }

    private void StartGame()
    {
        dice.SetCanThrow(true);
        character.transform.position = board.Boxes[0].transform.position;
        character.CurrentBox = 0;
    }

    private void MoveCharacter(int _diceResult)
    {
        StartCoroutine(character.MoveForward(_diceResult));
    }
}
