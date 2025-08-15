using UnityEngine;

public class HighlightOnTouchOrDrag : MonoBehaviour
{
    public Color outlineColor; 
    private Color originalOutlineColor;
    private bool isHighlighted = false;

    void Start()
    {
        originalOutlineColor = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
       
        if (Input.touchCount == 0)
        {
            if (isHighlighted) HideOutline();
            return;
        }

       
        Touch touch = Input.GetTouch(0);

        
        if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    ShowOutline();
                }
                else
                {
                    HideOutline();
                }
            }
            else
            {
                HideOutline();
            }
        }
       
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            HideOutline();
        }
    }

    private void ShowOutline()
    {
        if (isHighlighted) return;
        isHighlighted = true;
        GetComponent<SpriteRenderer>().color=outlineColor;
    }

    private void HideOutline()
    {
        if (!isHighlighted) return;
        isHighlighted = false;
        GetComponent<SpriteRenderer>().color = originalOutlineColor;
    }
}
