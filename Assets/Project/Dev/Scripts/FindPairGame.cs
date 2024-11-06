using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FindPairGame : MonoBehaviour
{
    public static event Action Completed;
    
    private readonly List<Card> SelectedCards = new List<Card>();
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

        List<Sprite> images = new List<Sprite>();
        for (int i = 0; i < (_rows * _columns) / 2; i++)
        {
            images.Add(_cardImages[i]);
            images.Add(_cardImages[i]);
        }
        
        ShuffleList(images);

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
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }
    
    private void Selected(Card selectedCard)
    {
        if (SelectedCards.Contains(selectedCard))
            return;

        SelectedCards.Add(selectedCard);

        if (SelectedCards.Count == 2)
        {
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        var delay = new WaitForSeconds(_openDelay);

        var first = SelectedCards[0];
        var second = SelectedCards[1];

        SelectedCards.Clear();

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