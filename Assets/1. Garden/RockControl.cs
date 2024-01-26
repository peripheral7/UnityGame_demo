using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFlowerControl : MonoBehaviour
{
    private GameObject rockFlowerObject;

    // 직접 드래그해서 지정해줘야 함!
    public GameObject RockObject;
    private bool isRockFlowerActive = false;

    void Start()
    {
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
            return;
            // DeactivateRockFlower();
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
