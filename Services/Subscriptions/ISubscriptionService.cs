using AutoMapper;
using Span.Culturio.Api.Data;
using Span.Culturio.Api.Models.Subscriptions;

namespace Span.Culturio.Api.Services.Subscriptions
{
    public interface ISubscriptionService {
        Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto createSubscriptionDto);
        Task<SubscriptionDto> GetAsync(int userId);
    }
}
