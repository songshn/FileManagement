﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DHJ.FileManagement.Web.Areas.AppAreaName.Models.Layout;
using DHJ.FileManagement.Web.Session;
using DHJ.FileManagement.Web.Views;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameTenantLogo
{
    public class AppAreaNameLogoViewComponent : FileManagementViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;
        
        public AppAreaNameLogoViewComponent(
            IPerRequestSessionCache sessionCache
        )
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string logoSkin = null)
        {
            var headerModel = new LogoViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                LogoSkinOverride = logoSkin
            };
            
            return View(headerModel);
        }
    }
}
