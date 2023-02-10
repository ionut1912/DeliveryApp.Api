using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;

public class UserConfigCreateCommand : ICommand<Result<Repository.Entities.UserConfigs>>
{
    public UserConfigForCreation UserConfigs { get; set; }
}