using UnityEngine;

public class SkullWinGame : MonoBehaviour
{
    public GameObject winCanvas;
    private bool hasWon = false;
    private Transform cameraTransform;
    
    void Start()
    {
        // Cari main camera
        cameraTransform = Camera.main.transform;
        
        // Pastikan canvas hidden di awal
        if (winCanvas == null)
        {
            Debug.LogError("WIN CANVAS BELUM DI-ASSIGN!");
        }
        else
        {
            winCanvas.SetActive(false);
        }
    }
    
    void LateUpdate()
    {
        // Kalau udah menang, canvas ikut kamera
        if (hasWon && winCanvas != null && cameraTransform != null)
        {
            // Posisi canvas di depan kamera
            Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * 2f;
            winCanvas.transform.position = targetPosition;
            
            // Canvas selalu ngadap kamera
            winCanvas.transform.LookAt(winCanvas.transform.position + cameraTransform.rotation * Vector3.forward,
                                      cameraTransform.rotation * Vector3.up);
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        // Cek apakah skull masuk ExitZone
        if (other.CompareTag("ExitZone") && !hasWon)
        {
            hasWon = true;
            
            if (winCanvas != null)
            {
                winCanvas.SetActive(true);
                Debug.Log("YOU WIN!");
            }
        }
    }
}