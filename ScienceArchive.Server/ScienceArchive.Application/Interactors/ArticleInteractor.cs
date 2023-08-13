using ScienceArchive.Application.Dtos.Article;
using ScienceArchive.Application.Dtos.Article.Request;
using ScienceArchive.Application.Dtos.Article.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.Application.Interactors;

public class ArticleInteractor : IArticleInteractor
{
    private readonly IArticleService _articleService;
    private readonly IApplicationMapper<Article, ArticleDto> _articleMapper;

    public ArticleInteractor(IArticleService articleService, IApplicationMapper<Article, ArticleDto> articleMapper)
    {
        _articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
        _articleMapper = articleMapper ?? throw new ArgumentNullException(nameof(articleMapper));
    }

    /// <inheritdoc/>
    public async Task<GetAllArticlesResponseDto> GetAllArticles(GetAllArticlesRequestDto dto)
    {
        var contract = new GetAllArticlesContract();
        var articles = await _articleService.GetAll(contract);
        var articlesDtos = articles.Select(article => _articleMapper.MapToDto(article)).ToList();

        return new(articlesDtos);
    }
    
    /// <inheritdoc/>
    public async Task<CreateArticleResponseDto> CreateArticle(CreateArticleRequestDto dto)
    {
        var contract = new CreateArticleContract(_articleMapper.MapToEntity(dto.Article));
        var createdArticle = await _articleService.Create(contract);

        return new(_articleMapper.MapToDto(createdArticle));
    }

    /// <inheritdoc/>
    public async Task<DeleteArticleResponseDto> DeleteArticle(DeleteArticleRequestDto dto)
    {
        var contract = new DeleteArticleContract(ArticleId.CreateFromString(dto.Id));
        var deletedArticleId = await _articleService.Delete(contract);
        
        return new(deletedArticleId.ToString());
    }

    /// <inheritdoc/>
    public async Task<UpdateArticleResponseDto> UpdateArticle(UpdateArticleRequestDto dto)
    {
        var contract = new UpdateArticleContract(
            ArticleId.CreateFromString(dto.Id), 
            _articleMapper.MapToEntity(dto.NewArticle));
        
        var updatedArticle = await _articleService.Update(contract);
        return new(_articleMapper.MapToDto(updatedArticle));
    }
}