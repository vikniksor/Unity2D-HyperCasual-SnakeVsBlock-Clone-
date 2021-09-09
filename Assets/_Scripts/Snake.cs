using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TailGenerator))]
[RequireComponent(typeof(SnakeInput))]

public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [Tooltip("The more speed of snake you add the bigger attraction you need.")]
    [SerializeField] private float _speed;
    [Tooltip("For example: great case is when snake`s speed equals 3 then attraction will be 15.")]
    [SerializeField] private float _tailSegmentsAttraction;

    private SnakeInput _snakeInput;
    private List<Segment> _tail;
    private TailGenerator _tailGenerator;


    private void Awake()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        _snakeInput = GetComponent<SnakeInput>();

        _tail = _tailGenerator.Generate();
    }

    /// <summary>
    /// better when need to continiously movement
    /// always has same speed(same frames per second) so the object moves without shakes but really smooth
    /// </summary>
    private void FixedUpdate()   
    {
        Move(_snakeHead.transform.position + _snakeHead.transform.up * _speed * Time.fixedDeltaTime);

        _snakeHead.transform.up = _snakeInput.GetDirectionToClick(_snakeHead.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = _snakeHead.transform.position;

        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, previousPosition,
                                                      _tailSegmentsAttraction * Time.deltaTime);
            previousPosition = tempPosition;
        }

        _snakeHead.Move(previousPosition);
    }
}
