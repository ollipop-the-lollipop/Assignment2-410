using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public TextMeshProUGUI currentAngle;

    Animator m_Animator;
    Vector3 m_Movement;
    Vector3 startVector;
    Vector3 currentVector;
    private float angle;
    private float radians;
    private float dotProduct;
    private float startMagnitude;
    private float currentMagnitude;
    private float magnitudes;
    Quaternion m_Rotation = Quaternion.identity;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
        startVector = m_Rigidbody.transform.position;
        startMagnitude = startVector.magnitude;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

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

        currentVector = m_Rigidbody.transform.position;
        currentMagnitude = currentVector.magnitude;
        dotProduct = Vector3.Dot(startVector, currentVector);
        magnitudes = startMagnitude * currentMagnitude;
        radians = Mathf.Acos(dotProduct / magnitudes);
        angle = radians * 180 / Mathf.PI;

        SetCountText();
    }
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    void SetCountText()
    {
        currentAngle.text = "Current Angle (from start): " + angle + "º";
    }
}
