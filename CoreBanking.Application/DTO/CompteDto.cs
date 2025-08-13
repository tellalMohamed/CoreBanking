using CoreBanking.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Application.DTO
{
    public class CompteDto
    {
        public required AccountNumber AccountNumber { get; set; }
        public int CustomerId { get; set; }
    }
}