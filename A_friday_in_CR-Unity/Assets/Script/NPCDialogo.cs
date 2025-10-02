using UnityEngine;
using UnityEngine.UI; // si usas Text normal
// using TMPro; // descomenta esto si usás TextMeshPro

public class NPCDialogo : MonoBehaviour
{
    [Header("Referencias de Canvas")]
    public GameObject canvasNPC;
    public GameObject canvasNPCInteractuar;  // Primer mensaje al acercarse
    public GameObject canvasDialogoNPC;      // Dialogo del NPC
    public GameObject canvasMisionLinterna;  // Misión: Encuentra la linterna
    

    [Header("Texto del NPC")]
    public Text textoDialogo; 
    // Si usas TMP: public TMP_Text textoDialogo;

    private bool jugadorCerca = false;
    private bool dialogoActivo = false;

    private string mensajeNPC = "Hola Nico. Se acaba de cortar la luz. " +
        "Como verás estoy usando una linterna. Sé que hay una por alguna parte del mapa.\n\n" +
        "Seguí las luces de emergencia que seguramente vas a poder conseguirla.\n\n" +
        "Una vez que encuentres la linterna vas a poder encontrar el panel eléctrico para devolver la luz.";

    void Start()
    {
        canvasNPC.SetActive(false);
        canvasNPCInteractuar.SetActive(false);
        canvasDialogoNPC.SetActive(false);
        canvasMisionLinterna.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E) && !dialogoActivo)
        {
            MostrarDialogo();
        }

        // Si el dialogo está activo, cualquier tecla lo cierra
        if (dialogoActivo && Input.anyKeyDown)
        {
            CerrarDialogo();
            FindAnyObjectByType<MissionManager>().LlegoAlNPC();
        }
    }

    private void MostrarDialogo()
    {
        canvasDialogoNPC.SetActive(true);
        textoDialogo.text = mensajeNPC;
        dialogoActivo = true;
        canvasNPCInteractuar.SetActive(false);
    }

    private void CerrarDialogo()
    {
        canvasDialogoNPC.SetActive(false);
        canvasMisionLinterna.SetActive(true); // muestra "Encuentra la linterna"
        dialogoActivo = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            canvasNPCInteractuar.SetActive(true);
            canvasNPC.SetActive(false);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            canvasNPCInteractuar.SetActive(false);
        }
    }
}