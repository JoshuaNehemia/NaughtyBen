using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickriffle : MonoBehaviour
{
    public GameObject riffleOnPlayer; // Model bola baseball di pemain
    private bool isPickedUp = false; // Status apakah bola sudah diambil

    void Start()
    {
        riffleOnPlayer.SetActive(false); // Sembunyikan bola di pemain saat mulai
    }

    private void Update()
    {
        // Tidak memerlukan update logic di sini untuk saat ini
    }

    private void OnTriggerStay(Collider other)
    {
        // Pastikan hanya pemain yang dapat berinteraksi
        if (other.gameObject.tag == "Player")
        {
            // Jika tombol E ditekan, ambil bola
            if (Input.GetKey(KeyCode.E) && !isPickedUp)
            {
                isPickedUp = true; // Tandai bahwa bola telah diambil
                this.GetComponent<MeshRenderer>().enabled = false; // Sembunyikan model bola
                riffleOnPlayer.SetActive(true); // Tampilkan bola di pemain
            }

            // Jika tombol F ditekan, kembalikan bola
            else if (Input.GetKey(KeyCode.F) && isPickedUp)
            {
                isPickedUp = false; // Tandai bahwa bola telah dikembalikan
                this.GetComponent<MeshRenderer>().enabled = true; // Tampilkan model bola
                riffleOnPlayer.SetActive(false); // Sembunyikan bola di pemain
            }
        }
    }
}
