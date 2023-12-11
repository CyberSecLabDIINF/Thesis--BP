using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoTiempo;
    public float tiempoRestante;
    public bool inicioTemporizador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IniciarCountdown();
    }

    public void IniciarCountdown() 
    {
        if (inicioTemporizador)
        {
            if (tiempoRestante > 0)
            {

                tiempoRestante -= Time.deltaTime;
            }
            if (tiempoRestante < 0)
            {
                tiempoRestante = 0;
            }
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);
            textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    public void PausarTemporizador() 
    {
        inicioTemporizador = false;
    }
}