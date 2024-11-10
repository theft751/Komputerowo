using Domain.AppModel;

namespace Domain.ViewModels;

public record ReviewAreaVm(ICollection<ReviewData> ReviewsData, int ProductId, int PageNumber,
    int ReviewsAmount, int ReviewsPageAmount);

