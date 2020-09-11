using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Global Variable
    // Tombol untuk menggerakkan ke atas
    public KeyCode upButton = KeyCode.W;

    // Tombol untuk menggerakkan ke bawah
    public KeyCode downButton = KeyCode.S;

    // Kecepatan gerak
    public float speed = 10.0f;

    // Batas atas dan bawah game scene ( baatas bawah menggunakan minus (-))
    public float yBoundary = 9.0f;

    // Rigidbody 2D raket ini
    private Rigidbody2D rigidBody2D;

    // Skor pemain
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Dapatkan kecepatan raket sekarang
        Vector2 velocity = rigidBody2D.velocity;

        // Jika pemaon menekan tombol ke atas, beri kecepatan positif ke komponen y (ke atas)
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        // Jika pemain menekan tombol ke bawah, beri kecepaan negatis ke komponen y ( ke bawah)
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        // Jika  pemain tidak menekan tombol apa apa, kecepatannya nol
        else
        {
            velocity.y = 0.0f;
        }

        // Dapatkan posisi raket sekarang 
        Vector3 position = transform.position;

        // Jika posisi raket melewati batas atas (yBoundary), kembalikan ke batas atas tersebut
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        // Jika posisi raket melewati batas bawah (-yBoundary), kembalikan ke batas atas tersebut
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        // Masukkan kembali posisinya ke trasform
        transform.position = position;
    }

    // Menaikkan skor sebanyak 1 poin
    public void inicrementScore()
    {
        score++;
    }

    // mendapatkan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    // Mendapatkan nilai skor 
    public int Score 
    {
        get { return score;}
    }
}
