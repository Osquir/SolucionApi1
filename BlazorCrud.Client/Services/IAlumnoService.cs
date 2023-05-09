using InstitucionCrud.Shared;

namespace BlazorCrud.Client.Services
{
    public interface IAlumnoService
    {
        Task<List<AlumnoDTO>> Lista();
        Task<AlumnoDTO> Buscar(int id);

        Task<int> Guardar(AlumnoDTO alumno);

        Task<int> Editar(AlumnoDTO alumno);

        Task<bool> Eliminar(int id);
    }
}
