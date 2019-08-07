﻿using System.Threading.Tasks;
using DHJ.FileManagement.ApiClient.Models;

namespace DHJ.FileManagement.Services.Account
{
    public interface IAccountService
    {
        AbpAuthenticateModel AbpAuthenticateModel { get; set; }
        AbpAuthenticateResultModel AuthenticateResultModel { get; set; }
        Task LoginUserAsync();
    }
}
