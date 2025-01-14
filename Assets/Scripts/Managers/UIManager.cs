using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Stats")]
    [SerializeField] private PersonajeStats stats;

    [Header("Paneles")]
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelTienda;
    [SerializeField] private GameObject panelCrafting;
    [SerializeField] private GameObject panelCorreo;
    [SerializeField] private GameObject panelCraftingInfo;
    [SerializeField] private GameObject panelCorreoInfo;
    [SerializeField] private GameObject panelActivos;
    [SerializeField] private GameObject panelActivoInfo;
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private GameObject panelInspectorQuests;
    [SerializeField] private GameObject panelPersonajeQuests;
    [SerializeField] private GameObject panelComputador;
    [SerializeField] private GameObject panelCmd;
    [SerializeField] private GameObject panelSnipeIt;
    [SerializeField] private GameObject panelServiceNow;
    [SerializeField] private GameObject panelActivoInforme;
    [SerializeField] private GameObject panelActivoInformePistas;
    [SerializeField] private GameObject panelActivoInformeConfirmacion;
    [SerializeField] private GameObject panelWallet;
    [SerializeField] private GameObject panelTiendaControles;
    [SerializeField] private GameObject panelTareas;
    [SerializeField] private GameObject panelEmpresa;
    [SerializeField] private GameObject panelPopUp;
    [SerializeField] private GameObject panelConfirmacionCierre;

    [SerializeField] private GameObject panelConfirmacionInstalacion;

    [Header("Paneles asociados al correo")]
    [SerializeField] private GameObject panelBandejaSalida;
    [SerializeField] private GameObject panelBandejaEntrada;
    [SerializeField] private GameObject panelInfoCorreo;
    public GameObject PanelComputador => panelComputador;

    [SerializeField] private GameObject panelApuntes;

    [SerializeField] private GameObject panelBotonesCiber;

    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private Image manaPlayer;
    [SerializeField] private Image expPlayer;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI nivelTMP;


    [Header("Ui_Personaje")]
    [SerializeField] private TextMeshProUGUI monedasTMP;
    [SerializeField] private TextMeshProUGUI bonificacionTMP;
    [SerializeField] private TextMeshProUGUI totalTMP;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI statDa�oTMP;
    [SerializeField] private TextMeshProUGUI statDefensaTMP;
    [SerializeField] private TextMeshProUGUI statCriticoTMP;
    [SerializeField] private TextMeshProUGUI statVelocidadTMP;
    [SerializeField] private TextMeshProUGUI statBloqueoTMP;
    [SerializeField] private TextMeshProUGUI statNivelTMP;
    [SerializeField] private TextMeshProUGUI statExpTMP;
    [SerializeField] private TextMeshProUGUI statExpRequeridaTMP;
    [SerializeField] private TextMeshProUGUI statExpTotalTMP;
    [SerializeField] private TextMeshProUGUI atributoFuerzaTMP;
    [SerializeField] private TextMeshProUGUI atributoInteligenciaTMP;
    [SerializeField] private TextMeshProUGUI atributoDestrezaTMP;
    [SerializeField] private TextMeshProUGUI atributoPuntosDisponiblesTMP;

    [Header("test")]
    [SerializeField] private CorreoLista correoLista;

    private float vidaActual;
    private float vidaMax;
    private float manaActual;
    private float manaMax;
    private float expActual;
    private float expRequeridaNuevoNivel;
    private int nivelActual;
    private int nivelMax;

    private void Start()
    {
        //de esta manera se resetea siempre al iniciar
        //amenazaLista.ResetearValores();
        correoLista.ResetearValores();
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarUIPersonaje();
        ActualizarPanelStats();

    }

    private void ActualizarUIPersonaje()
    {
        //Modificamos barra
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, vidaActual / vidaMax, 10f * Time.deltaTime);
        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount, manaActual / manaMax, 10f * Time.deltaTime);
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount, expActual / expRequeridaNuevoNivel, 10f * Time.deltaTime);
        vidaTMP.text = $"{vidaActual}/{vidaMax}";
        manaTMP.text = $"{manaActual}/{manaMax}";
        //Con esto verificamos si es el nivel maximo
        if (nivelActual == nivelMax)
        {
            expTMP.text = $" Nivel m�ximo";
            nivelTMP.text = $"Nivel m�ximo";
        }
        else
        {
            nivelTMP.text = $"Nivel {stats.Nivel}";
            expTMP.text = $"{((expActual / expRequeridaNuevoNivel) * 100):F2}% ";
        }
        monedasTMP.text = MonedasManager.Instance.MonedasTotales.ToString();

    }

    private void ActualizarPanelStats()
    {
        if (panelStats.activeSelf == false)
        {
            return;
        }
        if (stats.Nivel == nivelMax)
        {
            statDa�oTMP.text = stats.Da�o.ToString();
            statDefensaTMP.text = stats.Defensa.ToString();
            statCriticoTMP.text = $"{stats.PorcentajeCritico}%";
            statBloqueoTMP.text = $"{stats.PorcentajeBloqueo}%";
            statVelocidadTMP.text = stats.Velocidad.ToString();
            statNivelTMP.text = stats.Nivel.ToString();
            statExpTMP.text = "M�x";
            statExpRequeridaTMP.text = "M�x";
            statExpTotalTMP.text = stats.ExpTotal.ToString();
            atributoFuerzaTMP.text = stats.Fuerza.ToString();
            atributoInteligenciaTMP.text = stats.Inteligencia.ToString();
            atributoDestrezaTMP.text = stats.Destreza.ToString();
            atributoPuntosDisponiblesTMP.text = $"Puntos: {stats.PuntosDisponibles}";
        }
        else
        {
            statDa�oTMP.text = stats.Da�o.ToString();
            statDefensaTMP.text = stats.Defensa.ToString();
            statCriticoTMP.text = $"{stats.PorcentajeCritico}%";
            statBloqueoTMP.text = $"{stats.PorcentajeBloqueo}%";
            statVelocidadTMP.text = stats.Velocidad.ToString();
            statNivelTMP.text = stats.Nivel.ToString();
            statExpTMP.text = stats.ExpActual.ToString();
            statExpRequeridaTMP.text = stats.ExpRequeridaSiguienteNivel.ToString();
            statExpTotalTMP.text = stats.ExpTotal.ToString();
            atributoFuerzaTMP.text = stats.Fuerza.ToString();
            atributoInteligenciaTMP.text = stats.Inteligencia.ToString();
            atributoDestrezaTMP.text = stats.Destreza.ToString();
            atributoPuntosDisponiblesTMP.text = $"Puntos: {stats.PuntosDisponibles}";
        }

    }
    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax)
    {
        vidaActual = pVidaActual;
        vidaMax = pVidaMax;
    }
    public void ActualizarManaPersonaje(float pManaActual, float pManaMax)
    {
        manaActual = pManaActual;
        manaMax = pManaMax;
    }
    public void ActualizarExpPersonaje(float pManaActual, float pExpRequerida, int pNivelActual, int pNivelMax)
    {
        expActual = pManaActual;
        expRequeridaNuevoNivel = pExpRequerida;
        nivelActual = pNivelActual;
        nivelMax = pNivelMax;
    }

    #region Paneles
    public void AbrirCerrarPanelStats() {
        //Este metodo recibe un booleano como parametro, es por esto que se le pasa la negacion de la consulta si es que est� activo o no
        panelStats.SetActive(!panelStats.activeSelf);
    }

    public void AbrirPanelConfirmacionCierre() 
    {
        panelConfirmacionCierre.SetActive(true);
    }

    public void AbrirCerrarPanelConfirmacionInstalacion() 
    {
        panelConfirmacionInstalacion.SetActive(!panelConfirmacionInstalacion.activeSelf);
    }

    public void CerrarPanelConfirmacionCierre()
    {
        panelConfirmacionCierre.SetActive(false);
    }
    public void AbrirCerrarPanelWallet()
    {
        WalletManager.Instance.ActualizaNumeros();
        panelWallet.SetActive(!panelWallet.activeSelf);
    }
    public void AbrirCerrarPanelInventario() {
        panelInventario.SetActive(!panelInventario.activeSelf);
    }

    public void AbrirCerrarPanelEmpresa()
    {
        panelEmpresa.SetActive(!panelEmpresa.activeSelf);
    }


    public void AbrirPanelPopUp() 
    {
        panelPopUp.SetActive(false);
        panelPopUp.SetActive(true);
    }
    public void CerrarPanelPopUp() 
    {
        panelPopUp.SetActive(false);
    }

    public void AbrirCerrarPanelCmd()
    {
        panelCmd.SetActive(!panelCmd.activeSelf);
    }
    public void AbrirCerraPanelCorreoInfo(bool estado)
    {
        panelCorreoInfo.SetActive(estado);
    }

    public void AbrirCerrarPanelTarea() 
    {
        panelTareas.SetActive(!panelTareas.activeSelf);
    }

    public void AbrirCerraPanelActivoInfo(bool estado)
    {
        panelActivoInfo.SetActive(estado);
    }

    public void AbrirCerraPanelComputador(bool estado)
    {
        panelComputador.SetActive(estado);
    }

    public void AbrirPanelBandejaSalida()
    {
        panelBandejaEntrada.SetActive(false);
        panelInfoCorreo.SetActive(false);
        panelBandejaSalida.SetActive(true);
    }

    public void AbrirPanelBandejaEntrada()
    {
        panelBandejaEntrada.SetActive(true);
        panelInfoCorreo.SetActive(false);
        panelBandejaSalida.SetActive(false);
    }
    public void AbrirCerrarPanelSnipeIt()
    {
        panelSnipeIt.SetActive(!panelSnipeIt.activeSelf);
    }

    public void AbrirCerrarPanelServiceNow()
    {
        panelServiceNow.SetActive(!panelServiceNow.activeSelf);
    }

    public void AbrirCerrarPanelConfirmacionActivoInforme() 
    {
        
        panelActivoInformeConfirmacion.SetActive(!panelActivoInformeConfirmacion.activeSelf);
    }

    public void AbrirPanelConfirmacionActivoInforme() 
    {
        InformeActivosManager.Instance.HabilitaDeshabilitadaToggles(false);
        panelActivoInformeConfirmacion.SetActive(true);
    }

    public void CerrarPanelConfirmacionActivoInforme()
    {
        InformeActivosManager.Instance.HabilitaDeshabilitadaToggles(true);
        panelActivoInformeConfirmacion.SetActive(false);
    }

    public void AbrirCerrarPanelBotonesCiber(bool estado) 
    {
        panelBotonesCiber.SetActive(estado);
    }
    public void AbrirCerrarPanelInspectorQuests()
    {
        panelInspectorQuests.SetActive(!panelInspectorQuests.activeSelf);
    }

    public void AbrirCerrarPanelTienda() 
    {
        panelTienda.SetActive(!panelTienda.activeSelf);
    }

    public void AbrirCerrarPanelInformeActivo()
    {
        panelActivoInforme.SetActive(!panelActivoInforme.activeSelf);
    }

    public void AbrirCerrarPanelPersonajeQuests() 
    { 
        panelPersonajeQuests.SetActive(!panelPersonajeQuests.activeSelf);
    }
    public void AbrirPanelArgumentosActivoInforme() 
    {
        panelActivoInformePistas.SetActive(true);
    }

    public void AbrirPanelCrafting() 
    {
        panelCrafting.SetActive(true);
    }

    public void AbrirPanelCorreo()
    {
        panelCorreo.SetActive(!panelCorreo.activeSelf);
    }

    public void AbrirPanelActivos()
    {
        panelActivos.SetActive(!panelActivos.activeSelf);
    }
    public void AbrirPanelApuntes()
    {
        panelApuntes.SetActive(true);
    }

    public void CerrarPanelApuntes()
    {
        panelApuntes.SetActive(false);
    }

    public void AbrirCerrarPanelApuntes()
    {
        panelApuntes.SetActive(!panelApuntes.activeSelf);
    }

    public void AbrirCerrarPanelTiendaControles() 
    {
        panelTiendaControles.SetActive(!panelTiendaControles.activeSelf);
    }

    public void CerrarPanelActivos()
    {
        panelActivos.SetActive(false);
        AbrirCerraPanelActivoInfo(false);
    }
    public void CerrarPanelCorreo()
    {
        panelCorreo.SetActive(false);
        AbrirCerraPanelCorreoInfo(false);
    }

    public void CerarPanelCrafting() 
    {
        panelCrafting.SetActive(false);
        AbrirCerrarPanelCraftingInformacion(false);
    }

    public void AbrirCerrarPanelCraftingInformacion(bool estado) 
    {
        panelCraftingInfo.SetActive(estado);
    }

    public void AbrirPanelInteraccion(InteraccionExtraNPC tipoInteraccion) 
    { 
        switch (tipoInteraccion)
        {
            case InteraccionExtraNPC.Quests: 
                AbrirCerrarPanelInspectorQuests();
                break;

            case InteraccionExtraNPC.Tienda:
                AbrirCerrarPanelTienda();
                break;

            case InteraccionExtraNPC.Crafting:
                AbrirPanelCrafting();
                break;

            case InteraccionExtraNPC.Correo:
                AbrirPanelCorreo();
                break;

        }
    }

    public void AbrirCerrarPanelInspectorQuestConEstado(bool estado) 
    {
        panelInspectorQuests.SetActive(estado);
    }

    public bool EstaAbiertoPanelInspectorQuest() 
    {
        return panelInspectorQuests.activeSelf;
    }



    public void Cerrar()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }

    #endregion



}
