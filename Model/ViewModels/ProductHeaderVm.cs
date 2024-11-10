using Model.EntityModels.Additional.Common;

namespace Domain.ViewModels;

public record ProductHeaderVm(string Product, string Producer,
    int Rate, int ReviewsAmount, int productId, ProductType ProductType);
