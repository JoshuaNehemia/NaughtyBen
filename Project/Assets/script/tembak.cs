using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tembak : MonoBehaviour
{
    float force = 500;
    float vz = 15;
    float vy = 0.1f;
    public AudioClip suara;
    public Transform pucuk; // posisi awal peluru
    public GameObject peluru; // objek peluru

    private bool hasGun = false; // status apakah player memiliki senjata

    // Method untuk mengatur status apakah player memegang senjata
    public void SetHasGun(bool status)
    {
        hasGun = status;
    }

    void Update()
    {
        // Jika player tidak memegang senjata, tidak bisa menembak
        if (!hasGun) return;

        // Jika player menekan tombol kiri mouse (Fire1), lakukan tembakan
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 posisi = pucuk.position;
            var p = Instantiate(peluru, posisi, Quaternion.identity) as GameObject;

            float v = Mathf.Sqrt(vy * vy + vz * vz); // besar vektor
            vy = vy / v; // normalisasi vektor
            vz = vz / v;

            p.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(0, vy, vz) * force); // berikan gaya pada peluru

            Destroy(p, 3f); // hancurkan peluru setelah 3 detik
            GetComponent<AudioSource>().PlayOneShot(suara); // mainkan suara tembakan
        }
    }
}
