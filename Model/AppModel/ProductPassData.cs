using Model.EntityModels.Additional.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AppModel
{
    public record ProductPassData
    (
        int Id,
        OperationMode OperationMode,
        string AdditionalInfo,
        string Color,
        int Amount,
        int GuarantyTime,
        string Name,
        string Description,
        decimal Price,
        string Producer
    );
}
