using api_rest.Data;
using api_rest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace api_rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly ApplicationDbContext database;

        public ProdutosController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get(){
            var produtos = database.Produtos.ToList();
            return Ok(produtos); // Status code = 200 && dados
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            try{
                Produto produto = database.Produtos.First(p => p.Id == id);
                return Ok(produto);
            }catch(Exception e){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoTemp pTemp){
            
            Produto p = new Produto();
            
            p.Nome = pTemp.Nome;
            p.Preco = pTemp.Preco;
            database.Produtos.Add(p);
            database.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult("");
            //return Ok(new {msg = "Produto criado com sucesso!"}); 
        }
    

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            try{
                Produto produto = database.Produtos.First(p => p.Id == id);
                database.Produtos.Remove(produto);
                database.SaveChanges();
                return Ok();
            }catch(Exception e){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }


        public class ProdutoTemp{
            public string Nome {get; set;}
            public float Preco {get; set;}
        }

    }
}