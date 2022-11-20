using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers
{
    public class UserConfigQueryItemHandler : IQueryHandler<QueryItem<UserConfigs>, Result<UserConfigs>>
    {
        private readonly IUserConfigRepository _userConfigRepository;

        public UserConfigQueryItemHandler(IUserConfigRepository userConfigRepository)
        {
            _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
        }

        public async Task<Result<UserConfigs>> Handle(QueryItem<UserConfigs> request, CancellationToken cancellationToken)
        {
            return await _userConfigRepository.GetConfig(request, cancellationToken);
        }
    }
}
