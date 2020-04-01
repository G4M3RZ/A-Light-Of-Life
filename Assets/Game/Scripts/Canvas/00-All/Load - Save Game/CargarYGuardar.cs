using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class CargarYGuardar : MonoBehaviour {

    private string rutaArchivo;
    static bool _primeraVez = true;

    private void Start()
    {
        rutaArchivo = Application.persistentDataPath + "/datos.dat";
        if (_primeraVez)
        {
            Cargar();
            _primeraVez = false;
        }
    }
    private void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/datos.dat";
        if (_primeraVez)
        {
            Cargar();
            _primeraVez = false;
        }
    }

    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(rutaArchivo);
        DatosAGuardar datos = new DatosAGuardar(LoadAndSaveLevel._nivelDesbloqueado);
        bf.Serialize(file, datos);
        file.Close();
    }
    public void Cargar()
    {
        if (File.Exists(rutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);
            DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);
            LoadAndSaveLevel._nivelDesbloqueado = datos.nivelesDesbloqueados;
        }
        else
        {
            LoadAndSaveLevel._nivelDesbloqueado = 0;
        }
    }
}
[System.Serializable]
class DatosAGuardar
{
    public int nivelesDesbloqueados;

    public DatosAGuardar(int nivelesDesbloqueados_)
    {
        nivelesDesbloqueados = nivelesDesbloqueados_;
    }
}