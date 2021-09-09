using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Block))]
public class BlockView : MonoBehaviour
{
    [SerializeField] private TMP_Text _viewPrice;

    private Block _block;


    private void Awake()
    {
        _block = GetComponent<Block>();
    }


    private void OnEnable()
    {
        _block.FIllingUpdated += OnFillingUpdated;
    }

    private void OnDisable()
    {
        _block.FIllingUpdated -= OnFillingUpdated; 
    }

    private void OnFillingUpdated(int leftToFIll)
    {
        _viewPrice.text = leftToFIll.ToString();
    }
}
