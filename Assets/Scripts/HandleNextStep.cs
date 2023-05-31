using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using System.Text.RegularExpressions;

public class HandleNextStep : MonoBehaviour
{
    public GameObject IrisFala_01,
                      IrisFala_02,
                      IrisFala_03,
                      IrisFala_04,
                      IrisFala_05,
                      IrisFala_06,
                      IrisFala_07,
                      IrisFala_08,
                      IrisFala_09;
    public GameObject parentObject;
    public TMP_InputField inputField;
    public TMP_Text buttonText;
    public int IrisIndex = 0;
    public bool editMode = true;
    [Header("Valores Para o SGP")]
    [SerializeField] public string nome, email, cidade, estado, cpf, telefone, sexo;
    public DateTime nascimento;
    HighscoreTable SalvarJson;
    DatabaseConnection conecta;
    private void Awake()
    {

    }

    public void Start()
    {
        SalvarJson = FindObjectOfType<HighscoreTable>();
        Debug.Log(PlayerPrefs.GetString("Json"));
        conecta = FindObjectOfType<DatabaseConnection>();
        //conecta.MandarValoresAsync();
        inputField.characterValidation = TMP_InputField.CharacterValidation.Name;
    }

    public void HandleIrisIndex()
    {
        if (!editMode)
        {
            if (IrisIndex < 9)
            {
                if (inputField.text != string.Empty || IrisIndex == 8)
                {
                    if (IrisIndex == 0)
                    {
                        nome = inputField.text;
                        RemoveAllListners();
                        CreateMessage(IrisFala_01, parentObject);
                        inputField.characterLimit = 14;
                        inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
                        inputField.onValueChanged.AddListener(OnCPFValueChanged);
                    }
                    if (IrisIndex == 1)
                    {
                        cpf = inputField.text;
                        RemoveAllListners();
                        CreateMessage(IrisFala_02, parentObject);
                        inputField.characterLimit = 14;
                        inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
                        inputField.onValueChanged.AddListener(OnPhoneValueChanged);
                    }
                    if (IrisIndex == 2)
                    {
                        telefone = inputField.text;
                        RemoveAllListners();
                        CreateMessage(IrisFala_03, parentObject);
                        inputField.characterLimit = 10;
                        inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
                        inputField.onValueChanged.AddListener(OnDateValueChanged);
                    }
                    if (IrisIndex == 3)
                    {
                        inputField.text = System.String.Format("{0:yyyy-MM}", nascimento);
                        RemoveAllListners();
                        CreateMessage(IrisFala_04, parentObject);
                        inputField.characterLimit = 1;
                        inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
                        inputField.onValueChanged.AddListener(OnSexValueChanged);
                    }
                    if (IrisIndex == 4)
                    {
                        string sex = inputField.text;
                        if (sex == "1")
                            sexo = "Masculino";
                        else
                            sexo = "Feminino";
                        RemoveAllListners();
                        CreateMessage(IrisFala_05, parentObject);
                        inputField.characterLimit = -1;
                        inputField.characterValidation = TMP_InputField.CharacterValidation.Name;
                    }
                    if (IrisIndex == 5)
                    {
                        estado = inputField.text;
                        RemoveAllListners();
                        CreateMessage(IrisFala_06, parentObject);
                        inputField.characterValidation = TMP_InputField.CharacterValidation.Name;
                    }
                    if (IrisIndex == 6)
                    {
                        cidade = inputField.text;
                        RemoveAllListners();
                        inputField.characterValidation = TMP_InputField.CharacterValidation.EmailAddress;
                        CreateMessage(IrisFala_07, parentObject);
                    }
                    if (IrisIndex == 7)
                    {
                        email = inputField.text;
                        inputField.gameObject.SetActive(false);
                        SalvarJson.Iniciar();
                        Debug.Log(PlayerPrefs.GetString("Json"));
                        //conecta.MandarValoresAsync();
                        CreateMessage(IrisFala_08, parentObject);
                        buttonText.text = "Continuar";
                    }
                    if (IrisIndex == 8)
                    {
                        CreateMessage(IrisFala_09, parentObject);
                    }
                    IrisIndex++;
                }
            }
        }
    }
    public void CreateMessage(GameObject gameObject, GameObject parent)
    {
        gameObject = Instantiate(gameObject, Vector3.zero, Quaternion.identity, parent.transform);
        inputField.text = string.Empty;

    }

    private void OnCPFValueChanged(string newValue)
    {
        inputField.text = ApplyCPFFormat(newValue);
        inputField.stringPosition = inputField.text.Length;
        inputField.ForceLabelUpdate();
    }

    private string ApplyCPFFormat(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", ""); // Remove caracteres especiais
        ValidaCpf(cpf);
        if (cpf.Length > 3)
            cpf = cpf.Insert(3, ".");

        if (cpf.Length > 7)
            cpf = cpf.Insert(7, ".");

        if (cpf.Length > 11)
            cpf = cpf.Insert(11, "-");

        return cpf;
    }
    public static bool ValidaCpf(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };



        cpf = cpf.Trim().Replace(".", "").Replace("-", "");
        Debug.Log(cpf.Length);
        if (cpf.Length != 11)
            return false;



        if (!cpf.All(Char.IsDigit))
            return false;


        for (int j = 0; j < 10; j++)
            if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                return false;



        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;



        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];



        int resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;



        string digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];



        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;



        digito = digito + resto.ToString();


        Debug.Log(cpf.EndsWith(digito));
        return cpf.EndsWith(digito);
    }

    private void OnPhoneValueChanged(string newValue)
    {
        inputField.text = ApplyPhoneFormat(newValue);
        ValidaTelefone(newValue);
        inputField.stringPosition = inputField.text.Length;
        inputField.ForceLabelUpdate();
    }
    
    public bool ValidaTelefone(string telefone)
    {
        Regex Rgx = new Regex(@"^\(\d{2}\)\d{5}-\d{4}$"); //formato (XX)XXXXX-XXXX
        if (!Rgx.IsMatch(telefone))
            return false;
        else
            return true;
    }
    

    private string ApplyPhoneFormat(string phone)
    {
        phone = phone.Replace("(", "").Replace(")", "").Replace("-", ""); // Remove caracteres especiais

        if (phone.Length > 0)
            phone = phone.Insert(0, "(");

        if (phone.Length > 3)
            phone = phone.Insert(3, ")");

        if (phone.Length > 8)
            phone = phone.Insert(8, "-");

        return phone;
    }

    private void OnDateValueChanged(string newValue)
    {
        inputField.text = ApplyDateFormat(newValue);
        inputField.stringPosition = inputField.text.Length;
        inputField.ForceLabelUpdate();
    }

    private string ApplyDateFormat(string date)
    {
        date = date.Replace("/", ""); // Remove caracteres especiais

        if (date.Length > 2)
            date = date.Insert(2, "/");

        if (date.Length > 5)
            date = date.Insert(5, "/");

        return date;
    }
    private void OnSexValueChanged(string newValue)
    {
        inputField.text = ApplySexFormat(newValue);
        inputField.stringPosition = inputField.text.Length;
        inputField.ForceLabelUpdate();
    }

    private string ApplySexFormat(string sex)
    {
        sex = sex.Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("-", "").Replace("0", ""); // Remove caracteres especiais

        return sex;
    }

    private void RemoveAllListners()
    {
        inputField.onValueChanged.RemoveListener(OnCPFValueChanged);
        inputField.onValueChanged.RemoveListener(OnPhoneValueChanged);
        inputField.onValueChanged.RemoveListener(OnDateValueChanged);
        inputField.onValueChanged.RemoveListener(OnSexValueChanged);
    }

    public void RemoveMasksEdit(int index)
    {

        RemoveAllListners();
        if (index == 1)
        {
            
            RemoveAllListners();
            inputField.characterLimit = -1;
            inputField.characterValidation = TMP_InputField.CharacterValidation.Name;
           
        }
        if (index == 2)
        {
            inputField.characterLimit = 14;
            inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
            RemoveAllListners();
            inputField.onValueChanged.AddListener(OnCPFValueChanged);
            
        }
        if (index == 3)
        {
            inputField.characterLimit = 14;
            RemoveAllListners();
            inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
            inputField.onValueChanged.AddListener(OnPhoneValueChanged);
        }
        if (index == 4)
        {
            inputField.characterLimit = 10;
            RemoveAllListners();
            inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
            inputField.onValueChanged.AddListener(OnDateValueChanged);
        }
        if (index == 5)
        {
            inputField.characterLimit = 1;
            RemoveAllListners();
            inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
            inputField.onValueChanged.AddListener(OnSexValueChanged);
            
        }
        if (index == 6 || index == 7)
        {
            inputField.characterLimit = -1;
            inputField.characterValidation = TMP_InputField.CharacterValidation.Name;
            RemoveAllListners();
            
        }
        if (index == 8)
        {
            inputField.characterValidation = TMP_InputField.CharacterValidation.EmailAddress;
            
        }

    }

}
