using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private ISelectable currentSelect;
    private Vector2 selectPos;

    void Update()
    {
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        selectPos = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        SelectObject();

        // Debug.Log("[SELECT] click " + selectPos);
    }

    private void SelectObject()
    {
        Ray ray = cam.ScreenPointToRay(selectPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<ISelectable>(out var s))
            {
                ChangeSelection(s);
                return;
            }
        }
        ClearSelection();
    }

    private void ChangeSelection(ISelectable newSelection)
    {
        if(currentSelect != newSelection){
            currentSelect?.Diselect();
            newSelection.Select();
            currentSelect = newSelection;
            // Debug.Log("[SELECT] " + ((MonoBehaviour)newSelection).name + " selected");
        }
    }

    private void ClearSelection()
    {
        currentSelect?.Diselect();
        currentSelect = null;

        // Debug.Log("[SELECT] Clear Selection!");
    }
}