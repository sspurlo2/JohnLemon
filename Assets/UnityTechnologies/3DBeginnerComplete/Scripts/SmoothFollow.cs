using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;          
    public float followSpeed = 1f;   
    private bool stopFollowing = false;

    void Update()
    {
        if (target == null || stopFollowing) return;

        transform.position = Vector3.Lerp(
            transform.position,          // current position (a)
            target.position,             // target position (b)
            Time.deltaTime * followSpeed // t: time-smoothed follow factor 
        ); //text book linera interpolation --> doesn't get better than this
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stopFollowing = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stopFollowing = false;
        }
    }
}
