using Domain.EntityModels.Additional.Common;

namespace Domain.ViewModels;

public record ProductHeaderVm(string Product, string Producer,
    int Rate, int ReviewsAmount, int ProductId, ProductType ProductType);
