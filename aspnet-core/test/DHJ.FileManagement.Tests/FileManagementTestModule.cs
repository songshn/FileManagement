﻿using System;
using System.IO;
using Abp;
using Abp.AspNetZeroCore;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.Organizations;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using DHJ.FileManagement.Authorization.Roles;
using DHJ.FileManagement.Authorization.Users;
using DHJ.FileManagement.Configuration;
using DHJ.FileManagement.EntityFrameworkCore;
using DHJ.FileManagement.MultiTenancy;
using DHJ.FileManagement.Security.Recaptcha;
using DHJ.FileManagement.Tests.Configuration;
using DHJ.FileManagement.Tests.DependencyInjection;
using DHJ.FileManagement.Tests.UiCustomization;
using DHJ.FileManagement.Tests.Url;
using DHJ.FileManagement.Tests.Web;
using DHJ.FileManagement.UiCustomization;
using DHJ.FileManagement.Url;
using NSubstitute;

namespace DHJ.FileManagement.Tests
{
    [DependsOn(
        typeof(FileManagementApplicationModule),
        typeof(FileManagementEntityFrameworkCoreModule),
        typeof(AbpTestBaseModule))]
    public class FileManagementTestModule : AbpModule
    {
        public FileManagementTestModule(FileManagementEntityFrameworkCoreModule FileManagementEntityFrameworkCoreModule)
        {
            FileManagementEntityFrameworkCoreModule.SkipDbContextRegistration = true;
        }

        public override void PreInitialize()
        {
            var configuration = GetConfiguration();

            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            //Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<AbpZeroDbMigrator>();

            IocManager.Register<IAppUrlService, FakeAppUrlService>();
            IocManager.Register<IWebUrlService, FakeWebUrlService>();
            IocManager.Register<IRecaptchaValidator, FakeRecaptchaValidator>();

            Configuration.ReplaceService<IAppConfigurationAccessor, TestAppConfigurationAccessor>();
            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);

            Configuration.ReplaceService<IUiThemeCustomizerFactory, NullUiThemeCustomizerFactory>();

            Configuration.Modules.AspNetZero().LicenseCode = configuration["AbpZeroLicenseCode"];

            //Uncomment below line to write change logs for the entities below:
            Configuration.EntityHistory.IsEnabled = true;
            Configuration.EntityHistory.Selectors.Add("FileManagementEntities", typeof(User), typeof(Tenant));
        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager);
        }

        private void RegisterFakeService<TService>()
            where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return AppConfigurations.Get(Directory.GetCurrentDirectory(), addUserSecrets: true);
        }
    }
}
