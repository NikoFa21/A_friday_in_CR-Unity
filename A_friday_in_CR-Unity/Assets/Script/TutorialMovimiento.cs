using UnityEngine;

public class TutorialMovimiento : MonoBehaviour
{
    public GameObject canvasControles; // El Canvas con las teclas
    public GameObject canvasNPC;
    private bool wPresionada = false;
    private bool aPresionada = false;
    private bool sPresionada = false;
    private bool dPresionada = false;

    void Start()
    {
        if (canvasNPC != null)
            canvasNPC.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) wPresionada = true;
        if (Input.GetKeyDown(KeyCode.A)) aPresionada = true;
        if (Input.GetKeyDown(KeyCode.S)) sPresionada = true;
        if (Input.GetKeyDown(KeyCode.D)) dPresionada = true;

        // Cuando las 4 se presionen, ocultar el Canvas
        if (wPresionada && aPresionada && sPresionada && dPresionada)
        {
            if (canvasControles != null)
                canvasControles.SetActive(false);
            if (canvasNPC != null)
                canvasNPC.SetActive(true);
            enabled = false;
        }
    }
}