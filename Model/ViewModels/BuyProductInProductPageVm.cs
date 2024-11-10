using Model.EntityModels.Additional.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels;
public record BuyProductInProductPageVm(Availability Availability, int ProductAmount, UserType UserType, decimal Price);

