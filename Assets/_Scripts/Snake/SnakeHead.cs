using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;


    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }


    public void Move(Vector3 newPosition)
    {
        _rigidBody2D.MovePosition(newPosition);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            block.Fill();
        }
    }
}
