using Microsoft.AspNetCore.Mvc;
using webapicurso.Models;

[Route("[controller]")]
[ApiController]
public class LivroController :ControllerBase
{

    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    /// <summary>
    /// Exibe uma lista de todos os livros
    /// </summary>
    /// <param></param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     GET /Livro
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de livros</response>
    [HttpGet("")]
    public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
    {
        var response = await _livroService.ListarLivros();
        return Ok(response);
    }

    /// <summary>
    /// Exibe uma lista de todos os livros de um determinado autor
    /// </summary>
    /// <param name="idAutor">Numero de indentificacao do autor</param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     GET Livro/autor/1
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de livros</response>
    [HttpGet("autor/{idAutor}")]
    public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivrosPorIdAutor(int idAutor)
    {
        var response = await _livroService.ListarLivrosPorIdAutor(idAutor);
        return Ok(response);
    }

    /// <summary>
    /// Exibe informacoes de um livro de acordo com o ID dele
    /// </summary>
    /// <param name="idLivro">Numero de indentificacao do livro</param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     GET /Livro/1
    ///
    /// </remarks>
    /// <response code="200">Retorna todas as informacoes de um livro</response>
    [HttpGet("{idLivro}")]
    public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
    {
        var response = await _livroService.BuscarLivroPorId(idLivro);
        return Ok(response);
    }

    /// <summary>
    /// Cadastra um novo livro
    /// </summary>
    /// <param></param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     POST /Livro {
    ///         Nome:"Vinicius",
    ///         Sobrenome:"Lima"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de livros</response>
    [HttpPost("")]
    public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroDto dto)
    {
        var response = await _livroService.CriarLivro(dto);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza os dados de um livro ja cadastrado
    /// </summary>
    /// <param name="idLivro">Numero de indentificacao do livro</param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     PUT /Livro/1 {
    ///         Titulo:"Pequeno principe"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de livros</response>
    [HttpPut("{idLivro}")]
    public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(int idLivro,[FromBody] LivroDto dto)
    {
        var response = await _livroService.EditarLivro(idLivro, dto);
        return Ok(response);
    }

    /// <summary>
    /// Exclui o cadastro de um livro
    /// </summary>
    /// <param name="idLivro">Numero de indentificacao do livro</param>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     DELETE /Livro/1
    ///
    /// </remarks>
    /// <response code="200">Retorna uma lista de livros</response>
    [HttpDelete("{idLivro}")]
    public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
    {
        var response = await _livroService.ExcluirLivro(idLivro);
        return Ok(response);
    }
}