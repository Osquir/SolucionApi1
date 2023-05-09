using InstitucionCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly HttpClient _http;

        public AlumnoService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<AlumnoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<AlumnoDTO>>>("api/Alumnos/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);


        }
        public async Task<AlumnoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<AlumnoDTO>>($"api/Alumnos/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<int> Guardar(AlumnoDTO alumno)
        {

            var result = await _http.PostAsJsonAsync("api/Alumnos/Guardar", alumno);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);

        }
       
       
        public async Task<int> Editar(AlumnoDTO alumno)
        {
            var result = await _http.PutAsJsonAsync($"api/Alumnos/Editar/{alumno.IdAlumno}", alumno);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Alumnos/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }

       
    }
}
