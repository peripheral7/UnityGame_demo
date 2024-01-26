using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance { get; private set; }

    public GameObject selectedObject;
    public LayerMask itemMask;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        // RaycastHit[] hits = Physics.RaycastAll(ray);

        if (Physics.Raycast(ray, out hitInfo, itemMask))
        {
            // Debug.Log("Mouse over " + hitInfo.collider.name);

            GameObject hitObject = hitInfo.transform.root.gameObject;
            // if grouped, iterate through parents with getComponent <Unit> C#, or has collider

            SelectObject(hitObject);
        }
        else
        {
            ClearSelection();
        }
    }

    private Dictionary<Renderer, Material[]> originalMaterialsDict = new Dictionary<Renderer, Material[]>();

    void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)
                return;
            ClearSelection();
        }

        selectedObject = obj;

        if (selectedObject.layer == LayerMask.NameToLayer("Things"))
        {
            Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
            {
                // Check if materials have already been saved for this renderer
                if (!originalMaterialsDict.ContainsKey(r))
                {
                    // Save the original materials only once
                    originalMaterialsDict[r] = r.materials.Clone() as Material[];
                }

                Material[] newMaterials = new Material[r.materials.Length];
                for (int i = 0; i < r.materials.Length; i++)
                {
                    newMaterials[i] = new Material(r.materials[i]);
                    newMaterials[i].color = Color.grey;
                }

                r.materials = newMaterials;
            }
        }
    }

    void ClearSelection()
    {
        if (selectedObject == null)
            return;

        if (selectedObject.layer == LayerMask.NameToLayer("Things"))
        {
            Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
            {
                // Revert to the original materials only if they were saved previously
                if (originalMaterialsDict.ContainsKey(r))
                {
                    r.materials = originalMaterialsDict[r];
                    originalMaterialsDict.Remove(r);
                }
            }
        }

        selectedObject = null;
    }

}
