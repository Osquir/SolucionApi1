using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ApiCrud.Server.Models;
using InstitucionCrud.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoCursoController : ControllerBase
    {

        private readonly InstitucionContext _dbcontext;
        public AlumnoCursoController(InstitucionContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //Listar
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<AlumnoCursoDTO>>();
            var listaAlumnoCursoDTO = new List<AlumnoCursoDTO>();

            try
            {
                foreach (var item in await _dbcontext.AlumnoCursos.ToListAsync())
                {
                    listaAlumnoCursoDTO.Add(new AlumnoCursoDTO
                    {
                        IdAlumnoCurso = item.IdAlumnoCurso,
                        IdAlumno = item.IdAlumno,
                        IdCurso = item.IdCurso,
                        Año = item.Año,


                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaAlumnoCursoDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
        
        //Buscar
        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<AlumnoCursoDTO>();
            var AlumnoCursoDTO = new AlumnoCursoDTO();

            try
            {
                var dbAlumnoCurso = await _dbcontext.AlumnoCursos.FirstOrDefaultAsync(x => x.IdAlumnoCurso == id);

                if (dbAlumnoCurso != null)
                {
                    AlumnoCursoDTO.IdAlumnoCurso = dbAlumnoCurso.IdAlumnoCurso;
                    AlumnoCursoDTO.IdAlumno = dbAlumnoCurso.IdAlumno;
                    AlumnoCursoDTO.IdCurso = dbAlumnoCurso.IdCurso;
                    AlumnoCursoDTO.Año = dbAlumnoCurso.Año;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = AlumnoCursoDTO;
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

        //Guardar
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(AlumnoCursoDTO AlumnoCurso)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAlumnoCurso = new AlumnoCurso
                {
                    IdAlumnoCurso = AlumnoCurso.IdAlumnoCurso,
                    IdAlumno = AlumnoCurso.IdAlumno,
                    IdCurso = AlumnoCurso.IdCurso,
                    Año = AlumnoCurso.Año

                };
                _dbcontext.AlumnoCursos.Add(dbAlumnoCurso);
                await _dbcontext.SaveChangesAsync();

                if (dbAlumnoCurso.IdAlumnoCurso != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbAlumnoCurso.IdAlumnoCurso;
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
        public async Task<IActionResult> Editar(AlumnoCursoDTO AlumnoCurso, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAlumnoCurso = await _dbcontext.AlumnoCursos.FirstOrDefaultAsync(e => e.IdAlumnoCurso == id);



                if (dbAlumnoCurso != null)
                {
                    dbAlumnoCurso.IdAlumnoCurso = AlumnoCurso.IdAlumnoCurso;
                    dbAlumnoCurso.IdAlumno = AlumnoCurso.IdAlumno;
                    dbAlumnoCurso.IdCurso = AlumnoCurso.IdCurso;
                    dbAlumnoCurso.Año = AlumnoCurso.Año;


                    _dbcontext.AlumnoCursos.Update(dbAlumnoCurso);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbAlumnoCurso.IdAlumnoCurso;
                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "AlumnoCurso no encotrado";
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
        public async Task<IActionResult> Eliminar(AlumnoCursoDTO AlumnoCurso, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAlumnoCurso = await _dbcontext.AlumnoCursos.FirstOrDefaultAsync(e => e.IdAlumnoCurso == id);



                if (dbAlumnoCurso != null)
                {


                    _dbcontext.AlumnoCursos.Remove(dbAlumnoCurso);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "AlumnoCurso no encotrado";
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
