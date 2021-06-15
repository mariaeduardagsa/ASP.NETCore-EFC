using CrudSimples.API.Models;
using CrudSimples.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CrudSimples.API.Controllers
{
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        //private List<Colaborador> _colaborador = new List<Colaborador>
        //{
        //    new Colaborador(1, "Maria Eduarda", "Feminino", new DateTime(1999, 11, 25), "Desenvolvedora", true),
        //    new Colaborador(2, "Saulo", "Masculino", new DateTime(1997, 11, 25), "Líder de projetos", true),
        //    new Colaborador(3, "André", "Masculino", new DateTime(1989, 04,06), "Limpeza", false)
        //};

        private readonly ColaboradorDbContext _colaboradorDbContext;
        public ColaboradorController(ColaboradorDbContext colaboradorDbContext)
        {
            _colaboradorDbContext = colaboradorDbContext;
        }

        //api/Colaborador HTTP GET
        [HttpGet]
        public IActionResult Get()
        {
            var colaboradores = _colaboradorDbContext.Colaboradores.ToList();

            return Ok(colaboradores);
        }

        //api/Colaborador/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var colaborador = _colaboradorDbContext.Colaboradores.SingleOrDefault(c => c.Id == id);

            if(colaborador == null)
            {
                return NotFound();
            } else
            {
                return Ok(colaborador);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ColaboradorInputModel colaboradorInputModel)
        {
            if(colaboradorInputModel == null)
            {
                return BadRequest();
            }
            
            var colaborador = new Colaborador(colaboradorInputModel.Nome, colaboradorInputModel.Sexo, colaboradorInputModel.DataDeNascimento, colaboradorInputModel.Cargo, colaboradorInputModel.Ativo);

            _colaboradorDbContext.Colaboradores.Add(colaborador);
            _colaboradorDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = colaborador.Id }, colaborador);

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ColaboradorInputModel colaboradorInputModel, int id)
        {
            if(colaboradorInputModel == null)
            {
                return BadRequest();
            }

            var colaborador = _colaboradorDbContext.Colaboradores.SingleOrDefault(p => p.Id == id);

            if(colaborador == null)
            {
                return NotFound();
            }

            colaborador.Nome = colaboradorInputModel.Nome;
            colaborador.Sexo = colaboradorInputModel.Sexo;
            colaborador.DataDeNascimento = colaboradorInputModel.DataDeNascimento;
            colaborador.Cargo = colaboradorInputModel.Cargo;
            colaborador.Ativo = colaboradorInputModel.Ativo;

            _colaboradorDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var colaborador = _colaboradorDbContext.Colaboradores.SingleOrDefault(p => p.Id == id);

            if(colaborador == null)
            {
                return NotFound();
            }

            _colaboradorDbContext.Colaboradores.Remove(colaborador);
            _colaboradorDbContext.SaveChanges();

            return NoContent();
        }
    }
}
