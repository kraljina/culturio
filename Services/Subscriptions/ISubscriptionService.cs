using AutoMapper;
using Span.Culturio.Api.Data;

namespace Span.Culturio.Api.Services.Subscriptions {
    public class ISubscriptionService {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ISubscriptionService(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
    }
}
