using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeManager : MonoBehaviour
{
    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;

    private Vector2 _startPos;
    private GameObject _lastRotatedCard;
    private HashSet<GameObject> _alreadyRotated = new HashSet<GameObject>();
    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            _startPos = touch.position;
            _lastRotatedCard = null;
        }
        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
        {
            TryRotateUnderFinger(touch.position);
        }
    }

    private void TryRotateUnderFinger(Vector2 screenPos)
    {
        if (screenPos.x <= _startPos.x + 20f)
            return;

        var ped = new PointerEventData(eventSystem) { position = screenPos };
        var results = new List<RaycastResult>();
        raycaster.Raycast(ped, results);       
        if (results.Count == 0) return;
        
        var card = results[0].gameObject;

        if (card.CompareTag("Card") && card != _lastRotatedCard && !_alreadyRotated.Contains(card))
        {
            card.transform.Rotate(0f, 0f, -90f);
            _lastRotatedCard = card;
            _alreadyRotated.Add(card);
        }
        if (_alreadyRotated.Count == 4)
        {
            gameObject.GetComponentInParent<SwapAndMoveCardManager>().gameObject.SetActive(false);
        }
       
    }


    public void ResetAllRotations()
    {
        foreach (var card in _alreadyRotated)
        {
            card.transform.Rotate(0f, 0f, 90f * (_alreadyRotated.Count));
        }
        _alreadyRotated.Clear();
    }
}