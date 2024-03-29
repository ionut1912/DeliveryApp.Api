﻿using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Query.Account;

public class GetCurrentUserQuery : IQuery<ResultT<User>>
{
    public string Username { get; set; }
}