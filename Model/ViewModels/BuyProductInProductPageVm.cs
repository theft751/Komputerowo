using Domain.EntityModels.Additional.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels;
public record BuyProductInProductPageVm(int ProductId, Availability Availability, int ProductAmount, UserType UserType, decimal Price, int PageNumber);

