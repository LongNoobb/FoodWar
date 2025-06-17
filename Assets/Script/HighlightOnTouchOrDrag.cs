using UnityEngine;

public class HighlightOnTouchOrDrag : MonoBehaviour
{
    public Material outlineMaterial; 
    private Material[] originalMaterials;
    private Renderer rend;
    private bool isHighlighted = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterials = rend.materials;
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

        
        Material[] mats = new Material[originalMaterials.Length + 1];
        for (int i = 0; i < originalMaterials.Length; i++)
            mats[i] = originalMaterials[i];
        mats[mats.Length - 1] = outlineMaterial;

        rend.materials = mats;
    }

    private void HideOutline()
    {
        if (!isHighlighted) return;
        isHighlighted = false;
        rend.materials = originalMaterials;
    }
}
