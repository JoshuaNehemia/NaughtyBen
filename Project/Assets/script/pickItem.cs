using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickItem : MonoBehaviour
{
    public GameObject riffleOnPlayer; // Model rifle di pemain
    public GameObject baseBallOnPlayer; // Model baseball di pemain
    public GameObject riffleObject; // Objek rifle di dunia
    public GameObject baseballObject; // Objek baseball di dunia

    private bool isRifflePickedUp = false; // Status apakah rifle sudah diambil
    private bool isBaseballPickedUp = false; // Status apakah baseball sudah diambil

    private tembak shootingScript; // Referensi ke script tembak

    void Start()
    {
        // Cari script tembak di pemain
        shootingScript = GetComponent<tembak>();

        // Sembunyikan rifle dan baseball di pemain saat mulai
        riffleOnPlayer.SetActive(false);
        baseBallOnPlayer.SetActive(false);

        // Pastikan player tidak bisa menembak di awal
        if (shootingScript != null)
        {
            shootingScript.SetHasGun(false); // Player tidak punya senjata di awal
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && !isRifflePickedUp && !isBaseballPickedUp && this.gameObject.tag == "Gun")
            {
                PickRiffle();
            }
            else if (Input.GetKey(KeyCode.E) && !isBaseballPickedUp && !isRifflePickedUp && this.gameObject == baseballObject)
            {
                PickBaseball();
            }
            else if (Input.GetKey(KeyCode.F) && isRifflePickedUp)
            {
                DropRiffle();
            }
            else if (Input.GetKey(KeyCode.F) && isBaseballPickedUp)
            {
                DropBaseball();
            }
        }
    }

    private void PickRiffle()
    {
        isRifflePickedUp = true;
        isBaseballPickedUp = false;
        riffleObject.GetComponent<MeshRenderer>().enabled = false;
        baseballObject.GetComponent<MeshRenderer>().enabled = true;
        riffleOnPlayer.SetActive(true);
        baseBallOnPlayer.SetActive(false);

        // Aktifkan kemampuan menembak hanya jika rifle diambil
        if (shootingScript != null)
        {
            shootingScript.SetHasGun(true); // Player sekarang memegang senjata
        }
    }

    private void DropRiffle()
    {
        isRifflePickedUp = false;
        riffleObject.GetComponent<MeshRenderer>().enabled = true;
        riffleOnPlayer.SetActive(false);

        // Nonaktifkan kemampuan menembak jika rifle dilepaskan
        if (shootingScript != null)
        {
            shootingScript.SetHasGun(false); // Player tidak bisa menembak tanpa senjata
        }
    }

    private void PickBaseball()
    {
        isBaseballPickedUp = true;
        isRifflePickedUp = false;
        baseballObject.GetComponent<MeshRenderer>().enabled = false;
        riffleObject.GetComponent<MeshRenderer>().enabled = true;
        baseBallOnPlayer.SetActive(true);
        riffleOnPlayer.SetActive(false);

        // Nonaktifkan kemampuan menembak jika baseball diambil
        if (shootingScript != null)
        {
            shootingScript.SetHasGun(false); // Baseball tidak bisa digunakan untuk menembak
        }
    }

    private void DropBaseball()
    {
        isBaseballPickedUp = false;
        baseballObject.GetComponent<MeshRenderer>().enabled = true;
        baseBallOnPlayer.SetActive(false);

        // Pastikan kemampuan menembak tetap nonaktif jika baseball dilepaskan
        if (shootingScript != null)
        {
            shootingScript.SetHasGun(false); // Player tidak bisa menembak tanpa senjata
        }
    }
}
