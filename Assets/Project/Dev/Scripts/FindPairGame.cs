using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FindPairGame : MonoBehaviour
{
    public static event Action Completed;
    
    private readonly List<Card> CardList = new List<Card>();

    [SerializeField]
    private float _openDelay;
    
    [Header("Card")]
    [SerializeField]
    private Card _cardPrefab;
    [SerializeField]
    private List<Sprite> _cardImages;

    [Header("Field")]
    [SerializeField]
    private int _rows = 2;  [SerializeField]
    private int _columns = 2; 

    private Card _firstCard, _secondCard;
    private GridLayoutGroup _layoutGroup;
    private int _pairsFound = 0;

    private void Start()
    {
        gameObject.SetActive(false);
        
        _layoutGroup = GetComponent<GridLayoutGroup>();
        
        InitializeCards();
        ShuffleCards();
    }

    private void InitializeCards()
    {
        if (_cardImages.Count < (_rows * _columns) / 2)
        {
            Debug.LogError("Недостаточно изображений для создания пар!");
            return;
        }

        List<Sprite> images = new List<Sprite>(_cardImages);
        images.AddRange(_cardImages);

        images = images.GetRange(0, (_rows * _columns) / 2);
        images.AddRange(images);
        
        for (int i = 0; i < _rows * _columns; i++)
        {
            var cardObject = Instantiate(_cardPrefab, transform);
            var card = cardObject.GetComponent<Card>();
            card.SetImage(images[i]);
            card.Selected += Selected;
            CardList.Add(card);
        }

        if (_layoutGroup != null)
        {
            _layoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _layoutGroup.constraintCount = _columns;
        }
    }

    private void ShuffleCards()
    {
        ShuffleList(CardList);
    }

    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void Selected(Card selectedCard)
    {
        if (_firstCard == null)
        {
            _firstCard = selectedCard;
        }
        else if (_secondCard == null)
        {
            _secondCard = selectedCard;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        var delay = new WaitForSeconds(_openDelay);

        var first = _firstCard;
        var second = _secondCard;
        
        _firstCard = null;
        _secondCard = null;

        if (first.GetImage() == second.GetImage())
        {
            _pairsFound++;

            if (_pairsFound == _cardImages.Count)
            {
                GameOver();
            }
        }
        else
        {
            yield return delay;
            
            first.Reset();
            second.Reset();
        }        
    }

    private void GameOver()
    {
        Completed?.Invoke();
    }
}