using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "Amenazas")]
public class AmenazaLista : ScriptableObject
{
    public List<Amenaza> Amenazas;


    public void AņadirAmenaza(Amenaza amenaza) 
    {
        Amenazas.Add(amenaza);
    }
}
