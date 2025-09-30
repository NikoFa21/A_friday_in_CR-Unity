using UnityEngine;
using UnityEngine.UI;

public class PanelInteraccion : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject mensajeInteractuarUI;   // Texto "E para interactuar"
    public GameObject panelNumpadUI;          // Canvas del numpad
    public Text displayCodigo;                // Donde se muestra el código digitado
    public Light luzPrincipal;                // Luz que enciende el mapa

    private bool jugadorCerca = false;
    private string codigoIngresado = "";
    private string codigoCorrecto = "7030";

    void Start()
    {
        mensajeInteractuarUI.SetActive(false);
        panelNumpadUI.SetActive(false);
        luzPrincipal.enabled = false; // empieza apagada
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            AbrirPanel();
        }
    }

    private void AbrirPanel()
    {
        panelNumpadUI.SetActive(true);
        mensajeInteractuarUI.SetActive(false);

        // Bloquear el movimiento del jugador si querés
        Time.timeScale = 0f;
    }

    public void AgregarNumero(string numero)
    {
        if (codigoIngresado.Length < 6) // Máximo 6 dígitos
        {
            codigoIngresado += numero;
            displayCodigo.text = codigoIngresado;
        }
    }

    public void Borrar()
    {
        if (codigoIngresado.Length > 0)
        {
            codigoIngresado = codigoIngresado.Substring(0, codigoIngresado.Length - 1);
            displayCodigo.text = codigoIngresado;
        }
    }

    public void VerificarCodigo()
    {
        if (codigoIngresado == codigoCorrecto)
        {
            luzPrincipal.enabled = true; // enciende la luz del mapa
            CerrarPanel();
        }
        else
        {
            codigoIngresado = "";
            displayCodigo.text = "";
        }
    }

    private void CerrarPanel()
    {
        panelNumpadUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            mensajeInteractuarUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            mensajeInteractuarUI.SetActive(false);
        }
    }
}