using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    private BoxType boxType = BoxType.None;

    public BoxType BoxType { get => boxType; private set => boxType = value; }
}
