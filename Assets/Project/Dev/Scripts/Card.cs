using UnityEngine;
using UnityEngine.UI;
using System;

public class Card : MonoBehaviour
{
    [SerializeField] 
    private Image _imageComponent;

    [SerializeField]
    private Sprite _back;
    
    [SerializeField]
    private Button _button;
    
    private Sprite _image;

    public event Action<Card> Selected;

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    public void SetImage(Sprite newImage)
    {
        _image = newImage;
        _imageComponent.sprite = _image;
        Hide();
    }

    public Sprite GetImage()
    {
        return _image;
    }
    
    public void Reset()
    {
        Hide();
    }
    
    private void Show()
    {
        _imageComponent.sprite = _image;
        _button.enabled = false;
    }

    private void Hide()
    {
        _imageComponent.sprite = _back;
        _button.enabled = true;
    }
    
    private void OnClick()
    {
        Show();
        Selected?.Invoke(this);
    }
}