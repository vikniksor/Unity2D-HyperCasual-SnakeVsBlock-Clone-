using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bonus : MonoBehaviour
{
    [SerializeField] private TMP_Text _bonusSizeText;
    [SerializeField] private Vector2Int _bonusSizeRange;

    private int _bonusSize;


    private void Start()
    {
        _bonusSize = Random.Range(_bonusSizeRange.x, _bonusSizeRange.y);
        _bonusSizeText.text = _bonusSize.ToString();
    }


    public int Collect()
    {
        Destroy(gameObject);
        return _bonusSize;
    }

}
