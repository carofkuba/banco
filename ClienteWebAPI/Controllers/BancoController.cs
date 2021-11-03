﻿using AppBanco.Acceso_a_Datos;
using AppBanco.Servicios;
using BancoBack.Dominio;
using BancoBack.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private IAplicacion app;

        public BancoController()
        {
            app = new ApplicationFactory().CrearAplicacion(new DaoFactory());
        }
        //-----------------------------------------------------
        [HttpGet("tipos")]
        public IActionResult GetTipos()
        {
            return Ok(app.ConsultarTipos());
        }
        //-----------------------------------------------------
        [HttpGet("cuentasTorta")]
        public IActionResult GetCuentasTorta()
        {
            return Ok(app.ConsultarGraficoTorta());
        }
        //-----------------------------------------------------
        [HttpGet("cartesiano")]
        public IActionResult GetGraficoCartesiano()
        {
            return Ok(app.ConsultarGraficoCartesiano());
        }
        //-----------------------------------------------------
        [HttpGet("numero")]
        public IActionResult GetNumero()
        {
            return Ok(app.ProximoNroCliente());
        }
        //-----------------------------------------------------
        [HttpPost("registro")]
        public IActionResult PostCliente(Cliente oCliente)
        {
            if (oCliente != null)
            {
                bool result = app.RegistrarCliente(oCliente);
                return Ok(result);
            }

            return BadRequest("Se requiere número de Cliente");
        }
        //-----------------------------------------------------
        [HttpPost("altatipo")]
        public IActionResult PostTipo(TipoCuenta oTipo)
        {
            if (oTipo != null)
            {
                bool result = app.RegistrarTipoCuenta(oTipo);
                return Ok(result);
            }

            return BadRequest("Se requiere nombre de Cuenta");
        }
        //-----------------------------------------------------       
        [HttpPost("consultaparam")]
        public IActionResult PostConsulta(List<Parametro> filtros)
        {
            if (filtros == null || filtros.Count == 0)
                return BadRequest("Se requiere una lista de parámetros!");

            return Ok(app.ConsultarClientes(filtros));
        }
        //-----------------------------------------------------
<<<<<<< HEAD
        [HttpPost("consultaAdmin")]
        public IActionResult PostConsultaAdmin(Administrador oAdmin)
        {
            if (oAdmin == null)
                return BadRequest("Se requiere una lista de parámetros!");

            return Ok(app.ConsultarAdmins(oAdmin));
        }


=======
        [HttpDelete("{numeroClte}")]
        public IActionResult Delete(int numeroClte)
        {
            if (numeroClte == 0)
                return BadRequest("Id es requerido!");
            return Ok(app.RegistrarBajaCliente(numeroClte));
        }
>>>>>>> 151c935bd463926ed2a15b82561675f1a488d9ee

        //para el update es un Put?
    }
}
