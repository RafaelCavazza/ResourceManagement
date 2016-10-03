using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Employee;
using Domain.Entities;
using System;
using Aplication.Interfaces;
using System.Linq;

namespace Presentation.Controllers
{
    [Authorize]
    public class BranchsController : BaseController
    {    
    }
}
