using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventarioUI : Singleton<InventarioUI>
{
    [Header("Panel Inventario Descripcion")]

    [SerializeField] private GameObject panelInventarioDescripcion;
    [SerializeField] private Image iconoItem;
    [SerializeField] private TextMeshProUGUI nombreItem;
    [SerializeField] private TextMeshProUGUI descripcionItem;

    [SerializeField] private InventarioSlot slotPrefab;
    [SerializeField] private Transform contenedor;

    public int IndexSlotInicialPorMover { get; private set; }
    public InventarioSlot SlotSeleccionado { get; private set; }

    List<InventarioSlot> slotsDisponibles = new List<InventarioSlot>();
    // Start is called before the first frame update
    void Start()
    {
        InicializarInventario();
        IndexSlotInicialPorMover = -1;
    }

    private void Update()
    {
        ActualizarSlotSeleccionado();
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (SlotSeleccionado != null)
            {
                IndexSlotInicialPorMover = SlotSeleccionado.Index;
            }
        }
    }

    //se agregan los slots al contenedor
    private void InicializarInventario()
    {
        for (int i = 0; i < Inventario.Instance.NumeroDeSlots; i++)
        {
            InventarioSlot  nuevoSlot = Instantiate(slotPrefab, contenedor);
            nuevoSlot.Index = i;
            slotsDisponibles.Add(nuevoSlot);
        }
    }

    //obtenemos el slot que seleccionamos.
    private void ActualizarSlotSeleccionado() 
    {
        GameObject goSeleccionado = EventSystem.current.currentSelectedGameObject;
        if (goSeleccionado == null)
        {
            return;
        }

        InventarioSlot slot = goSeleccionado.GetComponent<InventarioSlot>();
        if (slot != null)
        {
            SlotSeleccionado = slot;
        }
    }
    public void DibujarItemEnInventario(InventarioItem itemPorAņadir , int cantidad, int itemIndex) 
    {
        InventarioSlot slot = slotsDisponibles[itemIndex];
        if (itemPorAņadir != null )
        {
            slot.ActivarSlotUI(true);
            slot.ActualizarSlot(itemPorAņadir, cantidad);
        }
        else
        {
            slot.ActivarSlotUI(false);
        }
    }


    private void ActualizarInventarioDescripcion(int index)
    {
        if (Inventario.Instance.ItemsInventario[index] != null)
        {
            iconoItem.sprite = Inventario.Instance.ItemsInventario[index].icono;
            nombreItem.text = Inventario.Instance.ItemsInventario[index].nombre;
            descripcionItem.text = Inventario.Instance.ItemsInventario[index].descripcion;
            panelInventarioDescripcion.SetActive(true);
        }
        else
        {
            panelInventarioDescripcion.SetActive(false);
        }
    }

    public void UsarItem() 
    {
        if (SlotSeleccionado != null)
        {
            SlotSeleccionado.SlotUsarItem();
            SlotSeleccionado.SeleccionarSlot();
        }
    }

    public void EquiparItem() 
    {
        if (SlotSeleccionado != null)
        {
            SlotSeleccionado.SlotEquiparItem();
            SlotSeleccionado.SeleccionarSlot();
        }
    }

    public void RemoverItem()
    {
        if (SlotSeleccionado != null)
        {
            SlotSeleccionado.SlotRemoverItem();
            SlotSeleccionado.SeleccionarSlot();
        }
    }


    #region Evento

    private void SlotInteraccionRespuesta(TipoDeInteraccion tipo, int index)
    {
        if (tipo == TipoDeInteraccion.Click)
        {
            ActualizarInventarioDescripcion(index);
        }
    }
    private void OnEnable()
    {
        InventarioSlot.EventoSlotInteraccion += SlotInteraccionRespuesta;
    }
    private void OnDisable()
    {
        InventarioSlot.EventoSlotInteraccion -= SlotInteraccionRespuesta;
    }

    #endregion

    
}
