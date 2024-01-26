using System.Collections;
using UnityEngine;

public class ButterflyMovement : MonoBehaviour
{
    private bool hasMovedYZ = false;

    void Update()
    {

        if (RockFlowerControl.Instance != null && RockFlowerControl.Instance.isRockFlowerActive &&  !hasMovedYZ)
        {
            StartCoroutine(MoveButterflyYZ());
            hasMovedYZ = true;
        }
    }


    IEnumerator MoveButterflyYZ()
    {
        yield return MoveSmooth(new Vector3(-1f, 0, 0), 0.3f);
        for (int i = 0; i < 7; i++)
        {
            yield return MoveSmooth(new Vector3(0, -0.9f, 0.2f), 0.3f); // Move -0.7 in y position over 0.5 seconds
            yield return MoveSmooth(new Vector3(0, 0.1f, 0.54f), 0.3f); // Move 0.6 in z position and +0.1 in y position over 0.5 seconds
        }
    }

    IEnumerator MoveSmooth(Vector3 offset, float duration)
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = startPos + offset * (elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos + offset; // Ensure the final position is accurate
    }
}
