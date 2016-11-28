using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Aplication.Interfaces;
using Domain.Entities;
using Presentation.ViewModels.Loan;
using AutoMapper;

namespace Presentation.Controllers
{
    [Authorize]
    public class LoanController : BaseController
    {
    }
}
