using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private bool hasMoved = false;

    void Update()
    {
        if (CampfireControlExists() && CampfireControl.Instance.isFireActive)
        {
            if (!hasMoved)
            {
                StartCoroutine(MoveSpiderSequence());
                hasMoved = true;
            }
        }
        else
        {
            hasMoved = false;
        }
    }

    bool CampfireControlExists()
    {
        return CampfireControl.Instance != null;
    }

    IEnumerator MoveSpiderSequence()
    {
        yield return MoveSmooth(Vector3.up * 3.0f, 2.0f);     // Move +3 in y position over 2 seconds
        yield return MoveSmooth(Vector3.forward * 5.5f, 3.0f); // Move +6 in z position over 3 seconds
        yield return MoveSmooth(Vector3.down * 3.0f, 2.0f);     // Move -3 in y position over 2 seconds

        hasMoved = true;
    }

    IEnumerator MoveSmooth(Vector3 offset, float duration)
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, startPos + offset, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos + offset; // Ensure the final position is accurate
    }
}
