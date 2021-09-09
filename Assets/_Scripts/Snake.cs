using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TailGenerator))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;

    private List<Segment> _tail;
    private TailGenerator _tailGenerator;


    private void Awake()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        _tail = _tailGenerator.Generate();
    }
}
