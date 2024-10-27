using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
    
public record ReviewDTO(int Id, string Username, int UserId, string Content, int Rate, DateTime ReleaseDate);