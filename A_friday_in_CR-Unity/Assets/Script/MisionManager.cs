using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    [Header("Canvases")]
    public GameObject canvasControles;       // Tutorial W,A,S,D
    public GameObject canvasNPC;             // Dirígete al NPC
    public GameObject canvasDialogoNPC;      // Dialogo con el NPC
    public GameObject panelMisionLinterna;   // Encuentra la linterna
    public GameObject panelMisionPanelElec;  // Encuentra el panel eléctrico

    private bool w, a, s, d; // para saber si apretó todas

    private void Start()
    {
        // Inicializamos
        canvasControles.SetActive(true);
        canvasNPC.SetActive(false);
        canvasDialogoNPC.SetActive(false);
        panelMisionLinterna.SetActive(false);
        panelMisionPanelElec.SetActive(false);
    }

    private void Update()
    {
        // ✅ Controlar tutorial de movimiento
        if (canvasControles.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.W)) w = true;
            if (Input.GetKeyDown(KeyCode.A)) a = true;
            if (Input.GetKeyDown(KeyCode.S)) s = true;
            if (Input.GetKeyDown(KeyCode.D)) d = true;

            if (w && a && s && d)
            {
                canvasControles.SetActive(false);
                canvasNPC.SetActive(true); // Aparece misión de ir al NPC
            }
        }

        // ✅ Cerrar diálogo con tecla
        if (canvasDialogoNPC.activeSelf && Input.anyKeyDown)
        {
            canvasDialogoNPC.SetActive(false);
            panelMisionLinterna.SetActive(true); // Activa misión linterna
        }
    }

    // ✅ Estos métodos se llaman desde otros scripts (colisiones)
    public void LlegoAlNPC()
    {
        canvasNPC.SetActive(false);
        canvasDialogoNPC.SetActive(true);
    }

    public void LlegoALinterna()
    {
        panelMisionLinterna.SetActive(false);
        panelMisionPanelElec.SetActive(true);
    }

    public void LlegoAlPanelElectrico()
    {
        panelMisionPanelElec.SetActive(false);
        // Podés disparar siguiente misión o terminar juego
    }
}