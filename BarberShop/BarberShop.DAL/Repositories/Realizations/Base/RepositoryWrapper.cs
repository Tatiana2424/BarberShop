using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces;
using BarberShop.DAL.Repositories.Interfaces.Base;

namespace BarberShop.DAL.Repositories.Realizations.Base;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly BarberShopDbContext _barberShopDbContext;

    private IBarberRepository _barberRepository;

    private ICategoryRepository _categoryRepository;

    private IOrderRepository _orderRepository;

    private IPlaceRepository _placeRepository;

    private IServiceRepository _serviceRepository;

    private IStatusRepository _statusRepository;

    private IUserRepository _userRepository;

    public int SaveChanges()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public RepositoryWrapper(BarberShopDbContext barberShopDbContext)
    {
        _barberShopDbContext = barberShopDbContext;
    }

    public IBarberRepository BarberRepository 
    { 
        get 
        {
            if (_barberRepository is null)
            {
                _barberRepository = new BarberRepository(_barberShopDbContext);
            }
            return _barberRepository; 
        } 
    }
    //    public IFactRepository FactRepository
    //    {
    //        get
    //        {
    //            if (_factRepository is null)
    //            {
    //                _factRepository = new FactRepository(_streetcodeDbContext);
    //            }

    //            return _factRepository;
    //        }
    //    }

    //    public IImageRepository ImageRepository
    //    {
    //        get
    //        {
    //            if (_imageRepository is null)
    //            {
    //                _imageRepository = new ImageRepository(_streetcodeDbContext);
    //            }

    //            return _imageRepository;
    //        }
    //    }

    //    public IAudioRepository AudioRepository
    //    {
    //        get
    //        {
    //            if (_audioRepository is null)
    //            {
    //                _audioRepository = new AudioRepository(_streetcodeDbContext);
    //            }

    //            return _audioRepository;
    //        }
    //    }

    //    public IStreetcodeCoordinateRepository StreetcodeCoordinateRepository
    //    {
    //        get
    //        {
    //            if (_streetcodeCoordinateRepository is null)
    //            {
    //                _streetcodeCoordinateRepository = new StreetcodeCoordinateRepository(_streetcodeDbContext);
    //            }

    //            return _streetcodeCoordinateRepository;
    //        }
    //    }

    //    public IVideoRepository VideoRepository
    //    {
    //        get
    //        {
    //            if (_videoRepository is null)
    //            {
    //                _videoRepository = new VideoRepository(_streetcodeDbContext);
    //            }

    //            return _videoRepository;
    //        }
    //    }

    //    public IArtRepository ArtRepository
    //    {
    //        get
    //        {
    //            if (_artRepository is null)
    //            {
    //                _artRepository = new ArtRepository(_streetcodeDbContext);
    //            }

    //            return _artRepository;
    //        }
    //    }

    //    public IStreetcodeArtRepository StreetcodeArtRepository
    //    {
    //        get
    //        {
    //            if (_streetcodeArtRepository is null)
    //            {
    //                _streetcodeArtRepository = new StreetcodeArtRepository(_streetcodeDbContext);
    //            }

    //            return _streetcodeArtRepository;
    //        }
    //    }

    //    public IPartnersRepository PartnersRepository
    //    {
    //        get
    //        {
    //            if (_partnersRepository is null)
    //            {
    //                _partnersRepository = new PartnersRepository(_streetcodeDbContext);
    //            }

    //            return _partnersRepository;
    //        }
    //    }

    //    public ISourceCategoryRepository SourceCategoryRepository
    //    {
    //        get
    //        {
    //            if (_sourceCategoryRepository is null)
    //            {
    //                _sourceCategoryRepository = new SourceCategoryRepository(_streetcodeDbContext);
    //            }

    //            return _sourceCategoryRepository;
    //        }
    //    }

    //    public ISourceSubCategoryRepository SourceSubCategoryRepository
    //    {
    //        get
    //        {
    //            if (_sourceSubCategoryRepository is null)
    //            {
    //                _sourceSubCategoryRepository = new SourceSubCategoryRepository(_streetcodeDbContext);
    //            }

    //            return _sourceSubCategoryRepository;
    //        }
    //    }

    //    public IRelatedFigureRepository RelatedFigureRepository
    //    {
    //        get
    //        {
    //            if (_relatedFigureRepository is null)
    //            {
    //                _relatedFigureRepository = new RelatedFigureRepository(_streetcodeDbContext);
    //            }

    //            return _relatedFigureRepository;
    //        }
    //    }

    //    public IStreetcodeRepository StreetcodeRepository
    //    {
    //        get
    //        {
    //            if (_streetcodeRepository is null)
    //            {
    //                _streetcodeRepository = new StreetcodeRepository(_streetcodeDbContext);
    //            }

    //            return _streetcodeRepository;
    //        }
    //    }

    //    public ISubtitleRepository SubtitleRepository
    //    {
    //        get
    //        {
    //            if (_subtitleRepository is null)
    //            {
    //                _subtitleRepository = new SubtitleRepository(_streetcodeDbContext);
    //            }

    //            return _subtitleRepository;
    //        }
    //    }

    //    public ITagRepository TagRepository
    //    {
    //        get
    //        {
    //            if (_tagRepository is null)
    //            {
    //                _tagRepository = new TagRepository(_streetcodeDbContext);
    //            }

    //            return _tagRepository;
    //        }
    //    }

    //    public ITermRepository TermRepository
    //    {
    //        get
    //        {
    //            if (_termRepository is null)
    //            {
    //                _termRepository = new TermRepository(_streetcodeDbContext);
    //            }

    //            return _termRepository;
    //        }
    //    }

    //    public ITextRepository TextRepository
    //    {
    //        get
    //        {
    //            if (_textRepository is null)
    //            {
    //                _textRepository = new TextRepository(_streetcodeDbContext);
    //            }

    //            return _textRepository;
    //        }
    //    }

    //    public ITimelineRepository TimelineRepository
    //    {
    //        get
    //        {
    //            if (_timelineRepository is null)
    //            {
    //                _timelineRepository = new TimelineRepository(_streetcodeDbContext);
    //            }

    //            return _timelineRepository;
    //        }
    //    }

    //    public IToponymRepository ToponymRepository
    //    {
    //        get
    //        {
    //            if (_toponymRepository is null)
    //            {
    //                _toponymRepository = new ToponymRepository(_streetcodeDbContext);
    //            }

    //            return _toponymRepository;
    //        }
    //    }

    //    public ITransactLinksRepository TransactLinksRepository
    //    {
    //        get
    //        {
    //            if (_transactLinksRepository is null)
    //            {
    //                _transactLinksRepository = new TransactLinksRepository(_streetcodeDbContext);
    //            }

    //            return _transactLinksRepository;
    //        }
    //    }

    //    public int SaveChanges()
    //    {
    //        return _streetcodeDbContext.SaveChanges();
    //    }

    //    public async Task<int> SaveChangesAsync()
    //    {
    //        return await _streetcodeDbContext.SaveChangesAsync();
    //    }

}