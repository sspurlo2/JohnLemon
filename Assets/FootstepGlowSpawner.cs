using UnityEngine;

public class FootstepGlowSpawner : MonoBehaviour
{
    public GameObject footstepGlowPrefab; // assign your particle prefab in the Inspector
    public float stepInterval = 0.3f; // time between steps
    private float stepTimer;

    void Update()
    {
        if (IsMoving())
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                SpawnGlow();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    bool IsMoving()
    {
        return Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
    }

    void SpawnGlow()
    {
        Instantiate(footstepGlowPrefab, transform.position, Quaternion.identity);
    }
}
