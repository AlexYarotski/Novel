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
        _button.interactable = true;
    }

    public void Disable()
    {
        _button.interactable = false;
    }

    private void Show()
    {
        _imageComponent.enabled = true;
    }

    private void Hide()
    {
        _imageComponent.sprite = _back;
    }
    
    private void OnClick()
    {
        Show();
        Selected?.Invoke(this);
    }
}