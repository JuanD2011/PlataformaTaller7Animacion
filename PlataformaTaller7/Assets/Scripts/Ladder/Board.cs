using UnityEngine;

public class Board : MonoBehaviour
{
    private Box[] boxes;

    public Box[] Boxes { get => boxes; set => boxes = value; }

    private void Awake() => Boxes = GetComponentsInChildren<Box>();
}
