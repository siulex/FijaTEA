using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaritasGustado : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public PuntuacionFinal gestorEventos;

    public void PuntuarConID()
    {
        gestorEventos.puntuar(id);
    }
}
