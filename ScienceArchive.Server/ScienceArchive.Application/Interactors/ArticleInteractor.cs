using ScienceArchive.Application.Dtos.Article;
using ScienceArchive.Application.Dtos.Article.Request;
using ScienceArchive.Application.Dtos.Article.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.Application.Interactors;

internal class ArticleInteractor : IArticleInteractor
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
        var contract = new GetAllVerifiedArticlesContract();
        var articles = await _articleService.GetAllVerified(contract);
        var articlesDtos = articles.Select(article => _articleMapper.MapToDto(article)).ToList();

        return new(articlesDtos);
    }

    /// <inheritdoc/>
    public async Task<GetArticlesByAuthorIdResponseDto> GetArticlesByAuthorId(GetArticlesByAuthorIdRequestDto dto)
    {
        var contract = new GetArticlesByAuthorIdContract(UserId.CreateFromString(dto.AuthorId));
        var articles = await _articleService.GetByAuthorId(contract);

        var articlesDtos = articles.Select(_articleMapper.MapToDto).ToList();
        return new GetArticlesByAuthorIdResponseDto(articlesDtos);
    }

    /// <inheritdoc/>
    public async Task<GetVerifiedArticlesByAuthorIdResponseDto> GetVerifiedArticlesByAuthorId(GetVerifiedArticlesByAuthorIdRequestDto dto)
    {
        var contract = new GetVerifiedArticlesByAuthorIdContract(UserId.CreateFromString(dto.AuthorId));
        var articles = await _articleService.GetVerifiedByAuthorId(contract);

        var articlesDtos = articles.Select(_articleMapper.MapToDto).ToList();
        return new GetVerifiedArticlesByAuthorIdResponseDto(articlesDtos);
    }

    /// <inheritdoc/>
    public async Task<GetArticleByIdResponseDto> GetArticleById(GetArticleByIdRequestDto dto)
    {
        var contract = new GetVerifiedArticleByIdContract(ArticleId.CreateFromString(dto.Id));
        var article = await _articleService.GetVerifiedById(contract);
        
        var articleDto = article is not null
            ? _articleMapper.MapToDto(article)
            : throw new Exception("Cannot get article with specified ID");
        
        return new(articleDto);
    }
    
    public async Task<GetArticlesByCategoryIdResponseDto> GetArticlesByCategoryId(GetArticlesByCategoryIdRequestDto dto)
    {
        var contract = new GetVerifiedArticlesByCategoryIdContract(CategoryId.CreateFromString(dto.CategoryId));
        var articles = await _articleService.GetVerifiedByCategoryId(contract);

        var articlesDtos = articles.Select(_articleMapper.MapToDto).ToList();
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
            _articleMapper.MapToEntity(dto.Article));
        
        var updatedArticle = await _articleService.Update(contract);
        return new(_articleMapper.MapToDto(updatedArticle));
    }
}