using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootButton : MonoBehaviour
{
    [SerializeField] private Image itemIcono;
    [SerializeField] private TextMeshProUGUI itemNombre;

    public DropItem ItemPorRecoger { get; set; }
    public void ConfigurarLootItem(DropItem dropItem) 
    {
        ItemPorRecoger = dropItem;
        itemIcono.sprite = dropItem.Item.icono;
        itemNombre.text = $"{dropItem.Item.nombre} x {dropItem.Cantidad}";
    }

    public void RecogerItem() 
    {
        if (ItemPorRecoger == null) 
        {
            return;
        }

        Inventario.Instance.AņadirItems(ItemPorRecoger.Item, ItemPorRecoger.Cantidad);
        ItemPorRecoger.ItemRecogido = true;
        Destroy(gameObject);
    }
}
