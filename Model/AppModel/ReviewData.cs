using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AppModel;

public record ReviewData(int Id, string Username, int UserId, string Content, int Rate, DateTime ReleaseDate);