using InstitucionCrud.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorCrud.Client.Services
{
    public class CursoService: ICursoService
    {
        private readonly HttpClient _http;

        public CursoService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<CursoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<CursoDTO>>>("api/Curso/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<CursoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<CursoDTO>>($"api/Curso/Buscar/{id}"); 

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<int> Guardar(CursoDTO curso)
        {
            var result = await _http.PostAsJsonAsync("api/Curso/Guardar", curso);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }
        public async Task<int> Editar(CursoDTO curso)
        {
            var result = await _http.PutAsJsonAsync($"api/Curso/Editar/{curso.IdCurso}",curso);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Curso/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }

      
    }

}

  
           

       

    

