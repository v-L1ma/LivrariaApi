using Microsoft.AspNetCore.Mvc;
using webapicurso.Models;
using webapicurso.Services.Autor;
namespace webapicurso.Controllers;

[Route("[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly IAutorService _autorService;
    public AutorController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    /// <summary>
    /// Exibe uma lista de todos os autores
    /// </summary>
    /// <param></param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     GET /Autor
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de autores</response>
    [HttpGet("")]
    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
    {
        var response = await _autorService.ListarAutores();
        return Ok(response);
    }

    /// <summary>
    /// Traz informações de um autor usando o ID dele
    /// </summary>
    /// <param name="idAutor">Numero de identificação do autor</param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     GET /Autor/1
    ///
    /// </remarks>
    /// <response code="200">Retorna todas as informações de um autor</response>
    [HttpGet("{idAutor}")]
    public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
    {
        var response = await _autorService.BuscarAutorPorId(idAutor);
        return Ok(response);
    }

    /// <summary>
    /// Traz informações de um autor usando o ID de um livro
    /// </summary>
    /// <param name="idLivro">Numero de identificação do livro</param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     GET /Autor/livro/1
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de autores</response>
    [HttpGet("livro/{idLivro}")]
    public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
    {
        var response = await _autorService.BuscarAutorPorIdLivro(idLivro);
        return Ok(response);
    }

    /// <summary>
    /// Cadastra um novo autor
    /// </summary>
    /// <param></param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     POST /Autor{
    ///         Nome: "Vinicius",
    ///         Sobrenome: "Lima"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de autores</response>
    [HttpPost("")]
    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorDto dto)
    {
        var response = await _autorService.CriarAutor(dto);
        return Ok(response);
    }

    /// <summary>
    /// Edita as informações de um autor já cadastrado
    /// </summary>
    /// <param name="idAutor">Numero de indentificacao do autor</param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     PUT /Autor/1{
    ///         Nome: "Vinicius",
    ///         Sobrenome: "Lima"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de autores</response>
    [HttpPut("{idAutor}")]
    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(int idAutor, [FromBody] AutorDto dto)
    {
        var response = await _autorService.EditarAutor(idAutor, dto);
        return Ok(response);
    }

    /// <summary>
    /// Exclui o cadastro de um autor
    /// </summary>
    /// <param name="idAutor">Numero de indentificacao do autor</param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     DELETE /Autor/1
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de autores</response>
    [HttpDelete("{idAutor}")]
    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int idAutor)
    {
        var response = await _autorService.ExcluirAutor(idAutor);
        return Ok(response);
    }
}