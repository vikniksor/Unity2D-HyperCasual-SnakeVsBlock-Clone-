using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _snakeSizeText;

    private Snake _snake;


    private void Awake()
    {
        _snake = GetComponent<Snake>();
    }


    private void OnEnable()
    {
        _snake.SizeUpdated += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _snake.SizeUpdated -= OnSizeUpdated;
    }

    private void OnSizeUpdated(int size)
    {
        _snakeSizeText.text = size.ToString();
    }
}
