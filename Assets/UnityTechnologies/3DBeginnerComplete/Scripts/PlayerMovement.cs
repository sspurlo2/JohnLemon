using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;

    public float turnSpeed = 20f;
    public Transform playerCamera; // Assign John Lemon's camera transform in the Inspector
    public Transform ghostTransform; // Assign the Ghost's transform in the Inspector
    public float detectionDistance = 5f;
    public float viewAngleThreshold = 0.1f; // Adjust for "looking at" sensitivity
    public TextMeshProUGUI WarningText;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();

        MoveAction.Enable();

        // It's better to assign the ghost in the Inspector
        if (ghostTransform == null)
        {
            Debug.LogError("Ghost Transform is not assigned in the Inspector!");
            enabled = false; // Disable the script if the ghost is not assigned
            return;
        }

        if (playerCamera == null)
        {
            Debug.LogError("Player Camera Transform is not assigned in the Inspector!");
            enabled = false; // Disable the script if the camera is not assigned
            return;
        }

        if (WarningText == null)
        {
            Debug.LogError("Warning Text (TextMeshPro) is not assigned in the Inspector!");
            enabled = false; // Disable if the text object is not assigned
            return;
        }

        WarningText.gameObject.SetActive(false); // Initially hide the warning text
    }

    void FixedUpdate()
    {
        var pos = MoveAction.ReadValue<Vector2>();

        float horizontal = pos.x;
        float vertical = pos.y;

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    void Update()
    {
        // Ensure the ghost and camera transforms are valid
        if (ghostTransform == null || playerCamera == null || WarningText == null)
        {
            return;
        }

        Vector3 toGhost = (ghostTransform.position - playerCamera.position).normalized; // Use camera position
        float distance = Vector3.Distance(playerCamera.position, ghostTransform.position); // Use camera position
        float dot = Vector3.Dot(playerCamera.forward, toGhost); // Use camera forward

        if (distance < detectionDistance && dot > viewAngleThreshold)
        {
            WarningText.gameObject.SetActive(true);
            WarningText.text = "Enemy is near!"; // Directly set TextMeshPro text
        }
        else
        {
            WarningText.gameObject.SetActive(false);
        }
    }
}