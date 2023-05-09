using ApiCrud.Server.Models;
using InstitucionCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly InstitucionContext _dbcontext;
        public CursoController(InstitucionContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<CursoDTO>>();
            var listaCursoDTO = new List<CursoDTO>();

            try
            {
                foreach (var item in await _dbcontext.Cursos.ToListAsync())
                {
                    listaCursoDTO.Add(new CursoDTO
                    {
                        IdCurso = item.IdCurso,
                        Codigo = item.Codigo,
                        NombreCurso = item.NombreCurso,
                        Creditos = (int)item.Creditos,
                        Descripcion = item.Descripcion,
                        Temario = item.Temario,
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaCursoDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<CursoDTO>();
            var CursoDTO = new CursoDTO();

            try
            {
                var dbCurso = await _dbcontext.Cursos.FirstOrDefaultAsync(x => x.IdCurso == id);

                if (dbCurso != null)
                {
                    CursoDTO.Codigo = dbCurso.Codigo;
                    CursoDTO.NombreCurso = dbCurso.NombreCurso;
                    CursoDTO.Creditos = (int)dbCurso.Creditos;
                    CursoDTO.Descripcion = dbCurso.Descripcion;
                    CursoDTO.Temario = dbCurso.Temario;
                    

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = CursoDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }



            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(CursoDTO Curso)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbCurso = new Curso
                {
                    Codigo = Curso.Codigo,
                    NombreCurso = Curso.NombreCurso,
                    Creditos = Curso.Creditos,
                    Descripcion = Curso.Descripcion,
                    Temario = Curso.Temario


                };
                _dbcontext.Cursos.Add(dbCurso);
                await _dbcontext.SaveChangesAsync();

                if (dbCurso.IdCurso != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbCurso.IdCurso;
                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No guardado";
                }


            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }


        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(CursoDTO Curso, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbCurso = await _dbcontext.Cursos.FirstOrDefaultAsync(e => e.IdCurso == id);



                if (dbCurso != null)
                {
                    dbCurso.Codigo = Curso.Codigo;
                    dbCurso.NombreCurso = Curso.NombreCurso;
                    dbCurso.Creditos = Curso.Creditos;
                    dbCurso.Descripcion= Curso.Descripcion;
                    dbCurso.Temario = Curso.Temario;

                    _dbcontext.Cursos.Update(dbCurso);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbCurso.IdCurso;
                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Curso no encotrado";
                }


            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> EEliminar(CursoDTO Curso, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbCurso = await _dbcontext.Cursos.FirstOrDefaultAsync(e => e.IdCurso == id);



                if (dbCurso != null)
                {


                    _dbcontext.Cursos.Remove(dbCurso);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Curso no encotrado";
                }


            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
    }
}
