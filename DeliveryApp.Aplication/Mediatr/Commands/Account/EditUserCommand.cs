using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DeliveryApp.Application.Mediatr.Commands.Account;

public class EditUserCommand : ICommand<ResultT<EditCurrentUserResponse>>
{
    public UserDto UserToBeEdited { get; set; }
    public ModelStateDictionary ModelState { get; set; }
}