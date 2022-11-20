using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers
{
    public class UserConfigListQueryHandler : IQueryHandler<ListQuery<UserConfigs>, Result<List<UserConfigs>>>
    {
        private readonly IUserConfigRepository _userConfigRepository;

        public UserConfigListQueryHandler(IUserConfigRepository userConfigRepository)
        {
            _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
        }

        public async Task<Result<List<UserConfigs>>> Handle(ListQuery<UserConfigs> request,
            CancellationToken cancellationToken)
        {
            return await _userConfigRepository.GetConfigs(request, cancellationToken);
        }
    }
}
