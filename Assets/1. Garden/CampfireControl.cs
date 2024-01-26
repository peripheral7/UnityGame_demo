using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireControl : MonoBehaviour
{
    private GameObject fireObject;
    public GameObject CampFireObject;
    public bool isFireActive = false;

    // Static reference to the instance of CampfireControl
    public static CampfireControl Instance { get; private set; }

    void Start()
    {
        // Set the static instance reference
        Instance = this;

        fireObject = transform.Find("Fire").gameObject;
        DeactivateFire();
    }

    void Update()
    {
        if (isSelected() && Input.GetKeyDown(KeyCode.Q))
        {
            ToggleFire();
            Debug.Log(CampFireObject);
        }
    }

    bool isSelected()
    {
        if (MouseManager.Instance.selectedObject == CampFireObject)
            return true;
        else
            return false;
    }

    void ToggleFire()
    {
        isFireActive = !isFireActive;

        if (isFireActive)
        {
            ActivateFire();
        }
        else
        {
            DeactivateFire();
        }
    }

    void ActivateFire()
    {
        fireObject.SetActive(true);
        // Add any other activation logic you may need
    }

    void DeactivateFire()
    {
        fireObject.SetActive(false);
        // Add any other deactivation logic you may need
    }
}
