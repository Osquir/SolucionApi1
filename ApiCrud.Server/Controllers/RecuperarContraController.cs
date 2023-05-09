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
    public class RecuperarContraController : ControllerBase
    {
        private readonly InstitucionContext _dbcontext;
        public RecuperarContraController(InstitucionContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<RecuperarContraDTO>>();
            var listaRecuperarContraDTO = new List<RecuperarContraDTO>();

            try
            {
                foreach (var item in await _dbcontext.RecuperarContras.ToListAsync())
                {
                    listaRecuperarContraDTO.Add(new RecuperarContraDTO
                    {
                        IdRcontra = item.IdRcontra,
                        IdUsuario = (int)item.IdUsuario,
                        Token = item.Token

                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaRecuperarContraDTO;
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
            var responseApi = new ResponseAPI<RecuperarContraDTO>();
            var RecuperarContraDTO = new RecuperarContraDTO();

            try
            {
                var dbRecuperarContra = await _dbcontext.RecuperarContras.FirstOrDefaultAsync(x => x.IdRcontra == id);

                if (dbRecuperarContra != null)
                {
                    RecuperarContraDTO.IdRcontra = dbRecuperarContra.IdRcontra;
                    RecuperarContraDTO.IdUsuario = (int)dbRecuperarContra.IdUsuario;
                    RecuperarContraDTO.Token = dbRecuperarContra.Token;


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = RecuperarContraDTO;
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
        public async Task<IActionResult> Guardar(RecuperarContraDTO RecuperarContra)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbRecuperarContra = new RecuperarContra
                {
                    IdUsuario = RecuperarContra.IdUsuario,
                    Token = RecuperarContra.Token,



                };
                _dbcontext.RecuperarContras.Add(dbRecuperarContra);
                await _dbcontext.SaveChangesAsync();

                if (dbRecuperarContra.IdRcontra != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbRecuperarContra.IdRcontra;
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
        public async Task<IActionResult> Editar(RecuperarContraDTO RecuperarContra, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbRecuperarContra = await _dbcontext.RecuperarContras.FirstOrDefaultAsync(e => e.IdRcontra == id);



                if (dbRecuperarContra != null)
                {
                    dbRecuperarContra.IdUsuario = RecuperarContra.IdUsuario;
                    dbRecuperarContra.Token = RecuperarContra.Token;

                    _dbcontext.RecuperarContras.Update(dbRecuperarContra);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbRecuperarContra.IdRcontra;
                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "RecuperarContra no encotrado";
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
        public async Task<IActionResult> EEliminar(RecuperarContraDTO RecuperarContra, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbRecuperarContra = await _dbcontext.RecuperarContras.FirstOrDefaultAsync(e => e.IdRcontra == id);



                if (dbRecuperarContra != null)
                {


                    _dbcontext.RecuperarContras.Remove(dbRecuperarContra);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "RecuperarContra no encotrado";
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
