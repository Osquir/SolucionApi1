using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ApiCrud.Server.Models;
using InstitucionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario_RolController : ControllerBase
    {
        private readonly InstitucionContext _dbcontext;
        public Usuario_RolController(InstitucionContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<UsuarioRolDTO>>();
            var listaUsuarioRolDTO = new List<UsuarioRolDTO>();

            try
            {
                foreach (var item in await _dbcontext.UsuarioRols.ToListAsync())
                {
                    listaUsuarioRolDTO.Add(new UsuarioRolDTO
                {
                    IdUsuarioRol= item.IdUsuarioRol,
                    UsuarioId = item.UsuarioId,
                    RolId = item.RolId,



                });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaUsuarioRolDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
        [HttpGet]
        [Route("B|uscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<UsuarioRolDTO>();
            var UsuarioRolDTO = new UsuarioRolDTO();

            try
            {
                var dbUsuarioRol = await _dbcontext.UsuarioRols.FirstOrDefaultAsync(x => x.IdUsuarioRol == id);

                if (dbUsuarioRol != null)
                {                   
                    UsuarioRolDTO.IdUsuarioRol = dbUsuarioRol.IdUsuarioRol;
                    UsuarioRolDTO.UsuarioId = dbUsuarioRol.UsuarioId;
                    UsuarioRolDTO.RolId = dbUsuarioRol.RolId;
                

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = UsuarioRolDTO;
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
        public async Task<IActionResult> Guardar(UsuarioRolDTO UsuarioRol)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbUsuarioRol = new UsuarioRol
                {
                    IdUsuarioRol = UsuarioRol.IdUsuarioRol,
                    UsuarioId = UsuarioRol.UsuarioId,
                    RolId = UsuarioRol.RolId,
                   

                };
                _dbcontext.UsuarioRols.Add(dbUsuarioRol);
                await _dbcontext.SaveChangesAsync();

                if (dbUsuarioRol.IdUsuarioRol != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbUsuarioRol.IdUsuarioRol;
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
        public async Task<IActionResult> Editar(UsuarioRolDTO UsuarioRol, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbUsuarioRol = await _dbcontext.UsuarioRols.FirstOrDefaultAsync(e => e.IdUsuarioRol == id);



                if (dbUsuarioRol != null)
                {
                    dbUsuarioRol.IdUsuarioRol = UsuarioRol.IdUsuarioRol;
                    dbUsuarioRol.UsuarioId = UsuarioRol.UsuarioId;
                    dbUsuarioRol.RolId = UsuarioRol.RolId;
                   

                    _dbcontext.UsuarioRols.Update(dbUsuarioRol);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbUsuarioRol.IdUsuarioRol;
                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "UsuarioRol no encotrado";
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
        public async Task<IActionResult> Eliminar(UsuarioRolDTO UsuarioRol, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbUsuarioRol = await _dbcontext.UsuarioRols.FirstOrDefaultAsync(e => e.IdUsuarioRol == id);



                if (dbUsuarioRol != null)
                {


                    _dbcontext.UsuarioRols.Remove(dbUsuarioRol);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "UsuarioRol no encotrado";
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
