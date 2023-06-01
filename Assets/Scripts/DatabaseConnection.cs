using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class DatabaseConnection : MonoBehaviour
{
    string path = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/1a27c350-bdf0-41f5-ab23-c752082c54bf/df3qto1-592eaae9-b3f6-4545-ab03-42d2015915ed.jpg/v1/fill/w_1192,h_670,q_70,strp/luffy_gear_5_wallpaper_by_jabamisora_df3qto1-pre.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NzIwIiwicGF0aCI6IlwvZlwvMWEyN2MzNTAtYmRmMC00MWY1LWFiMjMtYzc1MjA4MmM1NGJmXC9kZjNxdG8xLTU5MmVhYWU5LWIzZjYtNDU0NS1hYjAzLTQyZDIwMTU5MTVlZC5qcGciLCJ3aWR0aCI6Ijw9MTI4MCJ9XV0sImF1ZCI6WyJ1cm46c2VydmljZTppbWFnZS5vcGVyYXRpb25zIl19.Nk1M6oQNh9z7mqBrJ2bZisKjtH1AxCj71H3glxv-9Vk";
    [SerializeField] private Image image;
    public int fase;
    string url= "http://dev-apisgp.sesims.com.br/api/Aluno/cadastrar";
    HandleNextStep next;
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
        next = FindObjectOfType<HandleNextStep>();
        StartCoroutine(Imagemm());
        StartCoroutine(MandarValoresAsync());
    }
    private IEnumerator Imagemm()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            image.sprite = sprite;
            //end show Image in texture 2D
        }
    }

    private IEnumerator MandarValoresAsync()
    {
        
        string jsonContent = "{\"nome_Trabalhador\":%20\"Jorge Almeida\",\"naturalidade_Estado\":%20\"SP\",\"naturalidade_Cidade\":%20\"São Paulo\",\"data_Nascimento\":%20\"1990-06-04T14:35:52.540Z\",\"sexo\":%20\"M\",\"cpf\":%20\"25388449084\",\"telefone\":%20\"(67)85764-4314\",\"email\":%20\"tmeida@aaa.com\"}";
        UnityWebRequest request = UnityWebRequest.Post(url, jsonContent);
        request.SetRequestHeader("Authorization", "Bearer%20" + token);
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
  
        if (request.result == UnityWebRequest.Result.Success)
        {
            // A solicitação foi bem-sucedida
            Debug.Log("Resposta: " + request.downloadHandler.text);
            next.inputField.text = "acerto";
        }
        else
        {
            // A solicitação falhou
            Debug.LogError("Erro na solicitação: " + request.error);
            next.inputField.text = "erro";

        }
    }


}
