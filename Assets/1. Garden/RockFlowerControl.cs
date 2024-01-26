using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFlowerControl : MonoBehaviour
{
    private GameObject rockFlowerObject;

    public GameObject RockObject;
    public bool isRockFlowerActive = false;

    // Static reference to the instance of RockFlowerControl
    public static RockFlowerControl Instance { get; private set; }

    void Start()
    {
        // Set the static instance reference
        Instance = this;

        rockFlowerObject = transform.Find("RockFlower").gameObject;
        DeactivateRockFlower();
    }

    void Update()
    {
        if (isSelected() && Input.GetKeyDown(KeyCode.Q))
        {
            ToggleRockFlower();
            Debug.Log(RockObject);
        }
    }

    bool isSelected()
    {
        if (MouseManager.Instance.selectedObject == RockObject)
            return true;
        else
            return false;
    }

    void ToggleRockFlower()
    {
        isRockFlowerActive = !isRockFlowerActive;

        if (isRockFlowerActive)
        {
            ActivateRockFlower();
        }
        else
        {
            DeactivateRockFlower();
        }
    }

    void ActivateRockFlower()
    {
        rockFlowerObject.SetActive(true);
        // Add any other activation logic you may need for the rock flower
    }

    void DeactivateRockFlower()
    {
        rockFlowerObject.SetActive(false);
        // Add any other deactivation logic you may need for the rock flower
    }
}
