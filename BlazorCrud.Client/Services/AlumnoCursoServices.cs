using InstitucionCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class AlumnoCursoServices: IAlumnoCursoService
    {
        private readonly HttpClient _http;

        public AlumnoCursoServices(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<AlumnoCursoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<AlumnoCursoDTO>>>("api/AlumnoCurso/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<AlumnoCursoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<AlumnoCursoDTO>>($"api/AlumnoCurso/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<int> Guardar(AlumnoCursoDTO alumnoCurso)
        {
            var result = await _http.PostAsJsonAsync("api/AlumnoCurso/Guardar", alumnoCurso);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(AlumnoCursoDTO alumnoCurso)
        {
            var result = await _http.PutAsJsonAsync($"api/AlumnoCurso/Editar/{alumnoCurso.IdAlumnoCurso}", alumnoCurso);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/AlumnoCurso/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }

     

      
    }
}
