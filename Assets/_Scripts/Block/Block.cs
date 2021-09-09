using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [Tooltip("Range of a price for the destruction of block (in tail segments).")]
    [SerializeField] private Vector2Int _destroyPriceRange;

    private int _destroyPrice;
    private int _filling;

    public int LeftToFill => _destroyPrice - _filling;

    public event UnityAction<int> FIllingUpdated;


    private void Start()
    {
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);

        FIllingUpdated?.Invoke(LeftToFill);
    }

    public void Fill()
    {
        _filling++;
        FIllingUpdated?.Invoke(LeftToFill);

        if (_filling == _destroyPrice)
        {
            Destroy(gameObject);
        }
    }
}
