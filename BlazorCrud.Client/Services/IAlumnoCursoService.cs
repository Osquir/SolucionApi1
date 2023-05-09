using InstitucionCrud.Shared;

namespace BlazorCrud.Client.Services
{
    public interface IAlumnoCursoService
    {
        Task<List<AlumnoCursoDTO>> Lista();

        Task<AlumnoCursoDTO> Buscar(int id);

        Task<int> Guardar(AlumnoCursoDTO alumnoCurso);

        Task<int> Editar(AlumnoCursoDTO alumno);

        Task<bool> Eliminar(int id);
    }
}
