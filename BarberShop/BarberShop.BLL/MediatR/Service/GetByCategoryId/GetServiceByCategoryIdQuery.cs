﻿using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BLL.MediatR.Service.GetByCategoryId;

public record GetServiceByCategoryIdQuery(int CatrgoryId) : IRequest<Result<IEnumerable<ServiceDTO>>>;
