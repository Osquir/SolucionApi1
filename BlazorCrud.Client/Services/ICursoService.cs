using InstitucionCrud.Shared;

namespace BlazorCrud.Client.Services
{
    public interface ICursoService
    {
        Task<List<CursoDTO>> Lista();
        Task<CursoDTO> Buscar(int id);

        Task<int> Guardar(CursoDTO curso);

        Task<int> Editar(CursoDTO curso);

        Task<bool> Eliminar(int id);
    }
}
