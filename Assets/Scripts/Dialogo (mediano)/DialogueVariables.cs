using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;
public class DialogueVariables
{

    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    //Como el archivo globals es un include no se compila por si solo, por ende se utiliza esta funcion para que se compile 
    /*
    public DialogueVariables(string direccionArchivoGlobals) 
    {
        string inkFileContents = File.ReadAllText(direccionArchivoGlobals);
        Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
        Story globalVariablesStory = compiler.Compile();


        //inicializamos el diccionario

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string nombre in globalVariablesStory.variablesState) 
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(nombre);
            variables.Add(nombre, value);
           // Debug.Log("Se inicializ� la variable global dialogue: "+ nombre + " = " + value);
        }

    }*/
    public DialogueVariables(TextAsset loadGlobalsJSON)
    {
        // create the story
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);

        // initialize the dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            //Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
        
    }

    public void StartListening(Story story) 
    {
        //debe ir antes del metodo listener
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story) 
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    private void VariableChanged(string nombre, Ink.Runtime.Object value) 
    {
        //solo almacenar variables que han sido inicializadas desde el archivo globals ink
        //Debug.Log("La variable cambi�: " + nombre + " = " + value);
        if (variables.ContainsKey(nombre))
        {
            variables.Remove(nombre);
            variables.Add(nombre, value);

        }
    }

    private void VariablesToStory(Story story) 
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables) 
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }

    }


    //Funcion que cambia el valor de una variable de false a verdadero
    public void CambiaVariable(string nombreVariable, TextAsset loadGlobalsJSON) 
    {
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);
        variables[nombreVariable] = globalVariablesStory.variablesState.GetVariableWithName("verdadero");

    }

    public void CambiaVariablePostCorreo(string nombreVariable, TextAsset loadGlobalsJSON) 
    {
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);
        variables[nombreVariable] = globalVariablesStory.variablesState.GetVariableWithName("once");
    }


   

}
