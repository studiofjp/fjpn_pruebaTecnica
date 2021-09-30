using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pruebaTecnica.Models;
using pruebaTecnica.Models.Mensaje;
using pruebaTecnica.Models.Request;



namespace pruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        [HttpGet] // listado de personas 

        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.correcto = 0;

            try
            {
                using (prueba_tecnicaContext db = new prueba_tecnicaContext())
                {
                    var listar = db.Personas.ToList();
                    oRespuesta.correcto = 1;
                    oRespuesta.data = listar;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost] // insertar

        public IActionResult Add(personaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (prueba_tecnicaContext db = new prueba_tecnicaContext())
                {
                    Persona oPersona = new Persona();
                    oPersona.RunCuerpo = oModel.RunCuerpo;
                    oPersona.RunDigito = oModel.RunDigito;
                    oPersona.Nombres = oModel.Nombres;
                    oPersona.ApellidoPaterno = oModel.ApellidoPaterno;
                    oPersona.SexoCodigo = oModel.SexoCodigo;
                    db.Personas.Add(oPersona);
                    db.SaveChanges();
                    oRespuesta.correcto = 1;
                }
                       
            }
            catch(Exception ex)
            {
                oRespuesta.mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpPut] //Editar
        public IActionResult Edit(personaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (prueba_tecnicaContext db = new prueba_tecnicaContext())
                {
                    Persona oPersona = db.Personas.Find(oModel.RunCuerpo);
                    oPersona.Id = (Guid)oModel.Id;
                    oPersona.RunCuerpo = oModel.RunCuerpo;
                    oPersona.RunDigito = oModel.RunDigito;
                    oPersona.Nombres = oModel.Nombres;
                    oPersona.ApellidoPaterno = oModel.ApellidoPaterno;
                    oPersona.SexoCodigo = oModel.SexoCodigo;
                    db.Entry(oPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.correcto = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpDelete ("{RunCuerpo}")] //Eliminar 

        public IActionResult Delete(string RunCuerpo)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (prueba_tecnicaContext db = new prueba_tecnicaContext())
                {
                    Persona oPersona = db.Personas.Find(RunCuerpo);
                    db.Remove(oPersona);
                    db.SaveChanges();
                    oRespuesta.correcto = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

    }
}




