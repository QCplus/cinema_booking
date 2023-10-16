using CinemaBooking.Core.Dtos.MovieSessionsAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.MovieSessionsAggr.SearchSessions;

internal class SearchSessionsHandler : IRequestHandler<SearchSessionsCommand, IEnumerable<MovieSessionDto>>
{
    public Task<IEnumerable<MovieSessionDto>> Handle(SearchSessionsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
