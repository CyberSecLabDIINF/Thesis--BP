using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public static Action<Quest> EventoQuestCompletado;

    [Header("Info")]
    public string Nombre;
    public string ID;
    public int CantidadObjetivo;

    [Header("Descripcion")]
    [TextArea] public string Descripcion;

    [Header("Recompensas")]
    public int RecompensaOro;
    public float RecompensaExp;
    public QuesRecompensaItem RecompensaItem;

    [HideInInspector] public int CantidadActual;
    [HideInInspector] public bool QuestCompletadoCheck;

    [HideInInspector] public bool QuestAceptado;

    public void AņadirProgreso(int cantidad) 
    {
        CantidadActual += cantidad;
        VerificarQuestCompletado();
    }

    private void VerificarQuestCompletado() 
    {
        if (CantidadActual >= CantidadObjetivo) 
        {
            CantidadActual = CantidadObjetivo;
            QuestCompletado();
        }
    }

    private void QuestCompletado() 
    {
        if (QuestCompletadoCheck) 
        {
            return;
        }
        QuestCompletadoCheck = true;
        EventoQuestCompletado?.Invoke(this);
    }

    public void ResetQuest() 
    {
        QuestCompletadoCheck = false;
        CantidadActual = 0;
    }

}

[Serializable]
public class QuesRecompensaItem 
{
    public InventarioItem Item;
    public int Cantidad;
}
