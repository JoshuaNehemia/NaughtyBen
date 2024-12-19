using UnityEngine;

public class DestroyObject : MonoBehaviour
{
   /* [SerializeField] private float interactionRange = 3f; // Jarak interaksi
    [SerializeField] private string targetTag = "GameStairs"; // Tag objek yang bisa dihancurkan
    void Update()
    {
        // Deteksi jika tombol kiri mouse ditekan
        if (Input.GetMouseButtonDown(0))
        {
            TryDestroyObject();
        }
    }

    private void TryDestroyObject()
    {
        // Raycast dari posisi karakter ke arah depan
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Periksa apakah ray mengenai sesuatu dalam jarak tertentu
        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            // Hancurkan objek yang terkena
            Destroy(hit.collider.gameObject);
            Debug.Log("Objek dihancurkan: " + hit.collider.gameObject.name);
        }
        else
        {
            Debug.Log("Tidak ada objek yang terkena!");
        }
    }
   */
}
