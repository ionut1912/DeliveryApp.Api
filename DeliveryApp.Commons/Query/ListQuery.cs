﻿using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Commons.Query;

public class ListQuery<T> : IQuery<ResultT<List<T>>>
{
}