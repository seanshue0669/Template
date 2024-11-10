using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private string selectableTag = "Selectable";
    [SerializeField]
    private Material highlightMaterial;
    [SerializeField]
    private Material defaultMaterial;

    private Transform _selection;                // Tracks the current object the cursor is hovering over
    private Transform _selectedObject;           // Tracks the object that has been permanently selected
    // Update is called once per frame
    void Update()
    {
        // Create a ray from the mouse position
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            var selectionObject = hit.transform;

            // Check if the object has the specified tag and has not been permanently selected
            if (selectionObject.CompareTag(selectableTag) && selectionObject != _selectedObject)
            {
                var selectionRenderer = selectionObject.GetComponent<Renderer>();

                if (selectionRenderer != null)
                {
                    // Highlight the object under the cursor
                    selectionRenderer.material = highlightMaterial;
                }

                // Update the currently hovered object
                _selection = selectionObject;

                // If left mouse button is clicked, permanently select the object
                if (Input.GetMouseButtonDown(0))
                {
                    // If there was a previously selected object, reset its material
                    if (_selectedObject != null)
                    {
                        var previousRenderer = _selectedObject.GetComponent<Renderer>();
                        if (previousRenderer != null)
                        {
                            previousRenderer.material = defaultMaterial;
                        }
                    }
                    // Set the clicked object as the permanently selected object
                    _selectedObject = _selection;
                }
            }
        }
        ClearMat();
    }
    // Restore the material of the last hovered object if it has not been selected
    void ClearMat()
    {
        bool isHit = _selection != null;
        bool isHitRepeat = (_selection == _selectedObject);
        if (isHit && !isHitRepeat)
        {
            //assign material on it
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = defaultMaterial;
            }
            //clear the selection
            _selection = null;
        }
    }
}
