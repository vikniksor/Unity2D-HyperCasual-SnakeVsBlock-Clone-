using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Tooltip("Range of a price for the destruction of block (in tail segments).")]
    [SerializeField] private Vector2Int _destroyPriceRange;

    private int _destroyPrice;
    private int _filling;


    private void Start()
    {
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
    }

    public void Fill()
    {
        _filling++;

        if (_filling == _destroyPrice)
        {
            Destroy(gameObject);
        }
    }
}
