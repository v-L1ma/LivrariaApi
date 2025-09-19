using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore;
using webapicurso.Data;
using webapicurso.Models;

public class LivroService : ILivroService
{
    private readonly AppDbContext _context;

    public LivroService(AppDbContext context)
    {
        _context = context;
    }    
    public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
    {
        ResponseModel<List<LivroModel>> response = new();

        try
        {
            List<LivroModel> livros = await _context.Livros.Include(livro=> livro.Autor).ToListAsync();
            response.Dados = livros;
            response.Status = true;
            response.Mensagem = "Livros listados com sucesso";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = ex.Message;
        }
        return response;
    }
    public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
    {
        ResponseModel<LivroModel> response = new();

        try
        {
            LivroModel? livro = await _context.Livros.Include(livro=> livro.Autor).FirstOrDefaultAsync(livro => livro.Id == idLivro);

            if (livro == null)
            {
                response.Status = true;
                response.Mensagem = "Nenhum livro com esse Id foi encontrado";
                return response;
            }

            response.Dados = livro;
            response.Status = true;
            response.Mensagem = "Livro listado com sucesso.";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = ex.Message;
        }
        return response;
    }

    public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDto dto)
    {
        ResponseModel<List<LivroModel>> response = new();

        try
        {
            AutorModel? autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == dto.IdAutor);

            if (autor == null)
            {
                response.Status = true;
                response.Mensagem = "Nenhum autor com esse Id foi encontrado.";
                return response;
            }

            LivroModel livroNovo = new()
            {
                Titulo = dto.Titulo,
                Autor = autor,
            };

            _context.Add(livroNovo);
            await _context.SaveChangesAsync();

            response.Dados = await _context.Livros.ToListAsync();
            response.Status = true;
            response.Mensagem = "Livro cadastrado com sucesso!";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = ex.Message;
        }
        return response;
    }

    public async Task<ResponseModel<List<LivroModel>>> EditarLivro(int idLivro, LivroDto dto)
    {
        ResponseModel<List<LivroModel>> response = new();

        try
        {
            LivroModel? livro = await _context.Livros.FirstOrDefaultAsync(livro => livro.Id == idLivro);

            if (livro == null)
            {
                response.Status = true;
                response.Mensagem = "Nenhum livro com esse Id foi encontrado.";
                return response;
            }

            livro.Titulo = dto.Titulo;
            _context.Update(livro);
            await _context.SaveChangesAsync();

            response.Dados = await _context.Livros.Include(livro=> livro.Autor).ToListAsync();
            response.Status = true;
            response.Mensagem = "Dados do livro atualizados com sucesso!";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = ex.Message;
        }
        return response;
    }

    public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
    {
        ResponseModel<List<LivroModel>> response = new();

        try
        {
            LivroModel? livro = await _context.Livros.FirstOrDefaultAsync(livro => livro.Id == idLivro);

            if (livro == null)
            {
                response.Status = true;
                response.Mensagem = "Nenhum livro com esse Id foi encontrado.";
                return response;
            }

            _context.Remove(livro);
            await _context.SaveChangesAsync();

            response.Dados = await _context.Livros.Include(livro=> livro.Autor).ToListAsync();
            response.Status = true;
            response.Mensagem = "Livro deletado com sucesso!";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = ex.Message;
        }
        return response;
    }

    public async Task<ResponseModel<List<LivroModel>>> ListarLivrosPorIdAutor(int idAutor)
    {
        ResponseModel<List<LivroModel>> response = new();

        try
        {
            AutorModel? autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == idAutor);

            if (autor == null)
            {
                response.Status = true;
                response.Mensagem = "Nenhum autor com esse Id foi encontrado.";
                return response;
            }

            List<LivroModel> livros = await _context.Livros.Where(livro => livro.Autor == autor).Include(livro=> livro.Autor).ToListAsync();

            response.Dados = livros;
            response.Status = true;
            response.Mensagem = "Livro listados com sucesso!";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = ex.Message;
        }
        return response;
    }
}