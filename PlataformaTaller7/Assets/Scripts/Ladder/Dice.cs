using UnityEngine;

public class Dice : MonoBehaviour
{
    public void Throw()
    {
        GetRandomNumber();
    }

    private int GetRandomNumber()
    {
        return Random.Range(1, 7);
    }
}
