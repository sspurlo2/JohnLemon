using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundTrigger : MonoBehaviour
{
    public Transform[] enemies;
    public AudioSource alertAudio;
    public float triggerDistance = 8f;
    public float dotThreshold = -0.5f; // Enemy is behind the player

    private bool isSoundPlaying = false;

    void Update()
    {
        foreach (Transform enemy in enemies)
        {
            Vector3 toEnemy = (enemy.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, enemy.position);
            float dot = Vector3.Dot(transform.forward, toEnemy); // dot < 0 = enemy behind

            if (dot < dotThreshold && distance < triggerDistance)
            {
                if (!isSoundPlaying)
                {
                    alertAudio.Play();
                    isSoundPlaying = true;
                }
                return; // one is enough to trigger
            }
        }

        if (isSoundPlaying)
        {
            alertAudio.Stop();
            isSoundPlaying = false;
        }
    }
}
