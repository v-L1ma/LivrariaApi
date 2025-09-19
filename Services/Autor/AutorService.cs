using Microsoft.EntityFrameworkCore;
using webapicurso.Data;
using webapicurso.Models;

namespace webapicurso.Services.Autor;

public class AutorService : IAutorService
{

    private AppDbContext _context;

    public AutorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
    {
        ResponseModel<AutorModel> response = new();
        try
        {
            var autor = await _context.Autores.FindAsync(idAutor);

            if (autor == null)
            {
                response.Status = true;
                response.Mensagem = "Nenhum autor com esse ID foi encontrado";
                return response;
            }

            response.Dados = autor;
            response.Status = true;
            response.Mensagem = "Usuario encontrado com sucesso";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = ex.Message;
        }

        return response;
    }

    public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
    {
        ResponseModel<AutorModel> response = new();

        try
        {
            var livro = await _context.Livros.Include(livro => livro.Autor).FirstOrDefaultAsync(livro => livro.Id == idLivro);

            if (livro == null)
            {
                response.Status = true;
                response.Mensagem = "Nenhum livro com esse ID foi encontrado";
                return response;
            }

            response.Dados = livro.Autor;
            response.Status = true;
            response.Mensagem = "Autor do livro encontrado com sucesso";

        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = ex.Message;
        }

        return response;
    }
    public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
    {
        ResponseModel<List<AutorModel>> response = new();

        try
        {
            var autores = await _context.Autores.ToListAsync();
            response.Dados = autores;
            response.Mensagem = "Autores listados com sucesso";
            response.Status = true;

            return response;
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
    }
    public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDto dto)
    {
        ResponseModel<List<AutorModel>> response = new();

        try
        {
            AutorModel autorNovo = new()
            {
                Nome = dto.Nome,
                Sobrenome = dto.Sobrenome
            };

            _context.Autores.Add(autorNovo);
            await _context.SaveChangesAsync();

            response.Dados = await _context.Autores.ToListAsync();
            response.Status = true;
            response.Mensagem = "Autor criado com sucesso";
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
        }
        
        return response;
    }

    public async Task<ResponseModel<List<AutorModel>>> EditarAutor(int idAutor, AutorDto dto)
    {
        ResponseModel<List<AutorModel>> response = new();

        try
        {

            var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == idAutor);

             if (autor == null)
            {
                response.Status = true;
                response.Mensagem = "Nenhum Autor com esse ID foi encontrado";
                return response;
            }

            autor.Nome = dto.Nome;
            autor.Sobrenome = dto.Sobrenome;

            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();

            response.Dados = await _context.Autores.ToListAsync();
            response.Status = true;
            response.Mensagem = "Dados do autor atualizados com sucesso";
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
        }
        
        return response;
    }

    public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
    {
        ResponseModel<List<AutorModel>> response = new();

        try
        {
            AutorModel? autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == idAutor);

            if (autor == null)
            {
                response.Status = true;
                response.Mensagem = "Nenhum Autor com esse ID foi encontrado";
                return response;
            }

            _context.Remove(autor);
            await _context.SaveChangesAsync();

            response.Dados = await _context.Autores.ToListAsync();
            response.Status = true;
            response.Mensagem = "Autor excluido com sucesso!";

        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
        }
        return response;
    }
}