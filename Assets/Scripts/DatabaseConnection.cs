using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseConnection : MonoBehaviour
{
    string url= "https://dev-apisgp.sesims.com.br/api/Aluno/cadastrar";
    string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ByaW1hcnlzaWQiOiJhNGZmYzY3ZC0xYWFhLTQyMTgtYTZmNC0wOTllOThhMTdiY2EiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiV2VsbGluZ3RvblJvZHJpZ3VlcyIsImp0aSI6ImEyZTM5YzUxLThkODQtNGZmNC1hNDI4LWFhNjBjYjBmMGEzMSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJBZG1pblByb2Zlc3NvciIsIlVzdWFyaW9BbHVubyJdLCJleHAiOjE4NDMzMjY1NzksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9.kTicFi4v8cGpzyJKgmgBY5_W7yHDUFs94FWhBrAIiIY";
    /*public async Task MandarValoresAsync()
    {
       
        Debug.Log("entrou");
        var client = new HttpClient();

        var request = new HttpRequestMessage(HttpMethod.Post, "https://dev-apisgp.sesims.com.br/api/Aluno/cadastrar");
        Debug.Log(request);
        request.Headers.Add("Authorization", "Bearer " + token);
        
        var content = new StringContent(" {\r\n  \"nome_Trabalhador\": \"Jorge Almeida\",\r\n  \"naturalidade_Estado\": \"SP\",\r\n  \"naturalidade_Cidade\": \"São Paulo\",\r\n  \"data_Nascimento\": \"1990-06-04T14:35:52.540Z\",\r\n  \"sexo\": \"M\",\r\n  \"cpf\": \"25388449084\",\r\n  \"telefone\": \"(67)85764-4314\",\r\n  \"email\": \"tmeida@aaa.com\"\r\n}", null, "application/json");
        Debug.Log("dele");
        request.Content = content;

        var response = await client.SendAsync(request);
        Debug.Log("daaaale");
        response.EnsureSuccessStatusCode();

        Console.WriteLine(await response.Content.ReadAsStringAsync());
        Debug.Log("encerrou");
    }
    */
    private void Start()
    {
        StartCoroutine(MandarValoresAsync());
    }

    private IEnumerator MandarValoresAsync()
    {
        string url = "https://dev-apisgp.sesims.com.br/api/Aluno/cadastrar";
        string jsonContent = "{\"nome_Trabalhador\": \"Jorge Almeida\",\"naturalidade_Estado\": \"SP\",\"naturalidade_Cidade\": \"São Paulo\",\"data_Nascimento\": \"1990-06-04T14:35:52.540Z\",\"sexo\": \"M\",\"cpf\": \"25388449084\",\"telefone\": \"(67)85764-4314\",\"email\": \"tmeida@aaa.com\"}";

        UnityWebRequest request = UnityWebRequest.Post(url, jsonContent);
        request.SetRequestHeader("Authorization", "Bearer " + token);
        request.SetRequestHeader("Content-Type", "application/json");
        
        yield return request.SendWebRequest();
        Debug.Log("aaa");
        if (request.result == UnityWebRequest.Result.Success)
        {
            // A solicitação foi bem-sucedida
            Debug.Log("Resposta: " + request.downloadHandler.text);
        }
        else
        {
            // A solicitação falhou
            Debug.LogError("Erro na solicitação: " + request.error);
        }
    }


}
