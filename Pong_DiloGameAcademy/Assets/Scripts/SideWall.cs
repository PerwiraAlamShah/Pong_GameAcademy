using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{

    // Script GameManager untuk variable mengakses skor maksimal
    [SerializeField] private GameManager gameManager;
    // Pemain yang akan bertambah skornya jika ada bola menyentuh dinding ini
    public PlayerController player;

    // Akan dipanggil ketika objek lain ber-collider (bola) bersentuhan dengan dinding
    void OnTriggerEnter2D(Collider2D anotherCollider) 
    {
        // jika object tersebut bernama "Ball"
        if (anotherCollider.name == "Ball")
        {
            // Tambahkan skor pada pemain
            player.IncrementScore();

            // Jika skor pemain belum mencapai sokr maksimal...
            if (player.Score < gameManager.maxScore)
            {
                // ...restart game setalah bola mengenai dinding
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver); 
            }
        }
    }
}
