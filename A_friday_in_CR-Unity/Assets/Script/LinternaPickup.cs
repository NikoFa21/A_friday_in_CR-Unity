using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinternaPickup : MonoBehaviour
{
    [Header("Referencias")]
    public Light linternaJugador;
    public GameObject mensajeRecogerUI;
    public GameObject mensajeTutorialUI;

    private bool jugadorCerca = false;
    public static bool linternaRecogida = false;

    void Start()
    {
        // La linterna empieza apagada
        linternaJugador.enabled = false;

        // Los mensajes empiezan ocultos
        mensajeRecogerUI.SetActive(false);
        mensajeTutorialUI.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca && !linternaRecogida && Input.GetKeyDown(KeyCode.E))
        {
            RecogerLinterna();
        }
    }

    private void RecogerLinterna()
    {
        linternaRecogida = true;

        // Desaparece el objeto del mapa
        gameObject.SetActive(false);

        // Ocultar mensaje de "E para recoger"
        mensajeRecogerUI.SetActive(false);

        // Mostrar mensaje tutorial
        mensajeTutorialUI.SetActive(true);

        // Ocultar el tutorial después de 5 segundos
        Invoke(nameof(EsconderTutorial), 5f);
    }

    private void EsconderTutorial()
    {
        mensajeTutorialUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !linternaRecogida)
        {
            jugadorCerca = true;
            mensajeRecogerUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !linternaRecogida)
        {
            jugadorCerca = false;
            mensajeRecogerUI.SetActive(false);
        }
    }
}