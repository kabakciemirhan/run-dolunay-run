using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer; //zemin tespiti
    [SerializeField] private Transform feetPos; //zemine değen yerin tespiti
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    private bool isGrounded = false;
    private bool isButtonPressed = false;

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        if(isGrounded && isButtonPressed)
        {
            //eğer karakter yere dokunuyorsa ve ayrıca zıplama tuşuna basıldıysa
            rb.velocity = Vector2.up * jumpForce;
            Debug.Log("zeminden havaya zıpladı");
        }

    }

    public void ZıplamaTusu()
    {
        StartCoroutine(ButtonWait());
        Debug.Log("Zıplama tuşuna basıldı");
    }

    IEnumerator ButtonWait()
    {
        isButtonPressed = true;
        yield return new WaitForSeconds(0.1f);
        isButtonPressed = false;
    }
}
