﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DHJ.FileManagement.Web.Areas.AppAreaName.Models.Layout;
using DHJ.FileManagement.Web.Session;
using DHJ.FileManagement.Web.Views;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameTheme2Brand
{
    public class AppAreaNameTheme2BrandViewComponent : FileManagementViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameTheme2BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
