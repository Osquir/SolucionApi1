using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ApiCrud.Server.Models;
using InstitucionCrud.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

//Autorization Token
//using Microsoft.AspNetCore.Authorization;

namespace ApiCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly InstitucionContext _dbcontext;
        public AlumnosController(InstitucionContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //[Authorize]
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<AlumnoDTO>>();
            var listaAlumnoDTO = new List<AlumnoDTO>();

            try
            {
                foreach (var item in await _dbcontext.Alumnos.ToListAsync())
                {
                    listaAlumnoDTO.Add(new AlumnoDTO
                    {
                        IdAlumno = item.IdAlumno,
                        PrimerNombre = item.PrimerNombre,
                        SegundoNombre = item.SegundoNombre,
                        PrimerApellido = item.PrimerApellido,
                        SegundoApellido = item.SegundoApellido,
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaAlumnoDTO;
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
            var responseApi = new ResponseAPI<AlumnoDTO>();
            var AlumnoDTO = new  AlumnoDTO();

            try
            {
                var dbAlumno = await _dbcontext.Alumnos.FirstOrDefaultAsync(x=> x.IdAlumno== id);

                if (dbAlumno != null) 
                {
                    AlumnoDTO.IdAlumno = dbAlumno.IdAlumno;
                    AlumnoDTO.PrimerNombre = dbAlumno.PrimerNombre;
                    AlumnoDTO.SegundoNombre = dbAlumno.SegundoNombre;
                    AlumnoDTO.PrimerApellido = dbAlumno.PrimerApellido;
                    AlumnoDTO.SegundoApellido = dbAlumno.SegundoApellido;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = AlumnoDTO;
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
        public async Task<IActionResult> Guardar(AlumnoDTO alumno)
        {
            var responseApi = new ResponseAPI<int>();
          
            try
            {
                var dbAlumno = new Alumno
                {
                    PrimerNombre = alumno.PrimerNombre,
                    SegundoNombre = alumno.SegundoNombre,
                    PrimerApellido = alumno.PrimerApellido,
                    SegundoApellido = alumno.SegundoApellido,
                    Codigo = alumno.Codigo


                };
                _dbcontext.Alumnos.Add(dbAlumno);
                await _dbcontext.SaveChangesAsync();
                
                if(dbAlumno.IdAlumno !=0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbAlumno.IdAlumno;
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
        public async Task<IActionResult> Editar(AlumnoDTO alumno, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAlumno = await _dbcontext.Alumnos.FirstOrDefaultAsync(e=> e.IdAlumno == id);

               
            
                if (dbAlumno != null)
                {
                    dbAlumno.PrimerNombre = alumno.PrimerNombre;
                    dbAlumno.SegundoNombre = alumno.SegundoNombre;
                    dbAlumno.PrimerApellido= alumno.PrimerApellido; 
                    dbAlumno.SegundoApellido= alumno.SegundoApellido; 
                    dbAlumno.Codigo = alumno.Codigo;

                    _dbcontext.Alumnos.Update(dbAlumno);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbAlumno.IdAlumno;
                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Alumno no encotrado";
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
        public async Task<IActionResult> Eliminar(AlumnoDTO alumno, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAlumno = await _dbcontext.Alumnos.FirstOrDefaultAsync(e => e.IdAlumno == id);



                if (dbAlumno != null)
                {
            

                    _dbcontext.Alumnos.Remove(dbAlumno);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
              
                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Alumno no encotrado";
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
