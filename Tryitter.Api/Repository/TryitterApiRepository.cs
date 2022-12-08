using Tryitter.Api.Models;

namespace tryitter_api.Repository;

public class TryitterApiRepository : ITryitterApiRepository
{
  private readonly ITryitterApiContext _context;

  public TryitterApiRepository(ITryitterApiContext context)
  {
    _context = context;
  }
  
}