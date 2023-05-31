/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour {
    [Header("ValoresSGP")]
    [SerializeField] string nome, email, cidade, estado, cpf, telefone, sexo;
    DateTime nascimento;
    HandleNextStep valores;
    
    public void Iniciar() {
        valores = FindObjectOfType<HandleNextStep>();
        nome = valores.nome;
        email = valores.email;
        cidade = valores.cidade;
        estado = valores.estado;
        cpf = valores.cpf;
        telefone = valores.telefone;
        nascimento = valores.nascimento;
        sexo = valores.sexo;
        string jsonString = PlayerPrefs.GetString("Json");
        if(jsonString==null)
            AddHighscoreEntry("Robierto", "scorro", "bela vista", "MS", "1213132131", "666", nascimento, "helicoptero");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        AddHighscoreEntry(nome, email, cidade, estado, cpf, telefone, nascimento, sexo);
    }

    
    private void AddHighscoreEntry(string nome, string email, string cidade, string estado, string cpf, string telefone, DateTime nascimento, string sexo) {
        // Create HighscoreEntry
        AlunoDto highscoreEntry = new AlunoDto { Nome_Trabalhador = nome, Email = email, Naturalidade_Cidade=cidade, Naturalidade_Estado=estado, Cpf=cpf, Telefone=telefone, Data_Nascimento=nascimento, Sexo=sexo };
        
        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("Json");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            highscores = new Highscores() {
                highscoreEntryList = new List<AlunoDto>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("Json", json);
        PlayerPrefs.Save();
    }
    
    private class Highscores {
        public List<AlunoDto> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable] 
    private class AlunoDto
    {
        public string Nome_Trabalhador { get; set; }
        public string Naturalidade_Estado { get; set; }
        public string Naturalidade_Cidade { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }
    }

}
