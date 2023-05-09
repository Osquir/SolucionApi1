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
    public class RolController : ControllerBase
    {
        private readonly InstitucionContext _dbcontext;
        public RolController(InstitucionContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<RolDTO>>();
            var listaRolDTO = new List<RolDTO>();

            try
            {
                foreach (var item in await _dbcontext.Rols.ToListAsync())
                {
                    listaRolDTO.Add(new RolDTO
                    {
                        IdRol = item.IdRol,
                        Nombre = item.Nombre,
                     
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaRolDTO;
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
            var responseApi = new ResponseAPI<RolDTO>();
            var RolDTO = new RolDTO();

            try
            {
                var dbRol = await _dbcontext.Rols.FirstOrDefaultAsync(x => x.IdRol == id);

                if (dbRol != null)
                {
                    RolDTO.IdRol = dbRol.IdRol;
                    RolDTO.Nombre = dbRol.Nombre;
                 
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = RolDTO;
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
        public async Task<IActionResult> Guardar(RolDTO Rol)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbRol = new Rol
                {
                    Nombre = Rol.Nombre,
                    
                };
                _dbcontext.Rols.Add(dbRol);
                await _dbcontext.SaveChangesAsync();

                if (dbRol.IdRol != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbRol.IdRol;
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
        public async Task<IActionResult> Editar(RolDTO Rol, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbRol = await _dbcontext.Rols.FirstOrDefaultAsync(e => e.IdRol == id);



                if (dbRol != null)
                {
                    dbRol.Nombre = Rol.Nombre;
                   
                    _dbcontext.Rols.Update(dbRol);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbRol.IdRol;
                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Rol no encotrado";
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
        public async Task<IActionResult> EEliminar(RolDTO Rol, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbRol = await _dbcontext.Rols.FirstOrDefaultAsync(e => e.IdRol == id);



                if (dbRol != null)
                {


                    _dbcontext.Rols.Remove(dbRol);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Rol no encotrado";
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
