using ScienceArchive.Application.Dtos.Article;
using ScienceArchive.Application.Dtos.Article.Request;
using ScienceArchive.Application.Dtos.Article.Response;
using ScienceArchive.Application.Dtos.Category;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.ArticleContracts;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.Application.Interactors;

internal class ArticleInteractor : IArticleInteractor
{
    private readonly IArticleService _articleService;
    private readonly ICategoryService _categoryService;
    
    private readonly IApplicationMapper<Article, ArticleDto> _articleMapper;
    private readonly IApplicationMapper<Category, CategoryDto> _categoryMapper;
    
    public ArticleInteractor(
        IArticleService articleService, 
        ICategoryService categoryService,
        IApplicationMapper<Article, ArticleDto> articleMapper,
        IApplicationMapper<Category, CategoryDto> categoryMapper)
    {
        _articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        _articleMapper = articleMapper ?? throw new ArgumentNullException(nameof(articleMapper));
        _categoryMapper = categoryMapper ?? throw new ArgumentNullException(nameof(categoryMapper));
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
        var categoryId = CategoryId.CreateFromString(dto.CategoryId);
        var articlesContract = new GetVerifiedArticlesBySubcategoryIdContract(categoryId);
        var articles = await _articleService.GetVerifiedBySubcategoryId(articlesContract);

        var articlesDtos = articles.Select(_articleMapper.MapToDto).ToList();
        
        var categoryContract = new GetSubcategoryByIdContract(categoryId);
        var category = await _categoryService.GetSubcategoryById(categoryContract);

        if (category is null)
        {
            throw new Exception("Category with specified ID was not found");
        }

        var categoryDto = _categoryMapper.MapToDto(category);
        
        return new(articlesDtos, categoryDto);
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